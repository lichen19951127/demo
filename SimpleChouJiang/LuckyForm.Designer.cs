namespace Lucky
{
    partial class LuckyForm
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
            this.btnonoff = new System.Windows.Forms.Button();
            this.lblname = new System.Windows.Forms.Label();
            this.lblno = new System.Windows.Forms.Label();
            this.picface = new System.Windows.Forms.PictureBox();
            this.ilface = new System.Windows.Forms.ImageList(this.components);
            this.tmrchoose = new System.Windows.Forms.Timer(this.components);
            this.btnresult = new System.Windows.Forms.Button();
            this.btnbc = new System.Windows.Forms.Button();
            this.lblcc = new System.Windows.Forms.Label();
            this.lbln = new System.Windows.Forms.Label();
            this.lblset = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picface)).BeginInit();
            this.SuspendLayout();
            // 
            // btnonoff
            // 
            this.btnonoff.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnonoff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnonoff.Location = new System.Drawing.Point(281, 462);
            this.btnonoff.Name = "btnonoff";
            this.btnonoff.Size = new System.Drawing.Size(146, 61);
            this.btnonoff.TabIndex = 1;
            this.btnonoff.TabStop = false;
            this.btnonoff.Text = "开始";
            this.btnonoff.UseVisualStyleBackColor = true;
            this.btnonoff.Click += new System.EventHandler(this.btnonoff_Click);
            // 
            // lblname
            // 
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblname.ForeColor = System.Drawing.Color.Yellow;
            this.lblname.Location = new System.Drawing.Point(111, 352);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(204, 54);
            this.lblname.TabIndex = 3;
            this.lblname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblno
            // 
            this.lblno.AutoSize = true;
            this.lblno.BackColor = System.Drawing.Color.Transparent;
            this.lblno.Font = new System.Drawing.Font("隶书", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblno.ForeColor = System.Drawing.Color.Yellow;
            this.lblno.Location = new System.Drawing.Point(122, 209);
            this.lblno.Name = "lblno";
            this.lblno.Size = new System.Drawing.Size(192, 56);
            this.lblno.TabIndex = 3;
            this.lblno.Text = "一等奖";
            // 
            // picface
            // 
            this.picface.Location = new System.Drawing.Point(394, 197);
            this.picface.Name = "picface";
            this.picface.Size = new System.Drawing.Size(190, 220);
            this.picface.TabIndex = 4;
            this.picface.TabStop = false;
            this.picface.Visible = false;
            // 
            // ilface
            // 
            this.ilface.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.ilface.ImageSize = new System.Drawing.Size(200, 220);
            this.ilface.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tmrchoose
            // 
            this.tmrchoose.Interval = 9;
            this.tmrchoose.Tick += new System.EventHandler(this.tmrchoose_Tick);
            // 
            // btnresult
            // 
            this.btnresult.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnresult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnresult.Location = new System.Drawing.Point(576, 563);
            this.btnresult.Name = "btnresult";
            this.btnresult.Size = new System.Drawing.Size(114, 51);
            this.btnresult.TabIndex = 5;
            this.btnresult.TabStop = false;
            this.btnresult.Text = "获奖记录";
            this.btnresult.UseVisualStyleBackColor = true;
            this.btnresult.Visible = false;
            this.btnresult.Click += new System.EventHandler(this.btnresult_Click);
            // 
            // btnbc
            // 
            this.btnbc.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnbc.ForeColor = System.Drawing.Color.Red;
            this.btnbc.Location = new System.Drawing.Point(12, 481);
            this.btnbc.Name = "btnbc";
            this.btnbc.Size = new System.Drawing.Size(87, 42);
            this.btnbc.TabIndex = 5;
            this.btnbc.TabStop = false;
            this.btnbc.Text = "返回";
            this.btnbc.UseVisualStyleBackColor = true;
            this.btnbc.Click += new System.EventHandler(this.btnbc_Click);
            // 
            // lblcc
            // 
            this.lblcc.AutoSize = true;
            this.lblcc.BackColor = System.Drawing.Color.Transparent;
            this.lblcc.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblcc.Location = new System.Drawing.Point(588, 481);
            this.lblcc.Name = "lblcc";
            this.lblcc.Size = new System.Drawing.Size(23, 24);
            this.lblcc.TabIndex = 6;
            this.lblcc.Text = "0";
            // 
            // lbln
            // 
            this.lbln.AutoSize = true;
            this.lbln.BackColor = System.Drawing.Color.Transparent;
            this.lbln.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbln.ForeColor = System.Drawing.Color.Yellow;
            this.lbln.Location = new System.Drawing.Point(502, 483);
            this.lbln.Name = "lbln";
            this.lbln.Size = new System.Drawing.Size(87, 21);
            this.lbln.TabIndex = 7;
            this.lbln.Text = "已抽出:";
            // 
            // lblset
            // 
            this.lblset.AutoSize = true;
            this.lblset.BackColor = System.Drawing.Color.Transparent;
            this.lblset.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblset.Location = new System.Drawing.Point(589, 445);
            this.lblset.Name = "lblset";
            this.lblset.Size = new System.Drawing.Size(23, 24);
            this.lblset.TabIndex = 6;
            this.lblset.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(502, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "设　置:";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("隶书", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 48;
            this.listBox1.Location = new System.Drawing.Point(391, 184);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(198, 240);
            this.listBox1.TabIndex = 8;
            // 
            // LuckyForm
            // 
            this.AcceptButton = this.btnonoff;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lucky.Properties.Resources.bglucky;
            this.ClientSize = new System.Drawing.Size(643, 541);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblset);
            this.Controls.Add(this.lbln);
            this.Controls.Add(this.lblcc);
            this.Controls.Add(this.btnbc);
            this.Controls.Add(this.btnresult);
            this.Controls.Add(this.picface);
            this.Controls.Add(this.lblno);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.btnonoff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LuckyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抽奖系统";
            this.Load += new System.EventHandler(this.LuckyForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LuckyForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picface)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnonoff;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblno;
        private System.Windows.Forms.PictureBox picface;
        private System.Windows.Forms.ImageList ilface;
        private System.Windows.Forms.Timer tmrchoose;
        private System.Windows.Forms.Button btnresult;
        private System.Windows.Forms.Button btnbc;
        private System.Windows.Forms.Label lblcc;
        private System.Windows.Forms.Label lbln;
        private System.Windows.Forms.Label lblset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
    }
}