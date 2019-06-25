using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    ///    可选表属性
    ///    您可以使用System.ComponentModel.DataAnnotations版本在它的地方指定POCO的表名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        ///  可选表属性
        /// </summary>
        /// <param name="tableName"></param>
        public TableAttribute(string tableName)
        {
            Name = tableName;
        }

        /// <summary>
        ///  该表的名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     该模式的名字
        /// </summary>
        public string Schema { get; set; }
    }

    /// <summary>
    ///    可选列属性
    ///    您可以使用System.ComponentModel.DataAnnotations版本在它的地方指定POCO的表名
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        ///  可选列属性
        /// </summary>
        /// <param name="columnName"></param>
        public ColumnAttribute(string columnName)
        {
            Name = columnName;
        }

        /// <summary>
        ///    列名
        /// </summary>
        public string Name { get; private set; }
    }

    /// <summary>
    ///   可选的键属性
    ///    您可以使用System.ComponentModel.DataAnnotations版本在它的地方指定POCO的主键
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : Attribute
    {
    }

    /// <summary>
    ///    可选的键属性
    ///    您可以使用System.ComponentModel.DataAnnotations版本在它的地方指定POCO的必需的属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute
    {
    }

    /// <summary>
    ///     可选的可编辑属性
    ///     您可以使用System.ComponentModel.DataAnnotations版本在它的地方，以指定的属性编辑
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EditableAttribute : Attribute
    {
        /// <summary>
        /// 可选的可编辑属性
        /// </summary>
        /// <param name="iseditable"></param>
        public EditableAttribute(bool iseditable)
        {
            AllowEdit = iseditable;
        }

        /// <summary>
        ///   这属性是否持久化到数据库
        /// </summary>
        public bool AllowEdit { get; private set; }
    }

    /// <summary>
    ///    可选的只读属性
    ///     您可以使用System.ComponentModel版本在它的地方，以指定可编辑的属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ReadOnlyAttribute : Attribute
    {
        /// <summary>
        ///   可选的只读属性
        /// </summary>
        /// <param name="isReadOnly"></param>
        public ReadOnlyAttribute(bool isReadOnly)
        {
            IsReadOnly = isReadOnly;
        }

        /// <summary>
        ///    这属性是否持久化到数据库
        /// </summary>
        public bool IsReadOnly { get; private set; }
    }

    /// <summary>
    ///     可选的忽略选择属性
    ///    自定义的Dapper.SimpleCRUD排除在选择方法的属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreSelectAttribute : Attribute
    {
    }

    /// <summary>
    ///     可选的忽略插入属性
    ///     自定义的Dapper.SimpleCRUD排除从插入方法属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreInsertAttribute : Attribute
    {
    }

    /// <summary>
    ///     可选的忽略更新属性
    ///     自定义的Dapper.SimpleCRUD排除来自更新方法属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreUpdateAttribute : Attribute
    {
    }
}
