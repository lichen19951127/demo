using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
           //timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WriteRunLog("我的服务正在运行中》》》");
            using (SqlConnection conn = DapperHelper.Instance().GetConnection())
            {
                var result = conn.Execute("insert into Users values('123')");
                WriteRunLog("新增成功次数"+ result);
            }
        }

        protected override void OnStop()
        {
            WriteRunLog("我的服务停止运行了...");
        }


        /// <summary>
        /// 记录运行日志
        /// </summary>
        /// <param name="writeMsg"></param>
        public void WriteRunLog(string writeMsg)
        {
            FIle_Common file = new FIle_Common();
            file.CreateDire(@"F:\ServiceLog\");


            using (FileStream fs = new FileStream(@"F:\ServiceLog\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter m_streamWriter = new StreamWriter(fs);

                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);

                m_streamWriter.WriteLine("mcWindowsService:" + writeMsg + "  Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n");

                m_streamWriter.Flush();

                m_streamWriter.Close();

                fs.Close();
            }
        }

    }
}
