namespace Lucky
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.btnset = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.btnresult = new System.Windows.Forms.Button();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo3 = new System.Windows.Forms.RadioButton();
            this.btnrestart = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.exitlabel = new System.Windows.Forms.Label();
            this.rdot = new System.Windows.Forms.RadioButton();
            this.TitleTimer = new System.Windows.Forms.Timer(this.components);
            this.Titlefrontsizetext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnset
            // 
            this.btnset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnset.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnset.Location = new System.Drawing.Point(545, 204);
            this.btnset.Name = "btnset";
            this.btnset.Size = new System.Drawing.Size(120, 48);
            this.btnset.TabIndex = 0;
            this.btnset.TabStop = false;
            this.btnset.Text = "抽奖设置";
            this.btnset.UseVisualStyleBackColor = true;
            this.btnset.Click += new System.EventHandler(this.btnset_Click);
            // 
            // btnstart
            // 
            this.btnstart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnstart.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnstart.ForeColor = System.Drawing.Color.Red;
            this.btnstart.Location = new System.Drawing.Point(279, 495);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(141, 37);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "开始抽奖";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnresult
            // 
            this.btnresult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnresult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnresult.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnresult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnresult.Location = new System.Drawing.Point(545, 150);
            this.btnresult.Name = "btnresult";
            this.btnresult.Size = new System.Drawing.Size(120, 48);
            this.btnresult.TabIndex = 0;
            this.btnresult.TabStop = false;
            this.btnresult.Text = "抽奖结果";
            this.btnresult.UseVisualStyleBackColor = true;
            this.btnresult.Click += new System.EventHandler(this.btnresult_Click);
            // 
            // rdo1
            // 
            this.rdo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdo1.AutoSize = true;
            this.rdo1.BackColor = System.Drawing.Color.Transparent;
            this.rdo1.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo1.ForeColor = System.Drawing.Color.Yellow;
            this.rdo1.Location = new System.Drawing.Point(12, 344);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(181, 33);
            this.rdo1.TabIndex = 1;
            this.rdo1.Text = "抽取一等奖";
            this.rdo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo1.UseVisualStyleBackColor = false;
            // 
            // rdo2
            // 
            this.rdo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdo2.AutoSize = true;
            this.rdo2.BackColor = System.Drawing.Color.Transparent;
            this.rdo2.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo2.ForeColor = System.Drawing.Color.Yellow;
            this.rdo2.Location = new System.Drawing.Point(12, 405);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(181, 33);
            this.rdo2.TabIndex = 1;
            this.rdo2.Text = "抽取二等奖";
            this.rdo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo2.UseVisualStyleBackColor = false;
            // 
            // rdo3
            // 
            this.rdo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdo3.AutoSize = true;
            this.rdo3.BackColor = System.Drawing.Color.Transparent;
            this.rdo3.Checked = true;
            this.rdo3.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo3.ForeColor = System.Drawing.Color.Yellow;
            this.rdo3.Location = new System.Drawing.Point(12, 459);
            this.rdo3.Name = "rdo3";
            this.rdo3.Size = new System.Drawing.Size(181, 33);
            this.rdo3.TabIndex = 1;
            this.rdo3.TabStop = true;
            this.rdo3.Text = "抽取三等奖";
            this.rdo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo3.UseVisualStyleBackColor = false;
            // 
            // btnrestart
            // 
            this.btnrestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnrestart.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnrestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnrestart.Location = new System.Drawing.Point(545, 258);
            this.btnrestart.Name = "btnrestart";
            this.btnrestart.Size = new System.Drawing.Size(120, 48);
            this.btnrestart.TabIndex = 0;
            this.btnrestart.TabStop = false;
            this.btnrestart.Text = "清空记录";
            this.btnrestart.UseVisualStyleBackColor = true;
            this.btnrestart.Click += new System.EventHandler(this.btnrestart_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("华文新魏", 71.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TitleLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TitleLabel.Location = new System.Drawing.Point(28, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(624, 98);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "杏坛艺拍抽奖";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // exitlabel
            // 
            this.exitlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitlabel.AutoSize = true;
            this.exitlabel.BackColor = System.Drawing.Color.Transparent;
            this.exitlabel.ForeColor = System.Drawing.Color.Red;
            this.exitlabel.Location = new System.Drawing.Point(10, 513);
            this.exitlabel.Name = "exitlabel";
            this.exitlabel.Size = new System.Drawing.Size(77, 12);
            this.exitlabel.TabIndex = 3;
            this.exitlabel.Text = "按Alt+F4退出";
            this.exitlabel.Click += new System.EventHandler(this.exitlabel_Click);
            // 
            // rdot
            // 
            this.rdot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdot.AutoSize = true;
            this.rdot.BackColor = System.Drawing.Color.Transparent;
            this.rdot.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdot.ForeColor = System.Drawing.Color.Yellow;
            this.rdot.Location = new System.Drawing.Point(12, 286);
            this.rdot.Name = "rdot";
            this.rdot.Size = new System.Drawing.Size(181, 33);
            this.rdot.TabIndex = 7;
            this.rdot.Text = "抽取特等奖";
            this.rdot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdot.UseVisualStyleBackColor = false;
            // 
            // TitleTimer
            // 
            this.TitleTimer.Enabled = true;
            this.TitleTimer.Interval = 6;
            this.TitleTimer.Tick += new System.EventHandler(this.TitleTimer_Tick);
            // 
            // Titlefrontsizetext
            // 
            this.Titlefrontsizetext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Titlefrontsizetext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Titlefrontsizetext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Titlefrontsizetext.Location = new System.Drawing.Point(670, 511);
            this.Titlefrontsizetext.Name = "Titlefrontsizetext";
            this.Titlefrontsizetext.Size = new System.Drawing.Size(22, 21);
            this.Titlefrontsizetext.TabIndex = 8;
            this.Titlefrontsizetext.Text = "72";
            this.Titlefrontsizetext.TextChanged += new System.EventHandler(this.Titlefrontsizetext_TextChanged);
            this.Titlefrontsizetext.DoubleClick += new System.EventHandler(this.Titlefrontsizetext_DoubleClick);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnstart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(694, 534);
            this.Controls.Add(this.Titlefrontsizetext);
            this.Controls.Add(this.rdot);
            this.Controls.Add(this.exitlabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.rdo3);
            this.Controls.Add(this.rdo2);
            this.Controls.Add(this.rdo1);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.btnrestart);
            this.Controls.Add(this.btnresult);
            this.Controls.Add(this.btnset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抽奖系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnset;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnresult;
        private System.Windows.Forms.RadioButton rdo1;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.RadioButton rdo3;
        private System.Windows.Forms.Button btnrestart;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label exitlabel;
        private System.Windows.Forms.RadioButton rdot;
        private System.Windows.Forms.Timer TitleTimer;
        private System.Windows.Forms.TextBox Titlefrontsizetext;
    }
}

