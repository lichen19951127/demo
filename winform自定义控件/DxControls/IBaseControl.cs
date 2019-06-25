using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxControls
{
    public interface IBaseControl
    {
        string Title { get; set; }
        string TxtValue { get; set; }
        string SqlResult { get; }
        bool NeedThis { get; set; }
        string[] ColumnName { get; set; }
        MetroTextBox MTextBox { get; }
        void ClearValue();
        ResultType RType { get; set; }
    }
    public enum ResultType
    {
        Equals,
        Like,
        MoreThan,
        MoreEqualsThan,
        LessThan,
        LessEqualsThan
    }
}
