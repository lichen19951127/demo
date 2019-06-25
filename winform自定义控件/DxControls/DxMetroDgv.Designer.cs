namespace DxControls
{
    partial class DxMetroDgv
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DxMetroDgv));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flpConditions = new System.Windows.Forms.FlowLayoutPanel();
            this.tsOperation = new System.Windows.Forms.ToolStrip();
            this.tsbFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tsSchedule = new System.Windows.Forms.ToolStrip();
            this.tslTotalCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tscRows = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txbFirst = new System.Windows.Forms.ToolStripButton();
            this.txbPrevious = new System.Windows.Forms.ToolStripButton();
            this.txbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.tsbJump = new System.Windows.Forms.ToolStripButton();
            this.tstxtPageNum = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tsOperation.SuspendLayout();
            this.tsSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // flpConditions
            // 
            this.flpConditions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpConditions.Location = new System.Drawing.Point(0, 0);
            this.flpConditions.Name = "flpConditions";
            this.flpConditions.Size = new System.Drawing.Size(1037, 119);
            this.flpConditions.TabIndex = 0;
            // 
            // tsOperation
            // 
            this.tsOperation.BackColor = System.Drawing.Color.Transparent;
            this.tsOperation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFind,
            this.toolStripButton2,
            this.tsbReset,
            this.toolStripSeparator1,
            this.tsbAdd,
            this.toolStripSeparator2,
            this.tsbUpdate,
            this.toolStripSeparator3,
            this.tsbDelete,
            this.toolStripSeparator5,
            this.tsbExport});
            this.tsOperation.Location = new System.Drawing.Point(0, 119);
            this.tsOperation.Name = "tsOperation";
            this.tsOperation.Size = new System.Drawing.Size(1037, 25);
            this.tsOperation.TabIndex = 1;
            this.tsOperation.Text = "toolStrip1";
            // 
            // tsbFind
            // 
            this.tsbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFind.Image = ((System.Drawing.Image)(resources.GetObject("tsbFind.Image")));
            this.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(36, 22);
            this.tsbFind.Text = "查询";
            this.tsbFind.Click += new System.EventHandler(this.tsbFind_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbReset
            // 
            this.tsbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(36, 22);
            this.tsbReset.Text = "重置";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(36, 22);
            this.tsbAdd.Text = "添加";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdate.Image")));
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(36, 22);
            this.tsbUpdate.Text = "修改";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(36, 22);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExport
            // 
            this.tsbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(36, 22);
            this.tsbExport.Text = "导出";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // tsSchedule
            // 
            this.tsSchedule.BackColor = System.Drawing.Color.Transparent;
            this.tsSchedule.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsSchedule.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTotalCount,
            this.toolStripLabel2,
            this.tscRows,
            this.toolStripLabel3,
            this.toolStripSeparator4,
            this.txbFirst,
            this.txbPrevious,
            this.txbNext,
            this.tsbLast,
            this.tsbJump,
            this.tstxtPageNum,
            this.toolStripLabel1});
            this.tsSchedule.Location = new System.Drawing.Point(0, 680);
            this.tsSchedule.Name = "tsSchedule";
            this.tsSchedule.Size = new System.Drawing.Size(1037, 25);
            this.tsSchedule.TabIndex = 3;
            this.tsSchedule.Text = "toolStrip2";
            // 
            // tslTotalCount
            // 
            this.tslTotalCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslTotalCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslTotalCount.Name = "tslTotalCount";
            this.tslTotalCount.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "每页显示";
            // 
            // tscRows
            // 
            this.tscRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscRows.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscRows.Items.AddRange(new object[] {
            "50",
            "100"});
            this.tscRows.Name = "tscRows";
            this.tscRows.Size = new System.Drawing.Size(75, 25);
            this.tscRows.SelectedIndexChanged += new System.EventHandler(this.tscRows_SelectedIndexChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel3.Text = "行";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // txbFirst
            // 
            this.txbFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txbFirst.Image = ((System.Drawing.Image)(resources.GetObject("txbFirst.Image")));
            this.txbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txbFirst.Name = "txbFirst";
            this.txbFirst.Size = new System.Drawing.Size(36, 22);
            this.txbFirst.Text = "首页";
            this.txbFirst.Click += new System.EventHandler(this.txbFirst_Click);
            // 
            // txbPrevious
            // 
            this.txbPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txbPrevious.Image = ((System.Drawing.Image)(resources.GetObject("txbPrevious.Image")));
            this.txbPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txbPrevious.Name = "txbPrevious";
            this.txbPrevious.Size = new System.Drawing.Size(48, 22);
            this.txbPrevious.Text = "上一页";
            this.txbPrevious.Click += new System.EventHandler(this.txbPrevious_Click);
            // 
            // txbNext
            // 
            this.txbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txbNext.Image = ((System.Drawing.Image)(resources.GetObject("txbNext.Image")));
            this.txbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txbNext.Name = "txbNext";
            this.txbNext.Size = new System.Drawing.Size(48, 22);
            this.txbNext.Text = "下一页";
            this.txbNext.Click += new System.EventHandler(this.txbNext_Click);
            // 
            // tsbLast
            // 
            this.tsbLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(36, 22);
            this.tsbLast.Text = "尾页";
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // tsbJump
            // 
            this.tsbJump.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbJump.Image = ((System.Drawing.Image)(resources.GetObject("tsbJump.Image")));
            this.tsbJump.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJump.Name = "tsbJump";
            this.tsbJump.Size = new System.Drawing.Size(48, 22);
            this.tsbJump.Text = "跳转至";
            this.tsbJump.Click += new System.EventHandler(this.tsbJump_Click);
            // 
            // tstxtPageNum
            // 
            this.tstxtPageNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstxtPageNum.Name = "tstxtPageNum";
            this.tstxtPageNum.Size = new System.Drawing.Size(30, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel1.Text = "页";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.MediumTurquoise;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle33;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 144);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1037, 536);
            this.dgv.TabIndex = 4;
            this.dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // DxMetroDgv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tsSchedule);
            this.Controls.Add(this.tsOperation);
            this.Controls.Add(this.flpConditions);
            this.Name = "DxMetroDgv";
            this.Size = new System.Drawing.Size(1037, 705);
            this.tsOperation.ResumeLayout(false);
            this.tsOperation.PerformLayout();
            this.tsSchedule.ResumeLayout(false);
            this.tsSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpConditions;
        private System.Windows.Forms.ToolStrip tsOperation;
        private System.Windows.Forms.ToolStrip tsSchedule;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripButton tsbFind;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripLabel tslTotalCount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox tscRows;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton txbFirst;
        private System.Windows.Forms.ToolStripButton txbPrevious;
        private System.Windows.Forms.ToolStripButton txbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripButton tsbJump;
        private System.Windows.Forms.ToolStripTextBox tstxtPageNum;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbExport;
    }
}
