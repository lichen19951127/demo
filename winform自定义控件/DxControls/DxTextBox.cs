using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace DxControls
{
    public partial class DxTextBox : UserControl,IBaseControl
    {
        public DxTextBox()
        {
            InitializeComponent();
            Size = new Size(220, 38);
        }
        public bool OnlyNum { get; set; } = false;

        
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                metroLabel1.Text = $"{_title}：";
                MTextBox.Location = new Point(metroLabel1.Width + 5, metroLabel1.Location.Y - 2);
                MTextBox.Width = this.Width - metroLabel1.Width - 12;
            }
        }
        private string _txtValue;

        public string TxtValue
        {
            get
            {
                if (OnlyNum&&!string.IsNullOrEmpty(MTextBox.Text))
                {
                    var result = 0m;
                    if (decimal.TryParse(MTextBox.Text, out result))
                        return MTextBox.Text;
                    else return "";
                }
                return string.IsNullOrEmpty(MTextBox.Text) ? "" : MTextBox.Text.Replace('，', ',');
            }
            set
            {
                _txtValue = value;
                MTextBox.Text = _txtValue;
            }
        }
        public string[] ColumnName { get; set; }

        public bool NeedThis { get; set; } = true;

        public MetroTextBox MTextBox => metroTextBox1;

        public ResultType RType { get; set; }

        public void ClearValue() => MTextBox.Clear();

        public string SqlResult
        {
            get
            {
                var result = "";
                if (NeedThis)
                {
                    switch (RType)
                    {
                        case ResultType.Like:
                            result = SqlCreator.LikeSql(ColumnName, TxtValue);
                            break;
                        case ResultType.MoreThan:
                            result = SqlCreator.RangeNumSql(ColumnName.First(), ">", TxtValue);
                            break;
                        case ResultType.MoreEqualsThan:
                            result = SqlCreator.RangeNumSql(ColumnName.First(), ">=", TxtValue);
                            break;
                        case ResultType.LessThan:
                            result = SqlCreator.RangeNumSql(ColumnName.First(), "<", TxtValue);
                            break;
                        case ResultType.LessEqualsThan:
                            result = SqlCreator.RangeNumSql(ColumnName.First(), "<=", TxtValue);
                            break;
                        default:
                            result = SqlCreator.InSql(ColumnName, TxtValue);
                            break;
                    }
                }
                return result;
            }
        }
    }
}
