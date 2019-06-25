using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lucky
{
    public partial class SetForm : Form
    {
        public SetForm()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (vliainput())
            {
                saveset();
                this.Close();
            }
        }

        private void SetForm_Load(object sender, EventArgs e)
        {
            txt.Text = UserHelper.te.ToString();
            txt1.Text = UserHelper.one.ToString();
            txt2.Text = UserHelper.two.ToString();
            txt3.Text = UserHelper.three.ToString();
        }

        //保存设置
        private void saveset()
        {
            try
            {
                UserHelper.te = Convert.ToInt32(txt.Text);
                UserHelper.one = Convert.ToInt32(txt1.Text);
                UserHelper.two = Convert.ToInt32(txt2.Text);
                UserHelper.three = Convert.ToInt32(txt3.Text);
                UserHelper.allset = Convert.ToInt32(txt.Text) + Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt3.Text) ;
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败，请重试！","出错了");
            }
        }

        //输入验证
        private bool vliainput()
        {
            bool result = true;
            
            try
            {
                int txtno1 = Convert.ToInt32(txt1.Text);
                if (txtno1 < 0 || txtno1 > 100)
                {
                    txt1.Clear();
                    txt1.Focus();
                    MessageBox.Show("你输入的数字大小不符合!请输入1~100之间的数字!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = false; 
                }
            }
            catch (Exception)
            {
                txt1.Clear();
                txt1.Focus();
                MessageBox.Show("输入不符合要求!","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                result = false;
            }

            try
            {
                int txtno2 = Convert.ToInt32(txt2.Text);
                if (txtno2 < 1 || txtno2 > 1000)
                {
                    txt2.Clear();
                    txt2.Focus();
                    MessageBox.Show("你输入的数字大小不符合!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = false;
                }
            }
            catch (Exception)
            {
                txt2.Clear();
                txt2.Focus();
                MessageBox.Show("请输入数字!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                result = false;
            }

            try
            {
                int txtno3 = Convert.ToInt32(txt3.Text);
                if (txtno3 < 1 || txtno3 > 1000)
                {
                    txt3.Clear();
                    txt3.Focus();
                    MessageBox.Show("你输入的数字大小不符合!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = false;
                }
            }
            catch (Exception)
            {
                txt3.Clear();
                txt3.Focus();
                MessageBox.Show("请输入数字!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                result = false;
            }
            
            return result;
        }

        //快捷键
        //private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //    {
        //        txt2.Focus();
        //    }
        //}

        //private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //    {
        //        txt3.Focus();
        //    }
        //}
     
    }
}