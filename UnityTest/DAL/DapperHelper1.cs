using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 对于Dapper.SimpleCRUD扩展主类
    /// </summary>
    public static partial class SimpleCRUD
    {
        /// <summary>
        /// 数据库服务器方言
        /// </summary>
        public enum Dialect
        {
            SQLServer,
            PostgreSQL,
            SQLite,
            MySQL,
        }

        private static Dialect _dialect = Dialect.SQLServer;
        private static string _encapsulation;
        private static string _getIdentitySql;
        private static string _getPagedListSql;

        static SimpleCRUD()
        {
            SetDialect(_dialect);
        }

        /// <summary>
        ///  返回当前方言名称
        /// </summary>
        /// <returns></returns>
        public static string GetDialect()
        {
            return _dialect.ToString();
        }

        /// <summary>
        ///  设置数据库方言
        /// </summary>
        /// <param name="dialect"></param>
        public static void SetDialect(Dialect dialect)
        {
            switch (dialect)
            {
                case Dialect.PostgreSQL:
                    _dialect = Dialect.PostgreSQL;
                    _encapsulation = "{0}";
                    _getIdentitySql = string.Format("SELECT LASTVAL() AS id");
                    _getPagedListSql =
                        "Select {SelectColumns} from {TableName} {WhereClause} Order By {OrderBy} LIMIT {RowsPerPage} OFFSET (({PageNumber}-1) * {RowsPerPage})";
                    break;
                case Dialect.SQLite:
                    _dialect = Dialect.SQLite;
                    _encapsulation = "{0}";
                    _getIdentitySql = string.Format("SELECT LAST_INSERT_ROWID() AS id");
                    _getPagedListSql =
                        "Select {SelectColumns} from {TableName} {WhereClause} Order By {OrderBy} LIMIT {RowsPerPage} OFFSET (({PageNumber}-1) * {RowsPerPage})";
                    break;
                case Dialect.MySQL:
                    _dialect = Dialect.MySQL;
                    _encapsulation = "`{0}`";
                    _getIdentitySql = string.Format("SELECT LAST_INSERT_ID() AS id");
                    _getPagedListSql =
                        "Select {SelectColumns} from {TableName} {WhereClause} Order By {OrderBy} LIMIT {Offset},{RowsPerPage}";
                    break;
                default:
                    _dialect = Dialect.SQLServer;
                    _encapsulation = "[{0}]";
                    _getIdentitySql = string.Format("SELECT CAST(SCOPE_IDENTITY()  AS BIGINT) AS [id]");
                    _getPagedListSql =
                        "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {OrderBy}) AS PagedNumber, {SelectColumns} FROM {TableName} {WhereClause}) AS u WHERE PagedNUMBER BETWEEN (({PageNumber}-1) * {RowsPerPage} + 1) AND ({PageNumber} * {RowsPerPage})";
                    break;
            }
        }

        /// <summary>
        ///     <para>默认情况下查询匹配类名的表</para>
        ///     <para>表名称可以通过在你的类增加一个属性[Table("YourTableName")]被覆盖</para>
        /// 
        ///     <para>通过对Id列默认筛选器</para>
        ///     <para>ID列名可以添加主键属性[Key]来覆盖</para>
        /// 
        ///     <para>支持事务，命令超时</para>
        ///     <para>从表T 一个ID返回一个单一的实体</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>从表T 一个ID返回一个单一的实体</returns>
        public static T Get<T>(this IDbConnection connection, object id, IDbTransaction transaction = null,
            int? commandTimeout = null)
        {
            Type currenttype = typeof(T);
            List<PropertyInfo> idProps = GetIdProperties(currenttype).ToList();

            if (!idProps.Any())
                throw new ArgumentException("Get<T> only supports an entity with a [Key] or Id property");
            if (idProps.Count() > 1)
                throw new ArgumentException("Get<T> only supports an entity with a single [Key] or Id property");

            PropertyInfo onlyKey = idProps.First();
            string name = GetTableName(currenttype);
            var sb = new StringBuilder();
            sb.Append("Select ");
            //创建类型的新空实例，以获得基本属性
            BuildSelect(sb, GetScaffoldableProperties((T)Activator.CreateInstance(typeof(T))).ToArray());
            sb.AppendFormat(" from {0}", name);
            sb.Append(" where " + GetColumnName(onlyKey) + " = @Id");

            var dynParms = new DynamicParameters();
            dynParms.Add("@id", id);

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("Get<{0}>: {1} with Id: {2}", currenttype, sb, id));

            return connection.Query<T>(sb.ToString(), dynParms, transaction, true, commandTimeout).FirstOrDefault();
        }

        /// <summary>
        ///     <para>默认情况下查询匹配类名的表</para>
        ///     <para>表名称可以通过在你的类增加一个属性[Table("YourTableName")]被覆盖</para>
        ///     <para>whereConditions条件是一个匿名类型来过滤结果 ex: new {Category = 1, SubCategory=2}</para>
        ///      
        ///     <para>支持事务，命令超时</para>
        ///     <para>返回匹配条件的实体列表</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="whereConditions"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>获取具有可选的精确匹配的条件的实体列表</returns>
        public static IEnumerable<T> GetList<T>(this IDbConnection connection, object whereConditions,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Type currenttype = typeof(T);
            List<PropertyInfo> idProps = GetIdProperties(currenttype).ToList();
            if (!idProps.Any())
                throw new ArgumentException("Entity must have at least one [Key] property");

            string name = GetTableName(currenttype);

            var sb = new StringBuilder();
            PropertyInfo[] whereprops = GetAllProperties(whereConditions).ToArray();
            sb.Append("Select ");
            //创建该类型的新的空实例来获得基本属性
            BuildSelect(sb, GetScaffoldableProperties((T)Activator.CreateInstance(typeof(T))).ToArray());
            sb.AppendFormat(" from {0}", name);

            if (whereprops.Any())
            {
                sb.Append(" where ");
                BuildWhere(sb, whereprops, (T)Activator.CreateInstance(typeof(T)), whereConditions);
            }

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("GetList<{0}>: {1}", currenttype, sb));

            return connection.Query<T>(sb.ToString(), whereConditions, transaction, true, commandTimeout);
        }

        /// <summary>
        ///     <para>默认情况下查询匹配类名的表</para>
        ///     <para>表名称可以通过在你的类增加一个属性[Table("YourTableName")]被覆盖</para>
        ///     <para>条件是一个SQL where子句 和/或ORDER BY子句 ex: "where name='bob'"</para>
        ///     <para>支持事务，命令超时</para>
        ///     <para>返回匹配条件的实体列表</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="conditions"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>获取实体具有可选的SQL where条件列表</returns>
        public static IEnumerable<T> GetList<T>(this IDbConnection connection, string conditions,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Type currenttype = typeof(T);
            List<PropertyInfo> idProps = GetIdProperties(currenttype).ToList();
            if (!idProps.Any())
                throw new ArgumentException("Entity must have at least one [Key] property");

            string name = GetTableName(currenttype);

            var sb = new StringBuilder();
            sb.Append("Select ");
            //创建该类型的新空实例来获得基本属性
            BuildSelect(sb, GetScaffoldableProperties((T)Activator.CreateInstance(typeof(T))).ToArray());
            sb.AppendFormat(" from {0}", name);

            sb.Append(" " + conditions);

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("GetList<{0}>: {1}", currenttype, sb));

            return connection.Query<T>(sb.ToString(), null, transaction, true, commandTimeout);
        }

        public static IEnumerable<T> GetList<T>(this IDbConnection connection)
        {
            return connection.GetList<T>(new { });
        }

        public static IEnumerable<T> GetListPaged<T>(this IDbConnection connection, int pageNumber, int rowsPerPage,
            string conditions, string orderby, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (string.IsNullOrEmpty(_getPagedListSql))
                throw new Exception("GetListPage is not supported with the current SQL Dialect");

            if (pageNumber < 1)
                throw new Exception("Page must be greater than 0");

            Type currenttype = typeof(T);
            List<PropertyInfo> idProps = GetIdProperties(currenttype).ToList();
            if (!idProps.Any())
                throw new ArgumentException("Entity must have at least one [Key] property");

            string name = GetTableName(currenttype);
            var sb = new StringBuilder();
            string query = _getPagedListSql;
            if (string.IsNullOrEmpty(orderby))
            {
                orderby = GetColumnName(idProps.First());
            }

            //创建类型的新空实例，以获得基本属性
            BuildSelect(sb, GetScaffoldableProperties((T)Activator.CreateInstance(typeof(T))).ToArray());
            query = query.Replace("{SelectColumns}", sb.ToString());
            query = query.Replace("{TableName}", name);
            query = query.Replace("{PageNumber}", pageNumber.ToString());
            query = query.Replace("{RowsPerPage}", rowsPerPage.ToString());
            query = query.Replace("{OrderBy}", orderby);
            query = query.Replace("{WhereClause}", conditions);
            query = query.Replace("{Offset}", ((pageNumber - 1) * rowsPerPage).ToString());

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("GetListPaged<{0}>: {1}", currenttype, query));

            return connection.Query<T>(query, null, transaction, true, commandTimeout);
        }

        /// <summary>
        ///     <para>插入行到数据库</para>
        ///     <para>默认情况下插入到匹配类名的表</para>
        ///     <para>表名称可以通过在你的类增加一个属性[Table("YourTableName")]被覆盖</para>
        ///     <para>将过滤掉Id列，任何[Key]属性的列</para>
        ///     <para>标有[Editable(false)] 属性和复杂类型的属性被忽略</para>
        ///     <para>支持事务，命令超时</para>
        ///     <para>
        ///         如果是identity的int?类型，返回新插入的记录的ID（主键）,否则返回null
        ///     </para>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="entityToInsert"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>如果是identity的int?类型，返回新插入的记录的ID（主键）,否则返回null</returns>
        public static int? Insert(this IDbConnection connection, object entityToInsert,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Insert<int?>(connection, entityToInsert, transaction, commandTimeout);
        }

        /// <summary>
        ///     <para>插入行到数据库</para>
        ///     <para>默认情况下插入到匹配类名的表</para>
        ///     <para>表名称可以通过在你的类增加一个属性[Table("YourTableName")]被覆盖</para>
        ///     <para>将过滤掉Id列，任何[Key]属性的列</para>
        ///     <para>标有[Editable(false)] 属性和复杂类型的属性被忽略</para>
        ///     <para>支持事务，命令超时</para>
        ///     <para>
        ///         如果是identity的int?类型，返回新插入的记录的ID（主键）,否则返回null
        ///     </para>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="entityToInsert"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>如果是identity的int?类型，返回新插入的记录的ID（主键）,否则返回null</returns>
        public static TKey Insert<TKey>(this IDbConnection connection, object entityToInsert,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            List<PropertyInfo> idProps = GetIdProperties(entityToInsert).ToList();

            if (!idProps.Any())
                throw new ArgumentException("Insert<T> only supports an entity with a [Key] or Id property");
            if (idProps.Count() > 1)
                throw new ArgumentException("Insert<T> only supports an entity with a single [Key] or Id property");

            bool keyHasPredefinedValue = false;
            Type baseType = typeof(TKey);
            Type underlyingType = Nullable.GetUnderlyingType(baseType);
            Type keytype = underlyingType ?? baseType;
            if (keytype != typeof(int) && keytype != typeof(uint) && keytype != typeof(long) &&
                keytype != typeof(ulong) && keytype != typeof(short) && keytype != typeof(ushort) &&
                keytype != typeof(Guid))
            {
                throw new Exception("Invalid return type");
            }

            string name = GetTableName(entityToInsert);
            var sb = new StringBuilder();
            sb.AppendFormat("insert into {0}", name);
            sb.Append(" (");
            BuildInsertParameters(entityToInsert, sb);
            sb.Append(") ");
            sb.Append("values");
            sb.Append(" (");
            BuildInsertValues(entityToInsert, sb);
            sb.Append(")");

            if (keytype == typeof(Guid))
            {
                var guidvalue = (Guid)idProps.First().GetValue(entityToInsert, null);
                if (guidvalue == Guid.Empty)
                {
                    Guid newguid = SequentialGuid();
                    idProps.First().SetValue(entityToInsert, newguid, null);
                }
                else
                {
                    keyHasPredefinedValue = true;
                }
                sb.Append(";select '" + idProps.First().GetValue(entityToInsert, null) + "' as id");
            }

            if ((keytype == typeof(int) || keytype == typeof(long)) &&
                Convert.ToInt64(idProps.First().GetValue(entityToInsert, null)) == 0)
            {
                sb.Append(";" + _getIdentitySql);
            }
            else
            {
                keyHasPredefinedValue = true;
            }

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("Insert: {0}", sb));

            IEnumerable<dynamic> r = connection.Query(sb.ToString(), entityToInsert, transaction, true, commandTimeout);

            if (keytype == typeof(Guid) || keyHasPredefinedValue)
            {
                return (TKey)idProps.First().GetValue(entityToInsert, null);
            }
            return (TKey)r.First().id;
        }

        /// <summary>
        ///     <para>更新数据库中的单条记录或多条记录</para>
        ///     <para>默认情况下更新匹配类名的表</para>
        ///     <para>表名称可以通过在你的类增加一个属性[Table("YourTableName")]被覆盖</para>
        ///     <para>  更新 Id属性和[Key]属性 在数据库中匹配的 记录 </para>
        ///     <para>标有[Editable(false)] 属性和复杂类型的属性被忽略</para>
        ///     <para>支持事务，命令超时</para>
        ///     <para>返回影响的行数</para>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="entityToUpdate"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>影响的行数</returns>
        public static int Update(this IDbConnection connection, object entityToUpdate, IDbTransaction transaction = null,
            int? commandTimeout = null)
        {
            List<PropertyInfo> idProps = GetIdProperties(entityToUpdate).ToList();

            if (!idProps.Any())
                throw new ArgumentException("Entity must have at least one [Key] or Id property");

            string name = GetTableName(entityToUpdate);

            var sb = new StringBuilder();
            sb.AppendFormat("update {0}", name);

            sb.AppendFormat(" set ");
            BuildUpdateSet(entityToUpdate, sb);
            sb.Append(" where ");
            BuildWhere(sb, idProps, entityToUpdate);

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("Update: {0}", sb));

            return connection.Execute(sb.ToString(), entityToUpdate, transaction, commandTimeout);
        }

        /// <summary>
        ///     <para> 删除数据库中匹配传入的对象的单条记录或多条记录</para>
        ///     <para> 默认删除匹配类名的表中的记录</para>
        ///     <para>表名称可以通过在你的类增加一个属性[Table("YourTableName")]被覆盖</para>
        ///     <para>支持事务，命令超时</para>
        ///     <para>返回影响的行数</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entityToDelete"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of records effected</returns>
        public static int Delete<T>(this IDbConnection connection, T entityToDelete, IDbTransaction transaction = null,
            int? commandTimeout = null)
        {
            List<PropertyInfo> idProps = GetIdProperties(entityToDelete).ToList();


            if (!idProps.Any())
                throw new ArgumentException("Entity must have at least one [Key] or Id property");

            string name = GetTableName(entityToDelete);

            var sb = new StringBuilder();
            sb.AppendFormat("delete from {0}", name);

            sb.Append(" where ");
            BuildWhere(sb, idProps, entityToDelete);

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("Delete: {0}", sb));

            return connection.Execute(sb.ToString(), entityToDelete, transaction, commandTimeout);
        }

        /// <summary>
        ///     <para>根据ID删除数据库中单条记录或多条记录</para>
        ///     <para>默认删除匹配类名的表中的记录</para>
        ///     <para>表名称可以通过在你的类增加一个属性[Table("YourTableName")]被覆盖</para>
        ///     <para>删除其中ID属性和 [Key]属性 匹配数据库中的记录</para>
        ///     <para>影响的行数</para>
        ///     支持事务，命令超时
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>影响的行数</returns>
        public static int Delete<T>(this IDbConnection connection, object id, IDbTransaction transaction = null,
            int? commandTimeout = null)
        {
            Type currenttype = typeof(T);
            List<PropertyInfo> idProps = GetIdProperties(currenttype).ToList();


            if (!idProps.Any())
                throw new ArgumentException("Delete<T> only supports an entity with a [Key] or Id property");
            if (idProps.Count() > 1)
                throw new ArgumentException("Delete<T> only supports an entity with a single [Key] or Id property");

            PropertyInfo onlyKey = idProps.First();
            string name = GetTableName(currenttype);

            var sb = new StringBuilder();
            sb.AppendFormat("Delete from {0}", name);
            sb.Append(" where " + GetColumnName(onlyKey) + " = @Id");

            var dynParms = new DynamicParameters();
            dynParms.Add("@id", id);

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("Delete<{0}> {1}", currenttype, sb));

            return connection.Execute(sb.ToString(), dynParms, transaction, commandTimeout);
        }

        public static int DeleteList<T>(this IDbConnection connection, object whereConditions,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Type currenttype = typeof(T);
            string name = GetTableName(currenttype);

            var sb = new StringBuilder();
            PropertyInfo[] whereprops = GetAllProperties(whereConditions).ToArray();
            sb.AppendFormat("Delete from {0}", name);
            if (whereprops.Any())
            {
                sb.Append(" where ");
                BuildWhere(sb, whereprops, (T)Activator.CreateInstance(typeof(T)));
            }

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("DeleteList<{0}> {1}", currenttype, sb));

            return connection.Execute(sb.ToString(), whereConditions, transaction, commandTimeout);
        }

        public static int DeleteList<T>(this IDbConnection connection, string conditions,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (string.IsNullOrEmpty(conditions))
                throw new ArgumentException("DeleteList<T> requires a where clause");
            if (!conditions.ToLower().Contains("where"))
                throw new ArgumentException("DeleteList<T> requires a where clause and must contain the WHERE keyword");

            Type currenttype = typeof(T);
            string name = GetTableName(currenttype);

            var sb = new StringBuilder();
            sb.AppendFormat("Delete from {0}", name);
            sb.Append(" " + conditions);

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("DeleteList<{0}> {1}", currenttype, sb));

            return connection.Execute(sb.ToString(), null, transaction, commandTimeout);
        }

        /// <summary>
        ///     <para>默认查询匹配类名的表中的记录</para>
        ///     <para>从表T根据一个ID返回一个条数</para>
        /// </summary>
        public static int RecordCount<T>(this IDbConnection connection, string conditions = "",
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Type currenttype = typeof(T);
            string name = GetTableName(currenttype);
            var sb = new StringBuilder();
            sb.Append("Select count(1)");
            sb.AppendFormat(" from {0}", name);
            sb.Append(" " + conditions);

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("RecordCount<{0}>: {1}", currenttype, sb));

            return connection.Query<int>(sb.ToString(), null, transaction, true, commandTimeout).Single();
        }

        //构建基于实体列表update语句
        private static void BuildUpdateSet(object entityToUpdate, StringBuilder sb)
        {
            PropertyInfo[] nonIdProps = GetUpdateableProperties(entityToUpdate).ToArray();

            for (int i = 0; i < nonIdProps.Length; i++)
            {
                PropertyInfo property = nonIdProps[i];

                sb.AppendFormat("{0} = @{1}", GetColumnName(property), property.Name);
                if (i < nonIdProps.Length - 1)
                    sb.AppendFormat(", ");
            }
        }

        //build select clause based on list of properties skipping ones with the IgnoreSelect attribute
        //建立SELECT子句  基于属性列表  跳过那些IgnoreSelect属性
        private static void BuildSelect(StringBuilder sb, IEnumerable<PropertyInfo> props)
        {
            IList<PropertyInfo> propertyInfos = props as IList<PropertyInfo> ?? props.ToList();
            bool addedAny = false;
            for (int i = 0; i < propertyInfos.Count(); i++)
            {
                if (
                    propertyInfos.ElementAt(i)
                        .GetCustomAttributes(true)
                        .Any(attr => attr.GetType().Name == "IgnoreSelectAttribute")) continue;

                if (addedAny)
                    sb.Append(",");
                sb.Append(GetColumnName(propertyInfos.ElementAt(i)));
                //如果有一个自定义的列名添加一个“as 自定义列名”的项，以便它映射正确
                if (
                    propertyInfos.ElementAt(i)
                        .GetCustomAttributes(true)
                        .SingleOrDefault(attr => attr.GetType().Name == "ColumnAttribute") != null)
                    sb.Append(" as " + propertyInfos.ElementAt(i).Name);
                addedAny = true;
            }
        }

        private static void BuildWhere(StringBuilder sb, IEnumerable<PropertyInfo> idProps, object sourceEntity,
            object whereConditions = null)
        {
            PropertyInfo[] propertyInfos = idProps.ToArray();
            for (int i = 0; i < propertyInfos.Count(); i++)
            {
                bool useIsNull = false;

                //通过列属性将模型类型转换为数据库列名
                PropertyInfo propertyToUse = propertyInfos.ElementAt(i);
                PropertyInfo[] sourceProperties = GetScaffoldableProperties(sourceEntity).ToArray();
                for (int x = 0; x < sourceProperties.Count(); x++)
                {
                    if (sourceProperties.ElementAt(x).Name == propertyInfos.ElementAt(i).Name)
                    {
                        propertyToUse = sourceProperties.ElementAt(x);

                        if (whereConditions != null && propertyInfos.ElementAt(i).CanRead &&
                            (propertyInfos.ElementAt(i).GetValue(whereConditions, null) == null ||
                             propertyInfos.ElementAt(i).GetValue(whereConditions, null) == DBNull.Value))
                        {
                            useIsNull = true;
                        }
                        break;
                    }
                }
                sb.AppendFormat(
                    useIsNull ? "{0} is null" : "{0} = @{1}",
                    GetColumnName(propertyToUse),
                    propertyInfos.ElementAt(i).Name);

                if (i < propertyInfos.Count() - 1)
                    sb.AppendFormat(" and ");
            }
        }


        //建立插入值，其中包括类的所有属性：
        //不是命名Id
        //不标记Editable(false)的属性
        //不标记[Key]的属性(非必须属性)
        //不标记[IgnoreInsert]
        private static void BuildInsertValues(object entityToInsert, StringBuilder sb)
        {
            PropertyInfo[] props = GetScaffoldableProperties(entityToInsert).ToArray();
            for (int i = 0; i < props.Count(); i++)
            {
                PropertyInfo property = props.ElementAt(i);
                if (property.PropertyType != typeof(Guid)
                    && property.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "KeyAttribute")
                    && property.GetCustomAttributes(true).All(attr => attr.GetType().Name != "RequiredAttribute"))
                    continue;
                if (property.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "IgnoreInsertAttribute"))
                    continue;
                if (
                    property.GetCustomAttributes(true)
                        .Any(attr => attr.GetType().Name == "ReadOnlyAttribute" && IsReadOnly(property))) continue;

                if (property.Name == "Id" &&
                    property.GetCustomAttributes(true).All(attr => attr.GetType().Name != "RequiredAttribute") &&
                    property.PropertyType != typeof(Guid)) continue;
                sb.AppendFormat("@{0}", property.Name);
                if (i < props.Count() - 1)
                    sb.Append(", ");
            }
            if (sb.ToString().EndsWith(", "))
                sb.Remove(sb.Length - 2, 2);
        }

        //build insert parameters which include all properties in the class that are not:
        //建立插入参数，其中包括类的所有属性，除了：
        //标记为 Editable(false)属性
        //标记为 [Key] 属性
        //标记为 [IgnoreInsert]
        //名为 Id的属性
        private static void BuildInsertParameters(object entityToInsert, StringBuilder sb)
        {
            PropertyInfo[] props = GetScaffoldableProperties(entityToInsert).ToArray();

            for (int i = 0; i < props.Count(); i++)
            {
                PropertyInfo property = props.ElementAt(i);
                if (property.PropertyType != typeof(Guid)
                    && property.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "KeyAttribute")
                    && property.GetCustomAttributes(true).All(attr => attr.GetType().Name != "RequiredAttribute"))
                    continue;
                if (property.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "IgnoreInsertAttribute"))
                    continue;

                if (
                    property.GetCustomAttributes(true)
                        .Any(attr => attr.GetType().Name == "ReadOnlyAttribute" && IsReadOnly(property))) continue;
                if (property.Name == "Id" &&
                    property.GetCustomAttributes(true).All(attr => attr.GetType().Name != "RequiredAttribute") &&
                    property.PropertyType != typeof(Guid)) continue;
                sb.Append(GetColumnName(property));
                if (i < props.Count() - 1)
                    sb.Append(", ");
            }
            if (sb.ToString().EndsWith(", "))
                sb.Remove(sb.Length - 2, 2);
        }

        //得到一个实体的所有属性
        private static IEnumerable<PropertyInfo> GetAllProperties(object entity)
        {
            if (entity == null) entity = new { };
            return entity.GetType().GetProperties();
        }

        //Get all properties that are not decorated with the Editable(false) attribute
        //获取未用Editable(false)装饰的所有属性
        private static IEnumerable<PropertyInfo> GetScaffoldableProperties(object entity)
        {
            IEnumerable<PropertyInfo> props =
                entity.GetType()
                    .GetProperties()
                    .Where(
                        p =>
                            p.GetCustomAttributes(true)
                                .Any(attr => attr.GetType().Name == "EditableAttribute" && !IsEditable(p)) == false);
            return props.Where(p => p.PropertyType.IsSimpleType() || IsEditable(p));
        }

        //fake the funk and try to mimick EditableAttribute in System.ComponentModel.DataAnnotations 
        //This allows use of the DataAnnotations property in the model and have the SimpleCRUD engine just figure it out without a reference
        //确定属性有AllowEdit键和返回它的boolean状态
        //并尝试致力于模拟EditableAttribute在System.ComponentModel.DataAnnotations
        //这允许在模型中使用DataAnnotations，不引用并已在SimpleCRUD引擎弄清楚
        private static bool IsEditable(PropertyInfo pi)
        {
            object[] attributes = pi.GetCustomAttributes(false);
            if (attributes.Length > 0)
            {
                dynamic write = attributes.FirstOrDefault(x => x.GetType().Name == "EditableAttribute");
                if (write != null)
                {
                    return write.AllowEdit;
                }
            }
            return false;
        }

        //fake the funk and try to mimick ReadOnlyAttribute in System.ComponentModel 
        //This allows use of the DataAnnotations property in the model and have the SimpleCRUD engine just figure it out without a reference
        //确定属性是否有IsReadOnly键和返回它的boolean状态
        //并尝试致力于模拟ReadOnlyAttribute在System.ComponentModel
        //这允许在模型中使用DataAnnotations，不引用并已在SimpleCRUD引擎只是弄清楚
        private static bool IsReadOnly(PropertyInfo pi)
        {
            object[] attributes = pi.GetCustomAttributes(false);
            if (attributes.Length > 0)
            {
                dynamic write = attributes.FirstOrDefault(x => x.GetType().Name == "ReadOnlyAttribute");
                if (write != null)
                {
                    return write.IsReadOnly;
                }
            }
            return false;
        }

        //得到的所有属性：
        //非名称为 Id
        //没有标记 Key 的属性
        //没有标记 ReadOnly
        //没有标记 IgnoreInsert
        private static IEnumerable<PropertyInfo> GetUpdateableProperties(object entity)
        {
            IEnumerable<PropertyInfo> updateableProperties = GetScaffoldableProperties(entity);
            //根据ID删除一个
            updateableProperties = updateableProperties.Where(p => p.Name != "Id");
            //根据key属性删除一个
            updateableProperties =
                updateableProperties.Where(
                    p => p.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "KeyAttribute") == false);
            //删除readonly的所有
            updateableProperties =
                updateableProperties.Where(
                    p =>
                        p.GetCustomAttributes(true)
                            .Any(attr => (attr.GetType().Name == "ReadOnlyAttribute") && IsReadOnly(p)) == false);
            //根据IgnoreUpdate属性删除
            updateableProperties =
                updateableProperties.Where(
                    p =>
                        p.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "IgnoreUpdateAttribute") == false);

            return updateableProperties;
        }

        //获取 被命名ID的或Key特性的所有属性
        //为了插入和更新
        private static IEnumerable<PropertyInfo> GetIdProperties(object entity)
        {
            Type type = entity.GetType();
            return GetIdProperties(type);
        }

        //获取被命名ID的或Key特性的所有属性
        //对于获取（ID）和删除（ID），我们没有一个实体，正好类型，以便使用此方法
        private static IEnumerable<PropertyInfo> GetIdProperties(Type type)
        {
            List<PropertyInfo> tp =
                type.GetProperties()
                    .Where(p => p.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "KeyAttribute"))
                    .ToList();
            return tp.Any() ? tp : type.GetProperties().Where(p => p.Name == "Id");
        }

        //该实体 获取表名
        //插入和更新，我们有一个完整的实体因此使用这种方法
        //默认使用类名和覆盖，如果类有一个Table属性
        private static string GetTableName(object entity)
        {
            Type type = entity.GetType();
            return GetTableName(type);
        }

        //该实体 获取表名
        //对于获取（ID）和删除（ID），我们没有一个实体，正好类型，以便使用此方法
        //使用动态类型，以便能够同时处理我们的表属性和DataAnnotation
        //默认使用类名和覆盖，如果类有一个Table属性
        private static string GetTableName(Type type)
        {
            //var tableName = String.Format("[{0}]", type.Name);
            string tableName = Encapsulate(type.Name);

            var tableattr =
                type.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute") as
                    dynamic;
            if (tableattr != null)
            {
                //tableName = String.Format("[{0}]", tableattr.Name);
                tableName = Encapsulate(tableattr.Name);
                try
                {
                    if (!String.IsNullOrEmpty(tableattr.Schema))
                    {
                        //tableName = String.Format("[{0}].[{1}]", tableattr.Schema, tableattr.Name);
                        string schemaName = Encapsulate(tableattr.Schema);
                        tableName = String.Format("{0}.{1}", schemaName, tableName);
                    }
                }
                catch (RuntimeBinderException)
                {
                    //架构不存在这个这个属性。
                }
            }

            return tableName;
        }

        private static string GetColumnName(PropertyInfo propertyInfo)
        {
            string columnName = Encapsulate(propertyInfo.Name);

            var columnattr =
                propertyInfo.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == "ColumnAttribute")
                    as dynamic;
            if (columnattr != null)
            {
                columnName = Encapsulate(columnattr.Name);
                Trace.WriteLine(String.Format("Column name for type overridden from {0} to {1}", propertyInfo.Name,
                    columnName));
            }
            return columnName;
        }

        private static string Encapsulate(string databaseword)
        {
            return string.Format(_encapsulation, databaseword);
        }

        /// <summary>
        ///    生成基于所述当前日期/时间的guid
        /// </summary>
        /// <returns></returns>
        public static Guid SequentialGuid()
        {
            Guid tempGuid = Guid.NewGuid();
            byte[] bytes = tempGuid.ToByteArray();
            DateTime time = DateTime.Now;
            bytes[3] = (byte)time.Year;
            bytes[2] = (byte)time.Month;
            bytes[1] = (byte)time.Day;
            bytes[0] = (byte)time.Hour;
            bytes[5] = (byte)time.Minute;
            bytes[4] = (byte)time.Second;
            return new Guid(bytes);
        }
    }
}
