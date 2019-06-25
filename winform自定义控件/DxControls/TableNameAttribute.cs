using System;

namespace DxControls
{
    public class TableNameAttribute : Attribute
    {
        public TableNameAttribute(string tableName) => TableName = tableName;
        public string TableName { get; set; }
    }
    public class ControlTypeAttribute : Attribute
    {
        public ControlTypeAttribute(ControlType controlType,bool noChange=false,string valueKey="")
        {
            ControlType = controlType;
            NoChange = noChange;
            ValueKey = valueKey;
        }
        public bool NoChange { get; set; }
        public ControlType ControlType { get; set; }
        public string ValueKey { get; set; }
    }
    public enum ControlType
    {
        Text,Id,Number,Date,DateTime,Single,Multiple,ReMarks
    }

}