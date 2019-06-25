using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 同步和异步
{
    public partial class Form1 : Form
    {
    //同步：等待上一行完成计算之后，才会进入下一行。
    //异步：不会等待方法的完成，会直接进入下一行，是非阻塞的。
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 同步  有序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnSync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            int j = 3;
            int k = 5;
            int m = j + k;
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }
        }

        /// <summary>
        /// 异步  无序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"***************btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId}");
            Action<string> action = this.DoSomethingLong;
            // 调用委托(同步调用)
            action.Invoke("btnAsync_Click_1");
            // 异步调用委托
            action.BeginInvoke("btnAsync_Click_2", null, null);
            Console.WriteLine($"***************btnAsync_Click End    {Thread.CurrentThread.ManagedThreadId}");
        }

        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"****************DoSomethingLong {name} Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }
            Console.WriteLine($"****************DoSomethingLong {name}   End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}***************");
        }
    }
}
