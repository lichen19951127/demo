using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Lucky
{
    public partial class LoginForm : Form
    {
        bool restart = false;   //清空

        private static int acolor=0;
        bool coloradd = true;

        public LoginForm()
        {
            InitializeComponent();
        }

        //系统设置
        private void btnset_Click(object sender, EventArgs e)
        {
            SetForm set = new SetForm();
            set.ShowDialog();
        }

        //进入抽奖
        private void btnstart_Click(object sender, EventArgs e)
        {
            if (rdo1.Checked == true)
            {
                LuckyForm luck1 = new LuckyForm();
                luck1.choose = 1;
                luck1.ShowDialog();
            }
            else if (rdo2.Checked == true)
            {
                LuckyForm luck2 = new LuckyForm();
                luck2.choose = 2;
                luck2.ShowDialog();
            }
            else if (rdo3.Checked == true)
            {
                LuckyForm luck3 = new LuckyForm();
                luck3.choose = 3;
                luck3.ShowDialog();
            }
            else if (rdot.Checked == true)
            {
                LuckyForm luck = new LuckyForm();
                luck.choose = 0;
                luck.ShowDialog();
            }
        }

        //查看奖品
        private void btnsee_Click(object sender, EventArgs e)
        {
            ShowForm re = new ShowForm();
            re.ShowDialog();
        }
        
        //加载
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //restart = false;
            //SoundPlayer sp = new SoundPlayer("zhufu.wav");
            //sp.PlayLooping();
        }

        //查看结果
        private void btnresult_Click(object sender, EventArgs e)
        {
            ResultForm re = new ResultForm();
            re.ShowDialog();
        }

        //退出
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (restart==false)
            {                
                DialogResult re = MessageBox.Show("您要退出抽奖系统吗?", "关闭提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (re == DialogResult.Yes)
                {
                    DialogResult ree = MessageBox.Show("退出后本次抽奖记录将消失,确认要退出吗?", "重要提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (ree == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();            
            this.Dispose();            
        }      

        //清空
        private void btnrestart_Click(object sender, EventArgs e)
        {            
            DialogResult re = MessageBox.Show("您确定要清空抽奖记录吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (re == DialogResult.OK)
            {               
                restart = true;
                Application.Restart();                
            }     
        }

        private void exitlabel_Click(object sender, EventArgs e)
        {

        }

        private void TitleTimer_Tick(object sender, EventArgs e)
        {

            TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(acolor)))));


            if (acolor == 255)
            {
                coloradd = false;

            }
            else if (acolor == 0)
            {
                coloradd = true;
            
            }

            if (coloradd)
            {
                acolor++;

            }
            else
            {
                acolor--;
            
            }
        }

        private void Titlefrontsizetext_DoubleClick(object sender, EventArgs e)
        {
            int tmpsize = 72;
            try
            {
                tmpsize = int.Parse(Titlefrontsizetext.Text.Trim());


            }
            catch (Exception)
            {
                return;
            }
            TitleLabel.Font = new Font("华文新魏",tmpsize);
        }

        private void Titlefrontsizetext_TextChanged(object sender, EventArgs e)
        {

        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}