using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxControls
{
    public class SqlCreator
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="tableName">表名</param>
        /// <param name="whereString">查询条件</param>
        /// <returns></returns>
        public static string DropListSql(string columnName, string tableName, string whereString = "") => $"select {columnName} from {tableName} where 1=1 and {columnName} is not null {whereString} group by {columnName}";
        /// <summary>
        /// 指定页面数据
        /// </summary>
        /// <param name="middlesql">查询语句</param>
        /// <param name="start">开始行</param>
        /// <param name="end">结束航</param>
        /// <param name="middlesortsql">排序字段</param>
        /// <returns></returns>
        public static string PageSql(string middlesql, int start, int end, string middlesortsql = "")
        {
            var beforesql = "select * from(select a.*, rownum rn from(select * from";
            var endsql = $") a where rownum <= {end}) b where b.rn >= {start}";
            return $"{beforesql}{middlesql}{middlesortsql}{endsql}";
        }
        /// <summary>
        /// 总行数
        /// </summary>
        /// <param name="tablesql">查询语句</param>
        /// <returns></returns>
        public static string CountSql(string tablesql) => $"select count(*) from {tablesql}";
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public static string AllDataSql(string sql) => $"select * from {sql}";

        public static string InSql(string[] columnNames, IEnumerable<string> lst) => InSql(columnNames, string.Join(",", lst));

        public static string InSql(string columnName, IEnumerable<string> lst) => InSql(columnName, string.Join(",", lst));

        public static string InSql(string columnName, string value) => InSql(new string[] { columnName }, value);

        public static string InSql(string[] columnNames, string value) => string.IsNullOrEmpty(value) ? "" : $" and ({string.Join(" or ", columnNames.Select(s => $" {s} in ('{string.Join("','", value.Split(','))}') "))})";

        public static string LikeSql(string columnName, string value) => LikeSql(new string[] { columnName }, value);
        public static string LikeSql(string[] columnNames, string value)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(value))
            {
                sql = " and (";
                var v = value.Split(',');
                foreach (var n in v)
                {
                    sql += string.Join(" or ", columnNames.Select(s => $" {s} like '%{n}%' "));
                }
                sql += ")";
            }
            return sql;
        }

        public static string RangeDtSql(string columnname, string operate, string dt) => !string.IsNullOrEmpty(dt) ? $" and to_date(replace({columnname},' 0:00:00',''),'yyyy-mm-dd'){operate}to_date('{dt}','yyyy-mm-dd')" : "";
        public static string RangeDtSql(string columnname, string operate, DateTime? dt) => dt.HasValue ? $" and to_date(replace({columnname},' 0:00:00',''),'yyyy-mm-dd'){operate}to_date('{dt.Value.ToString("yyyy-MM-dd")}','yyyy-mm-dd')" : "";
        public static string RangeTimeSql(string columnname, string operate, string dt) => string.IsNullOrEmpty(dt) ? "":$" and to_date({columnname},'yyyy-mm-dd hh24:mi:ss'){operate}to_date('{dt}','yyyy-mm-dd hh24:mi:ss')";
        public static string RangeTimeSql(string columnname, string operate, DateTime? dt) => dt.HasValue ? $" and to_date({columnname},'yyyy-mm-dd hh24:mi:ss'){operate}to_date('{dt.Value.ToString("yyyy-MM-dd HH:mm:ss")}','yyyy-mm-dd hh24:mi:ss')" : "";
        public static string RangeNumSql(string columnName, string operate, string value) => $" and to_number({columnName}){operate}{value}";

    }
}
