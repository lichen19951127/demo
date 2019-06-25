namespace QRCode
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.pageEncode = new System.Windows.Forms.TabPage();
            this.tlpEncode = new System.Windows.Forms.TableLayoutPanel();
            this.lbData = new System.Windows.Forms.Label();
            this.lbEncode = new System.Windows.Forms.Label();
            this.lbLevel = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            this.lbSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pageDecode = new System.Windows.Forms.TabPage();
            this.tlpDecode = new System.Windows.Forms.TableLayoutPanel();
            this.picDecode = new System.Windows.Forms.PictureBox();
            this.lb = new System.Windows.Forms.Label();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.picEncode = new System.Windows.Forms.PictureBox();
            this.TabControl.SuspendLayout();
            this.pageEncode.SuspendLayout();
            this.tlpEncode.SuspendLayout();
            this.pageDecode.SuspendLayout();
            this.tlpDecode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEncode)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.pageEncode);
            this.TabControl.Controls.Add(this.pageDecode);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(584, 462);
            this.TabControl.TabIndex = 1;
            // 
            // pageEncode
            // 
            this.pageEncode.Controls.Add(this.tlpEncode);
            this.pageEncode.Location = new System.Drawing.Point(4, 22);
            this.pageEncode.Name = "pageEncode";
            this.pageEncode.Padding = new System.Windows.Forms.Padding(3);
            this.pageEncode.Size = new System.Drawing.Size(576, 436);
            this.pageEncode.TabIndex = 0;
            this.pageEncode.Text = "Encode";
            this.pageEncode.UseVisualStyleBackColor = true;
            // 
            // tlpEncode
            // 
            this.tlpEncode.ColumnCount = 3;
            this.tlpEncode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpEncode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpEncode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpEncode.Controls.Add(this.lbData, 0, 1);
            this.tlpEncode.Controls.Add(this.lbEncode, 0, 2);
            this.tlpEncode.Controls.Add(this.lbLevel, 0, 3);
            this.tlpEncode.Controls.Add(this.lbVersion, 0, 4);
            this.tlpEncode.Controls.Add(this.txtData, 1, 1);
            this.tlpEncode.Controls.Add(this.cmbEncoding, 1, 2);
            this.tlpEncode.Controls.Add(this.cmbLevel, 1, 3);
            this.tlpEncode.Controls.Add(this.cmbVersion, 1, 4);
            this.tlpEncode.Controls.Add(this.lbSize, 0, 5);
            this.tlpEncode.Controls.Add(this.txtSize, 1, 5);
            this.tlpEncode.Controls.Add(this.btnEncode, 0, 6);
            this.tlpEncode.Controls.Add(this.btnSave, 1, 6);
            this.tlpEncode.Controls.Add(this.btnPrint, 2, 6);
            this.tlpEncode.Controls.Add(this.picEncode, 0, 0);
            this.tlpEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEncode.Location = new System.Drawing.Point(3, 3);
            this.tlpEncode.Name = "tlpEncode";
            this.tlpEncode.RowCount = 7;
            this.tlpEncode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpEncode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpEncode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpEncode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpEncode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpEncode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpEncode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpEncode.Size = new System.Drawing.Size(570, 430);
            this.tlpEncode.TabIndex = 0;
            // 
            // lbData
            // 
            this.lbData.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(133, 258);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(35, 12);
            this.lbData.TabIndex = 0;
            this.lbData.Text = "Data:";
            // 
            // lbEncode
            // 
            this.lbEncode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEncode.AutoSize = true;
            this.lbEncode.Location = new System.Drawing.Point(109, 288);
            this.lbEncode.Name = "lbEncode";
            this.lbEncode.Size = new System.Drawing.Size(59, 12);
            this.lbEncode.TabIndex = 1;
            this.lbEncode.Text = "Encoding:";
            // 
            // lbLevel
            // 
            this.lbLevel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbLevel.AutoSize = true;
            this.lbLevel.Location = new System.Drawing.Point(67, 318);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(101, 12);
            this.lbLevel.TabIndex = 2;
            this.lbLevel.Text = "Correction Level";
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(115, 348);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(53, 12);
            this.lbVersion.TabIndex = 3;
            this.lbVersion.Text = "Version:";
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(174, 253);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(222, 21);
            this.txtData.TabIndex = 4;
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(174, 284);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(222, 20);
            this.cmbEncoding.TabIndex = 5;
            // 
            // cmbLevel
            // 
            this.cmbLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new System.Drawing.Point(174, 314);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(222, 20);
            this.cmbLevel.TabIndex = 6;
            // 
            // cmbVersion
            // 
            this.cmbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(174, 344);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(222, 20);
            this.cmbVersion.TabIndex = 7;
            // 
            // lbSize
            // 
            this.lbSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(133, 378);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(35, 12);
            this.lbSize.TabIndex = 8;
            this.lbSize.Text = "Size:";
            // 
            // txtSize
            // 
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSize.Location = new System.Drawing.Point(174, 373);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(222, 21);
            this.txtSize.TabIndex = 9;
            // 
            // btnEncode
            // 
            this.btnEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEncode.Location = new System.Drawing.Point(3, 402);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(165, 25);
            this.btnEncode.TabIndex = 10;
            this.btnEncode.Text = "Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(174, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(222, 25);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrint.Location = new System.Drawing.Point(402, 402);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(165, 25);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pageDecode
            // 
            this.pageDecode.Controls.Add(this.tlpDecode);
            this.pageDecode.Location = new System.Drawing.Point(4, 22);
            this.pageDecode.Name = "pageDecode";
            this.pageDecode.Padding = new System.Windows.Forms.Padding(3);
            this.pageDecode.Size = new System.Drawing.Size(576, 436);
            this.pageDecode.TabIndex = 1;
            this.pageDecode.Text = "Decode";
            this.pageDecode.UseVisualStyleBackColor = true;
            // 
            // tlpDecode
            // 
            this.tlpDecode.ColumnCount = 4;
            this.tlpDecode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDecode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDecode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDecode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDecode.Controls.Add(this.picDecode, 0, 0);
            this.tlpDecode.Controls.Add(this.lb, 0, 1);
            this.tlpDecode.Controls.Add(this.txtShow, 1, 1);
            this.tlpDecode.Controls.Add(this.btnOpen, 1, 2);
            this.tlpDecode.Controls.Add(this.btnDecode, 2, 2);
            this.tlpDecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDecode.Location = new System.Drawing.Point(3, 3);
            this.tlpDecode.Name = "tlpDecode";
            this.tlpDecode.RowCount = 3;
            this.tlpDecode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpDecode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpDecode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpDecode.Size = new System.Drawing.Size(570, 430);
            this.tlpDecode.TabIndex = 0;
            // 
            // picDecode
            // 
            this.tlpDecode.SetColumnSpan(this.picDecode, 4);
            this.picDecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDecode.Location = new System.Drawing.Point(3, 3);
            this.picDecode.Name = "picDecode";
            this.picDecode.Size = new System.Drawing.Size(564, 295);
            this.picDecode.TabIndex = 0;
            this.picDecode.TabStop = false;
            // 
            // lb
            // 
            this.lb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(104, 327);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(35, 12);
            this.lb.TabIndex = 1;
            this.lb.Text = "Data:";
            // 
            // txtShow
            // 
            this.txtShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDecode.SetColumnSpan(this.txtShow, 3);
            this.txtShow.Location = new System.Drawing.Point(145, 322);
            this.txtShow.Name = "txtShow";
            this.txtShow.Size = new System.Drawing.Size(422, 21);
            this.txtShow.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpen.Location = new System.Drawing.Point(145, 368);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(136, 59);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDecode.Location = new System.Drawing.Point(287, 368);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(136, 59);
            this.btnDecode.TabIndex = 4;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // picEncode
            // 
            this.tlpEncode.SetColumnSpan(this.picEncode, 3);
            this.picEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picEncode.Location = new System.Drawing.Point(3, 3);
            this.picEncode.Name = "picEncode";
            this.picEncode.Size = new System.Drawing.Size(564, 243);
            this.picEncode.TabIndex = 13;
            this.picEncode.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.TabControl);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QR二维码";
            this.TabControl.ResumeLayout(false);
            this.pageEncode.ResumeLayout(false);
            this.tlpEncode.ResumeLayout(false);
            this.tlpEncode.PerformLayout();
            this.pageDecode.ResumeLayout(false);
            this.tlpDecode.ResumeLayout(false);
            this.tlpDecode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEncode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage pageEncode;
        private System.Windows.Forms.TableLayoutPanel tlpEncode;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.Label lbEncode;
        private System.Windows.Forms.Label lbLevel;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox picEncode;
        private System.Windows.Forms.TabPage pageDecode;
        private System.Windows.Forms.TableLayoutPanel tlpDecode;
        private System.Windows.Forms.PictureBox picDecode;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDecode;
    }
}

