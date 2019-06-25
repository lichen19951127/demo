using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxControls
{
    public partial class DxAddOrUpdate : UserControl
    {
        public DxAddOrUpdate()
        {
            InitializeComponent();
        }
        public string TableName { get; set; }
        public Form FatherForm { get; set; }
        private List<Control> _flpControls;
        public enum OperateType{Add,Update}
        public OperateType Operate { get; set; } = OperateType.Add;
        public List<Control> FlpControls
        {
            get => flowLayoutPanel2.Controls.Cast<Control>().ToList();
            set { _flpControls = value;
                flowLayoutPanel2.Controls.AddRange(_flpControls.ToArray());
            }
        }
        private bool _showSubmit = true;

        public bool ShowSumit
        {
            get { return _showSubmit; }
            set
            {
                _showSubmit = value;
                mbtnSubmit.Visible = _showSubmit;
            }
        }
        public string Sql => GetSql();
        public delegate void SubmitHandler(object sender, EventArgs e);
        public event SubmitHandler Submit;
        private void mbtnSubmit_Click(object sender, EventArgs e)
        {
            Submit?.Invoke(sender, e);
        }
        public bool NeedClose { get; set; } = true;
        private void mbtnCancel_Click(object sender, EventArgs e)
        {
            FatherForm.Controls.Remove(this);
        }
        string GetSql()
        {
            var cvs = FlpControls.Where(w => w is IBaseControl)
                   .Cast<IBaseControl>()
                   .Where(w => w.NeedThis = true)
                   .Select(s => new { column = string.Join(",", s.ColumnName), value = s.TxtValue });
            if (Operate == OperateType.Add)
            {
                var addcvs = cvs.Where(w => w.column.ToUpper() != "ID");
                return $"insert into {TableName}({string.Join(",", addcvs.Select(s => s.column))}) values('{string.Join("','", addcvs.Select(s => s.value))}')";
            }
            else
            {
                var id = cvs.First(f => f.column.ToUpper() == "ID").value;
                var updatecvs = cvs.Where(w => w.column.ToUpper() != "ID").Select(s => $"{s.column}='{s.value}'");
                return $"update {TableName} set {string.Join(",", updatecvs)} where id = '{id}'";
            }
        }
    }
}
