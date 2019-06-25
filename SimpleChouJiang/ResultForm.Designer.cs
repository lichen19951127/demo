namespace Lucky
{
    partial class ResultForm
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
            this.tedengjiang = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.rtb3 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tedengjiang
            // 
            this.tedengjiang.AutoSize = true;
            this.tedengjiang.BackColor = System.Drawing.Color.Transparent;
            this.tedengjiang.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tedengjiang.ForeColor = System.Drawing.Color.Yellow;
            this.tedengjiang.Location = new System.Drawing.Point(20, 4);
            this.tedengjiang.Name = "tedengjiang";
            this.tedengjiang.Size = new System.Drawing.Size(141, 35);
            this.tedengjiang.TabIndex = 0;
            this.tedengjiang.Text = "特等奖:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(58, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "一等奖";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(323, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "二等奖";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(593, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "三等奖";
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnclose.Location = new System.Drawing.Point(313, 509);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(129, 42);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // rtb1
            // 
            this.rtb1.BackColor = System.Drawing.Color.White;
            this.rtb1.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb1.ForeColor = System.Drawing.Color.Red;
            this.rtb1.Location = new System.Drawing.Point(37, 124);
            this.rtb1.Name = "rtb1";
            this.rtb1.ReadOnly = true;
            this.rtb1.Size = new System.Drawing.Size(134, 367);
            this.rtb1.TabIndex = 4;
            this.rtb1.TabStop = false;
            this.rtb1.Text = "";
            this.rtb1.TextChanged += new System.EventHandler(this.rtb1_TextChanged);
            // 
            // rtb2
            // 
            this.rtb2.BackColor = System.Drawing.Color.White;
            this.rtb2.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb2.ForeColor = System.Drawing.Color.Red;
            this.rtb2.Location = new System.Drawing.Point(308, 124);
            this.rtb2.Name = "rtb2";
            this.rtb2.ReadOnly = true;
            this.rtb2.Size = new System.Drawing.Size(134, 367);
            this.rtb2.TabIndex = 4;
            this.rtb2.TabStop = false;
            this.rtb2.Text = "";
            this.rtb2.TextChanged += new System.EventHandler(this.rtb2_TextChanged);
            // 
            // rtb3
            // 
            this.rtb3.BackColor = System.Drawing.Color.White;
            this.rtb3.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb3.ForeColor = System.Drawing.Color.Red;
            this.rtb3.Location = new System.Drawing.Point(579, 124);
            this.rtb3.Name = "rtb3";
            this.rtb3.ReadOnly = true;
            this.rtb3.Size = new System.Drawing.Size(134, 367);
            this.rtb3.TabIndex = 4;
            this.rtb3.TabStop = false;
            this.rtb3.Text = "";
            // 
            // ResultForm
            // 
            this.AcceptButton = this.btnclose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lucky.Properties.Resources.bgresult;
            this.ClientSize = new System.Drawing.Size(758, 565);
            this.Controls.Add(this.rtb3);
            this.Controls.Add(this.rtb2);
            this.Controls.Add(this.rtb1);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tedengjiang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResultForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "获奖名单";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tedengjiang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.RichTextBox rtb3;
    }
}