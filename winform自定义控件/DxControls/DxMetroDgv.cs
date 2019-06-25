using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DxControls
{
    public partial class DxMetroDgv : UserControl
    {
        bool Init = false;
        public DxMetroDgv()
        {
            InitializeComponent();
            tscRows.SelectedIndex = 0;
            Init = true;
        }

        private bool _showAddBtn=true;

        public bool ShowAddBtn
        {
            get { return _showAddBtn; }
            set
            {
                _showAddBtn = value;
                toolStripSeparator1.Visible = _showAddBtn;
                tsbAdd.Visible = _showAddBtn;
            }
        }
        private bool _showUpdate=true;

        public bool ShowUpdate
        {
            get { return _showUpdate; }
            set
            {
                _showUpdate = value;
                toolStripSeparator2.Visible = _showUpdate;
                tsbUpdate.Visible = _showUpdate;
            }
        }

        private bool _showDelete=true;

        public bool ShowDelete
        {
            get { return _showDelete; }
            set { _showDelete = value;
                toolStripSeparator3.Visible = _showDelete;
                tsbDelete.Visible = _showDelete;
            }
        }
        private bool _showSchedule=true;

        public bool ShowSchedule
        {
            get { return _showSchedule; }
            set
            {
                _showSchedule = value;
                tsSchedule.Visible = _showSchedule;
            }
        }



        public DataGridView DxDgv => dgv;
        public FlowLayoutPanel Conditions => flpConditions;

        public int PageIndex { get; set; } = 1;
        public int PageCount { get; set; } = 1;
        public int PageRows => tscRows.Text.ObjToInt();

        private int _totalCount;
        public int TotalCount
        {
            get { return  _totalCount; }
            set
            {
                _totalCount = value;
                PageCount = _totalCount / PageRows + (_totalCount % PageRows == 0 ? 0 : 1);
            }
        }
        public ToolStripLabel TotalCountText => tslTotalCount;

        private DataTable _dtSource;

        public DataTable DtSource
        {
            get { return _dtSource; }
            set
            {
                _dtSource = value;
                DxDgv.DataSource = null;
                DxDgv.DataSource = _dtSource;
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font, rectangle, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        private List<Control> _flpControls;

        public List<Control> FlpControls
        {
            get { return _flpControls; }
            set
            {
                _flpControls = value;
                if (value != null)
                {
                    flpConditions.Controls.Clear();
                    flpConditions.Controls.AddRange(value.ToArray());
                }
            }
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            foreach (var n in flpConditions.Controls.Cast<Control>().Where(w => w is IBaseControl))
            {
                (n as IBaseControl).ClearValue();
            }
        }

        public string GetSql() => string.Join("", flpConditions.Controls.Cast<Control>().Where(w => w is IBaseControl).Where(w => (w as IBaseControl).NeedThis == true).Select(s => (s as IBaseControl).SqlResult));


        public delegate void FreshDataHandler(object sender, EventArgs e);
        public event FreshDataHandler FreshData;
        private void tscRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Init)
            {
                PageIndex = 1;
                FreshData?.Invoke(sender, e);
            }
        }
        private void tsbFind_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            FreshData?.Invoke(sender, e);
        }
        private void txbFirst_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            FreshData?.Invoke(sender, e);
        }
        private void txbPrevious_Click(object sender, EventArgs e)
        {
            if (PageIndex > 1)
            {
                PageIndex--;
                FreshData?.Invoke(sender, e);
            }
            else
                MessageBox.Show("已检索至第一页");
        }
        private void txbNext_Click(object sender, EventArgs e)
        {
            if (PageCount - PageIndex > 0)
            {
                PageIndex++;
                FreshData?.Invoke(sender, e);
            }
            else
                MessageBox.Show("已检索至最后一页");
        }
        private void tsbLast_Click(object sender, EventArgs e)
        {
            PageIndex = PageCount;
            FreshData?.Invoke(sender, e);
        }
        private void tsbJump_Click(object sender, EventArgs e)
        {
            var jumppage = tstxtPageNum.Text.ObjToInt();
            if (jumppage >= 1 && jumppage <= PageCount)
            {
                PageIndex = jumppage;
                FreshData?.Invoke(sender, e);
            }
        }

        public delegate void ExportDataHandler(object sender, EventArgs e);
        public event ExportDataHandler ExportData;
        private void tsbExport_Click(object sender, EventArgs e) => ExportData?.Invoke(sender, e);


        public delegate void AddDataHandler(object sender, EventArgs e);
        public event AddDataHandler AddData;
        private void tsbAdd_Click(object sender, EventArgs e) => AddData?.Invoke(sender, e);

        public delegate void UpdateDataHandler(object sender, EventArgs e);
        public event UpdateDataHandler UpdateData;
        private void tsbUpdate_Click(object sender, EventArgs e) => UpdateData?.Invoke(sender, e);


        public delegate void DeleteDataHandler(object sender, EventArgs e);
        public event DeleteDataHandler DeleteData;
        private void tsbDelete_Click(object sender, EventArgs e) => DeleteData?.Invoke(sender, e);
    }
}
