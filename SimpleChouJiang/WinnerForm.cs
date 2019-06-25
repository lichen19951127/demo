using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lucky
{
    public partial class WinnerForm : Form
    {
        public int ccdj;    //等级

        public WinnerForm()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //窗体加载
        private void WinnerForm_Load(object sender, EventArgs e)
        {
            //显示等级
            if (ccdj == 1)
            {
                lbldj.Text = "一等奖";
                saveout(1);                      
            }
            else if (ccdj == 2)
            {
                lbldj.Text = "二等奖";
                saveout(2);
            }
            else if (ccdj == 3)
            {
                lbldj.Text = "三等奖";
                saveout(3);
            }          
            
            //居中显示
            //rtbwin.SelectAll();
            //rtbwin.SelectionAlignment= HorizontalAlignment.Center;           
        }

        //读取内容
        private void saveout(int dj)
        {
            if (dj == 1)
            {
                foreach (string a in UserHelper.yiwinner)
                {
                    if (a!=null)
                    {
                        listBox1.Items.Add(a);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (dj == 2)
            {
                foreach (string b in UserHelper.erwinner)
                {
                    if (b!=null)
                    {
                        listBox1.Items.Add(b);
                    }
                    else
                    {
                        break;
                    }
                }

            }
            else if (dj == 3)
            {
                foreach (string c in UserHelper.sanwinner)
                {
                    if (c != null)
                    {
                        listBox1.Items.Add(c);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("没有中奖人员数据","提示");
                this.Close();
            
            }
        }
    }
}