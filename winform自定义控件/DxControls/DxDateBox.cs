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
using PopupTool;

namespace DxControls
{
    public partial class DxDateBox : UserControl,IBaseControl
    {
        public DxDateBox()
        {
            InitializeComponent();
            MTextBox.ReadOnly = true;
            Size = new Size(220, 38);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                metroLabel1.Text = $"{_title}↓：";
                MTextBox.Location = new Point(metroLabel1.Width + 5, metroLabel1.Location.Y-2);
                MTextBox.Width = this.Width - metroLabel1.Width - 12;
            }
        }
        private string _txtValue;

        public string TxtValue
        {
            get => string.IsNullOrEmpty(MTextBox.Text) ? "" : MTextBox.Text.Replace('，', ',');
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
        public bool NeedPopup { get; set; } = true;

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
                            result = ShowTimeBox?SqlCreator.RangeTimeSql(ColumnName.First(), ">", TxtValue): SqlCreator.RangeDtSql(ColumnName.First(), ">", TxtValue);
                            break;
                        case ResultType.MoreEqualsThan:
                            result = ShowTimeBox ? SqlCreator.RangeTimeSql(ColumnName.First(), ">=", TxtValue) : SqlCreator.RangeDtSql(ColumnName.First(), ">=", TxtValue);
                            break;
                        case ResultType.LessThan:
                            result = ShowTimeBox ? SqlCreator.RangeTimeSql(ColumnName.First(), "<", TxtValue) : SqlCreator.RangeDtSql(ColumnName.First(), "<", TxtValue);
                            break;
                        case ResultType.LessEqualsThan:
                            result = ShowTimeBox ? SqlCreator.RangeTimeSql(ColumnName.First(), "<=", TxtValue) : SqlCreator.RangeDtSql(ColumnName.First(), "<=", TxtValue);
                            break;
                        default:
                            result = ShowTimeBox ? SqlCreator.RangeTimeSql(ColumnName.First(), "=", TxtValue) : SqlCreator.RangeDtSql(ColumnName.First(), "=", TxtValue);
                            break;
                    }
                }
                return result;
            }
        }
        DxCalendarBox mc;
        public bool ShowTimeBox { get; set; } = false;
        public bool ShowClear { get; set; } = true;
        private void metroLabel1_Click(object sender, EventArgs e)
        {
            if (NeedPopup)
            {
                mc = new DxCalendarBox();
                mc.ShowTimeBox = ShowTimeBox;
                mc.ShowClearButton = ShowClear;
                mc.CalendarBox.DateSelected += mc_DateSelected;
                if (ShowClear) mc.ClearClick += Mc_ClearClick;
                if (ShowTimeBox) mc.TimeBox.ValueChanged += TimeBox_ValueChanged;
                Popup pp = new Popup(mc);
                pp.BackColor = Color.Transparent;
                mc.Dock = DockStyle.Fill;
                pp.Show(this);
            }
        }

        private void Mc_ClearClick(object sender, EventArgs e) => MTextBox.Clear();

        public TimeType TTyped { get; set; }
        public DateType DType { get; set; }
        void SetTxtValue()
        {
            var date = "";
            var time = "";
            switch (DType)
            {
                case DateType.H_Line2:
                    date = mc.CalendarBox.SelectionStart.ToString("yyyy-M-d");
                    break;
                case DateType.Zh_Cn1:
                    date = mc.CalendarBox.SelectionStart.ToString("yyyy年MM月dd日");
                    break;
                case DateType.Zh_Cn2:
                    date = mc.CalendarBox.SelectionStart.ToString("yyyy年M月d日");
                    break;
                case DateType.Slash1:
                    date = mc.CalendarBox.SelectionStart.ToString("yyyy/MM/dd");
                    break;
                case DateType.Slash2:
                    date = mc.CalendarBox.SelectionStart.ToString("yyyy/M/d");
                    break;
                default:
                    date = mc.CalendarBox.SelectionStart.ToString("yyyy-MM-dd");
                    break;
            }
            if (ShowTimeBox)
            {
                time = mc.TimeBox.Value.ToString(" HH:mm:ss");
            }
            else
            {
                switch (TTyped)
                {
                    case TimeType.Start:
                        time = " 00:00:00";
                        break;
                    case TimeType.End:
                        time = " 23:59:59";
                        break;
                    default:
                        break;
                }
            }
            MTextBox.Text = date + time;
        }
        private void TimeBox_ValueChanged(object sender, EventArgs e)
        {
            SetTxtValue();
        }

        private void mc_DateSelected(object sender, DateRangeEventArgs e)
        {
            SetTxtValue();
        }
        public enum TimeType
        {
            /// <summary>
            /// 空
            /// </summary>
            None,
            /// <summary>
            /// 00:00:00
            /// </summary>
            Start,
            /// <summary>
            /// 23:59:59
            /// </summary>
            End
        }
        public enum DateType
        {
            /// <summary>
            /// yyyy-MM-dd
            /// </summary>
            H_Line1,
            /// <summary>
            /// yyyy-M-d
            /// </summary>
            H_Line2,
            /// <summary>
            /// yyyy年MM月dd日
            /// </summary>
            Zh_Cn1,
            /// <summary>
            /// yyyy年M月d日
            /// </summary>
            Zh_Cn2,
            /// <summary>
            /// yyyy/mm/dd
            /// </summary>
            Slash1,
            /// <summary>
            /// yyyy/m/d
            /// </summary>
            Slash2,
        }
    }
}
