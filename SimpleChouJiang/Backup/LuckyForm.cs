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
    public partial class LuckyForm : Form
    {       
        public int choose;     
        int pernum;            //总人数(图片的数量)
        int i = 0;             //图片下标(总人数)
        int index;             //中奖者的下标(滚动下标)           
        int dj = 1;            //抽奖等级
        int save=0;              //是否保存
        String winner="";          //中奖者下标
 
        bool go = true;        //判断开始按钮  
        int wined = 0;         //已抽出的中奖人数

        Random ran = new Random(DateTime.Now.Millisecond);

        int tmpadd = 0;
        private static int aset = 0;
        private static int setnum=0;

        public LuckyForm()
        {
            InitializeComponent();
        }


        private void zhongjianglist()
        {
            if (dj == 1)
            {
                foreach (string a in UserHelper.yiwinner)
                {
                    if (a != null)
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
                    if (b != null)
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

            else if (dj == 4)
            {
                foreach (string d in UserHelper.siwinner)
                {
                    if (d != null)
                    {
                        listBox1.Items.Add(d);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (dj == 5)
            {
                foreach (string e in UserHelper.wuwinner)
                {
                    if (e != null)
                    {
                        listBox1.Items.Add(e);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (dj == 0)
            {
                foreach (string t in UserHelper.twinner)
                {
                    if (t != null)
                    {
                        listBox1.Items.Add(t);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

          
        private void LuckyForm_Load(object sender, EventArgs e)
        {
            try
            {

                //显示抽几等奖
                if (choose == 1)
                {
                    lblno.Text = "一等奖";
                    lblset.Text = UserHelper.one.ToString();  //设置名额
                    lblcc.Text = readnum(1).ToString();　　　 //抽出名额
                    dj = 1;
                }
                else if (choose == 2)
                {
                    lblno.Text = "二等奖";
                    lblset.Text = UserHelper.two.ToString();
                    lblcc.Text = readnum(2).ToString();
                    dj = 2;
                }
                else if (choose == 3)
                {
                    lblno.Text = "三等奖";
                    lblset.Text = UserHelper.three.ToString();
                    lblcc.Text = readnum(3).ToString();
                    dj = 3;
                }
                else if (choose == 4)
                {
                    lblno.Text = "四等奖";
                    lblset.Text = UserHelper.four.ToString();
                    lblcc.Text = readnum(4).ToString();
                    dj = 4;
                }
                else if (choose == 5)
                {
                    lblno.Text = "五等奖";
                    lblset.Text = UserHelper.five.ToString();
                    lblcc.Text = readnum(5).ToString();
                    dj = 5;
                }
                else if (choose == 0)
                {
                    lblno.Text = "特等奖";
                    lblset.Text = UserHelper.te.ToString();
                    lblcc.Text = readnum(0).ToString();
                    dj = 0;
                }


                zhongjianglist();

                //所有图片路径
                //string path = Application.StartupPath + @"\staff";

                ////设置抽奖人员
                //DirectoryInfo dir = new DirectoryInfo(path);
                //FileInfo[] ff = dir.GetFiles("*.jpg");
                //i = ff.Length;
                //pernum = ff.Length;　　　//总人数

                //存放名字的数组
                //UserHelper.sname = new string[i];
                //int ix = 0;
                //foreach (FileInfo f in ff)
                //{
                //    UserHelper.sname[ix] = f.Name.ToString().Substring(0, f.Name.Length - 4);
                //    ilface.Images.Add(f.Name, Image.FromFile(f.FullName));
                //    ix++;
                //}

                //读取用户信息 放到数组中去默认最大人数是500
                UserHelper.sname = new string[500];
                StreamReader sr = new StreamReader("staff.txt",System.Text.Encoding.Default);

                while (!sr.EndOfStream)
                {
                    UserHelper.sname[i] = sr.ReadLine();
                    i++;
                }

                sr.Close();
                pernum = i;

                //加载单项抽出的人数
                save = Convert.ToInt32(lblcc.Text);
                //加载抽出的总人数
                wined = readnum(1) + readnum(2) + readnum(3) + readnum(4) + readnum(5) + readnum(0);
            }
            catch (Exception)
            {
                MessageBox.Show("抱歉,启动失败!","系统",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Close();
            }
        }  
    
        //读取抽取的名额
        private int readnum(int num)
        {
            int re = 0;  //计数器
            
            if (num == 1)
            {
                foreach (string n in UserHelper.yiwinner)
                {
                    if (n != null)
                    {
                        re++;
                    }
                    else 
                    {
                        break;
                    }
                }
            }
            else if (num == 2)
            {
                foreach (string n in UserHelper.erwinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (num == 3)
            {
                foreach (string n in UserHelper.sanwinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            else if (num == 4)
            {
                foreach (string n in UserHelper.siwinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (num == 5)
            {
                foreach (string n in UserHelper.wuwinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (num == 0)
            {
                foreach (string n in UserHelper.twinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return re;
        }

        //键盘控制
        //private void LuckyForm_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //判断是否按下空格或回车
        //    if (e.KeyChar == '\r' || e.KeyChar == ' ')
        //    {
        //        btnonoff_Click(sender, e);
        //    }
        //}

        //图片游动控制
        private void tmrchoose_Tick(object sender, EventArgs e)
        {           
            index = ran.Next(1, i - 1);         
      
            //this.picface.Image = this.ilface.Images[index];
            this.lblname.Text = UserHelper.sname[index];
        }

        //点击开始抽奖
        private void btnonoff_Click(object sender, EventArgs e)
        {
            //图片张数大于1
            if (pernum > 0)
            {
                //判断按键开始抽奖
                if (go)
                {
                    //当抽出了所有名额提示返回
                    if (Convert.ToInt32(lblcc.Text) >= Convert.ToInt32(lblset.Text))
                    {
                        DialogResult re = MessageBox.Show("您设置的中奖人数已经全部抽出,要返回吗?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (re == DialogResult.OK)
                        {
                            this.Close();
                        }
                        else
                        {                            
                            tmrchoose.Enabled = true;
                            btnonoff.Text = "停止";
                            go = false;
                        }
                    }
                    else
                    {
                        tmrchoose.Enabled = true;
                        btnonoff.Text = "停止";
                        go = false;
                    }
                }
                else
                {
                    if (btnonoff.Text.Equals("保存"))
                    {
                        DialogResult re = MessageBox.Show("要保存本次的抽奖记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (re == DialogResult.Yes)
                        {
                            switch (dj)
                            {
                                case 1:
                                    UserHelper.yiwinner[save] = winner;
                                    break;
                                case 2:
                                    UserHelper.erwinner[save] = winner;
                                    break;
                                case 3:
                                    UserHelper.sanwinner[save] = winner;
                                    break;  
                                case 4:
                                    UserHelper.siwinner[save] = winner;
                                    break;  
                                case 5:
                                    UserHelper.wuwinner[save] = winner;
                                    break;  
                                case 0:
                                    UserHelper.twinner[save] = winner;
                                    break;  
                            }

                            UserHelper.wintemp[wined] = winner;
                            listBox1.Items.Add(winner);

                            save = save + 1;     //单项中奖人数自增一
                            wined = wined + 1;   //中奖总人数自增一
                            lblcc.Text = Convert.ToString(Convert.ToInt32(lblcc.Text) + 1);

                            btnonoff.Text = "开始";
                            go = true;
                        }
                        else
                        {
                            btnonoff.Text = "开始";
                            go = true;
                        }

                        winner = "";//清空中奖者缓存
                    }
                    else
                    {
                        
                        tmrchoose.Enabled = false;
                        bool ishave;//是否重复   
                        do
                        {
                            ishave = false;      //初始化
                   
                            //如果己抽出的人数大于参加抽奖的人数,充许中两次奖(一般不可能出现~~!)
                            if (wined >= i-1)
                            {
                                //ishave = false;
                                break;
                            }


                            foreach (string awin in UserHelper.wintemp)
                            {
                                if (UserHelper.sname[index].Equals(awin))
                                {
                                    ishave = true;
                                    break;
                                }
                            
                            }

                            if (ishave)
                            {
                                index++;
                                if (index >= i)
                                {
                                    index = 1;
                                
                                }
                            }
                        } while (ishave);

                        SetLucky();

                       // this.picface.Image = this.ilface.Images[index];
                        this.lblname.Text = winner;
                        //将抽出的结果存在winner中 
                        btnonoff.Text = "保存";
                    }
                }
            }
            else 
            {
                MessageBox.Show("没有找到抽奖成员!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetLucky()
        {
            if (dj == 0)
            {
                tmpadd = 1;

            }
            else if (tmpadd == 0)
            {
                tmpadd = ran.Next(1, dj);

            }

           aset++;

            if(aset == tmpadd)
            {
            switch (dj)
                {
                    case 0:
                        winner = UserHelper.setwin;
                        break;
                    case 1:
                        if (setnum < UserHelper.setwin1.Length && UserHelper.setwin1[setnum] != null)
                        {
                            winner = UserHelper.setwin1[setnum];
                            setnum++;
                        }
                        break;
                    case 2:
                        if (setnum < UserHelper.setwin2.Length && UserHelper.setwin2[setnum] != null)
                        {
                            winner = UserHelper.setwin2[setnum];
                            setnum++;
                        }
                        break;
                    case 3:
                        if (setnum < UserHelper.setwin3.Length && UserHelper.setwin3[setnum] != null)
                        {
                                winner = UserHelper.setwin3[setnum];
                                setnum++;
                        }
                        break;
                    case 4:
                        if (setnum < UserHelper.setwin4.Length && UserHelper.setwin4[setnum] != null)
                        {
                                winner = UserHelper.setwin4[setnum];
                                setnum++;
                        }
                        break;
                    case 5:
                        if (setnum < UserHelper.setwin5.Length && UserHelper.setwin5[setnum] != null)
                        {
                                winner = UserHelper.setwin5[setnum];
                                setnum++;

                        }
                        break;
                
                }

                            aset = 0;
                            tmpadd = 0;
             
            }

           

            if (winner==null || winner.Equals(""))
            {
                winner = UserHelper.sname[index];
            
            }

        }


        //查看结果
        private void btnresult_Click(object sender, EventArgs e)
        {
            //WinnerForm winner = new WinnerForm();
            //winner.ccdj = this.dj;
            //winner.ShowDialog();
        }       
       
        //返回
        private void btnbc_Click(object sender, EventArgs e)
        {

            aset = 0;
            setnum = 0;

            this.Close();

        }

        //退出关闭tmr
        private void LuckyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnonoff.Text.Equals("保存"))
            { 
                       DialogResult re = MessageBox.Show("已抽出中奖者但尚未保存,要关闭吗?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                       if (re == DialogResult.Cancel)
                       {
                           e.Cancel = true;
                           return;
                       }
            

            }
            aset = 0;
            setnum = 0;

            GC.Collect();
            this.Dispose();



        }                
    }
}