using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lucky
{
    public partial class ShowForm : Form
    {
        public ShowForm()
        {
            InitializeComponent();
        }

        private void ShowForm_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\award";
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] picjp = dir.GetFiles("*.jpg");

                foreach (FileInfo ff in picjp)
                {
                    //if (ff.Name != "Thumbs.db")
                    //{
                        iljp.Images.Add(Image.FromFile(ff.FullName));
                    //}
                }

                pic.Image = iljp.Images[0];
                pic1.Image = iljp.Images[1];
                pic2.Image = iljp.Images[2];
                pic3.Image = iljp.Images[3];

            }
            catch (Exception)
            {
                MessageBox.Show("窗体加载失败:找不到图片!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pic2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void pic1_Click(object sender, EventArgs e)
        {

        }

        
    }
}