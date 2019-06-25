using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; //代表一秒运行一次
            timer1.Enabled = true; //启动
        }
        public bool booql = true;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (booql)
            {
                
                if (DateTime.Now.Hour == 17 && DateTime.Now.Minute == 00) //时间17点
                {
                    booql = false;
                    string time1 = System.DateTime.Now.ToString("d").Replace("/", "-");
                    //bin/debug/mysql
                    string file = ".//mysql/" + time1 + "_test.sql";
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = MySql.conn;
                            MySql.conn.Open();
                            mb.ExportToFile(file);
                            MySql.conn.Close();
                            MessageBox.Show("数据库已自动备份本地");

                        }
                    }
                 
                }

            }
        }

        
    }
}
