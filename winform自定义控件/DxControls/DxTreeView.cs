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
    public partial class DxTreeView : UserControl,IBaseControl
    {
        public DxTreeView()
        {
            InitializeComponent();
            CbSource = new List<string>();
            Size = new Size(220, 38);
        }
        TreeView tv;

        public bool CheckedSwitch { get; set; } = true;

        public List<string> CbSource { get; set; }

        public bool NeedPopup { get; set; } = true;
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
                        default:
                            result = SqlCreator.InSql(ColumnName, TxtValue);
                            break;
                    }
                }
                return result;
            }
        }
        private void metroLabel1_Click(object sender, EventArgs e)
        {
            if (NeedPopup)
            {
                tv = new TreeView();
                tv.CheckBoxes = CheckedSwitch;
                if (CbSource != null)
                {
                    tv.Nodes.Clear();
                    CbSource.ForEach(n => tv.Nodes.Add(n, n));
                    if (CheckedSwitch)
                    {
                        tv.AfterCheck += tv_AfterCheck;
                        tv.NodeMouseDoubleClick += tv_NodeMouseDoubleClick;
                    }
                    else
                    {
                        tv.NodeMouseClick += tv_NodeMouseClick;
                    }
                    if (!string.IsNullOrEmpty(TxtValue))
                    {
                        var s = TxtValue.Split(',');
                        s.ToList().ForEach(n =>
                        {
                            if (tv.Nodes.Find(n, true).Count() > 0)
                                tv.Nodes.Find(n, true)[0].Checked = true;
                        });
                    }
                }
                Popup pp = new Popup(tv);
                pp.Size = new Size(220, 180);
                pp.BackColor = System.Drawing.Color.Transparent;
                tv.Dock = DockStyle.Fill;
                pp.Show(this);
            }
        }

        private void tv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.Checked = !e.Node.Checked;            
        }

        private void tv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            MTextBox.Text = string.Join(",", tv.Nodes.Cast<TreeNode>().Where(w => w.Checked).Select(s => s.Text));
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MTextBox.Text = tv.Nodes.Cast<TreeNode>().FirstOrDefault(f=>f.IsSelected).Text;
        }
    }
}
