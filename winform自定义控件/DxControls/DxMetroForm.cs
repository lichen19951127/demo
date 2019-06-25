using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DxControls.DxAddOrUpdate;

namespace DxControls
{
    public partial class DxMetroForm : Form
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Text = Title;
            }
        }
        public DataRow CurrentRow => (dxMetroDgv1.DxDgv.DataSource as DataTable).AsEnumerable().FirstOrDefault(w=>w.Field<object>("系统编号").ToString()== dxMetroDgv1.DxDgv.SelectedRows[0].Cells[0].Value.ToString());
        public DxMetroDgv DmDgv => dxMetroDgv1;
        public string TableName { get; set; }
        public DxMetroForm()
        {
            InitializeComponent();
        }
        public string DeleteSql => $"delete from {TableName} where id='{CurrentRow["系统编号"].ToString()}'";
        private async void DxMetroForm_Load(object sender, EventArgs e)
        {
            dxMetroDgv1.FlpControls = SetConditionControls();
            var result = await GSDatas(dxMetroDgv1.PageIndex);
            if (!string.IsNullOrEmpty(result)) MessageBox.Show(result);
        }
        public virtual List<Control> SetConditionControls()
        {
            return new List<Control>();
        }
        public void FreshPageData() => dxMetroDgv1_FreshData(null, null);
        private async void dxMetroDgv1_FreshData(object sender, EventArgs e)
        {
            var result = await GSDatas(dxMetroDgv1.PageIndex);
            if (!string.IsNullOrEmpty(result)) MessageBox.Show(result);
        }
        public virtual Task<string> GSDatas(int page = 0)
        {
            return Task.Run(() => "");
        }

        private void dxMetroDgv1_AddData(object sender, EventArgs e)
        {
            AddOperate();
        }
        public virtual void AddOperate()
        {
            Muc = new DxAddOrUpdate();
            Muc.TableName = TableName;
            Muc.FatherForm = this;
            Muc.Operate = OperateType.Add;
            Muc.FlpControls = SetChangeControls();
            Muc.Submit += Muc_Submit;
            Muc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(Muc);
            Muc.Dock = DockStyle.Fill;
            Muc.BringToFront();
            Muc.Show();
        }

        public virtual List<Control> SetChangeControls()
        {
            return new List<Control>();
        }
        private async void dxMetroDgv1_ExportData(object sender, EventArgs e)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXCEL文件";
            kk.Filter = "excel文件(*.xlsx) |*.xlsx";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                if(await ConditionExport(kk.FileName))
                {
                    MessageBox.Show("导出成功");
                }
                else
                {
                    MessageBox.Show("导出失败");
                }
            }
        }
        public virtual Task<bool> ConditionExport(string filename)
        {
            return Task.Run(() => false);
        }
        private void dxMetroDgv1_UpdateData(object sender, EventArgs e)
        {
            UpdateOperate();
        }
        public virtual void UpdateOperate()
        {
            Muc = new DxAddOrUpdate();
            Muc.TableName = TableName;
            Muc.FatherForm = this;
            Muc.Operate = OperateType.Update;
            Muc.FlpControls = SetChangeControls();
            Muc.Submit += Muc_Submit;
            Muc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(Muc);
            Muc.Dock = DockStyle.Fill;
            Muc.BringToFront();
            Muc.Show();
        }

        public DxAddOrUpdate Muc;
        public delegate void SubmitHandler(object sender, EventArgs e);
        public event SubmitHandler Submit;
        private void Muc_Submit(object sender, EventArgs e)
        {
            Submit?.Invoke(sender, e);
        }
        public delegate void DeleteDataHandler(object sender, EventArgs e);
        public event DeleteDataHandler DeleteData;
        private void dxMetroDgv1_DeleteData(object sender, EventArgs e)
        {
            DeleteData?.Invoke(sender, e);
        }

       
    }
}
