namespace DxControls
{
    partial class DxMetroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dxMetroDgv1 = new DxControls.DxMetroDgv();
            this.SuspendLayout();
            // 
            // dxMetroDgv1
            // 
            this.dxMetroDgv1.BackColor = System.Drawing.Color.White;
            this.dxMetroDgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxMetroDgv1.DtSource = null;
            this.dxMetroDgv1.FlpControls = null;
            this.dxMetroDgv1.Location = new System.Drawing.Point(20, 60);
            this.dxMetroDgv1.Name = "dxMetroDgv1";
            this.dxMetroDgv1.PageCount = 0;
            this.dxMetroDgv1.PageIndex = 1;
            this.dxMetroDgv1.ShowAddBtn = true;
            this.dxMetroDgv1.ShowDelete = true;
            this.dxMetroDgv1.ShowSchedule = true;
            this.dxMetroDgv1.ShowUpdate = true;
            this.dxMetroDgv1.Size = new System.Drawing.Size(933, 563);
            this.dxMetroDgv1.TabIndex = 0;
            this.dxMetroDgv1.TotalCount = 0;
            this.dxMetroDgv1.FreshData += new DxControls.DxMetroDgv.FreshDataHandler(this.dxMetroDgv1_FreshData);
            this.dxMetroDgv1.ExportData += new DxControls.DxMetroDgv.ExportDataHandler(this.dxMetroDgv1_ExportData);
            this.dxMetroDgv1.AddData += new DxControls.DxMetroDgv.AddDataHandler(this.dxMetroDgv1_AddData);
            this.dxMetroDgv1.UpdateData += new DxControls.DxMetroDgv.UpdateDataHandler(this.dxMetroDgv1_UpdateData);
            this.dxMetroDgv1.DeleteData += new DxControls.DxMetroDgv.DeleteDataHandler(this.dxMetroDgv1_DeleteData);
            // 
            // DxMetroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 643);
            this.Controls.Add(this.dxMetroDgv1);
            this.Name = "DxMetroForm";
            this.Text = "DxMetroForm";
            this.Load += new System.EventHandler(this.DxMetroForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DxMetroDgv dxMetroDgv1;
    }
}