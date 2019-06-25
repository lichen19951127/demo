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

        /// <summary>
        /// 检查Winddows激活有效期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("slmgr.vbs -xpr");
        }

        /// <summary>
        /// 计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("calc");
        }

        /// <summary>
        /// 记事本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("notepad");
        }

        /// <summary>
        /// 注册表编辑器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("regedit");
        }

        /// <summary>
        /// 计算机性能监测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("perfmon.msc");
        }

        /// <summary>
        /// 任务管理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("taskmgr");
        }

        /// <summary>
        /// 系统版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button7_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("winver");
        }

        /// <summary>
        /// 画图板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button8_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("mspaint");
        }

        /// <summary>
        /// 远程桌面连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button16_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("mstsc");
        }

        /// <summary>
        /// 放大镜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button15_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("magnify");
        }

        /// <summary>
        /// DirectX诊断工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button14_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("dxdiag");
        }

        /// <summary>
        /// 屏幕键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button13_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("osk");
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("eventvwr");
        }

        /// <summary>
        /// 造字程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button11_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("eudcedit");
        }

        /// <summary>
        /// 字符映射表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button10_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("charmap");
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button9_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("logoff");
        }

        /// <summary>
        /// 关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button24_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("shutdown -s -t 00");
        }

        /// <summary>
        /// 60s后关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button23_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("shutdown -s -t 60");
        }

        /// <summary>
        /// 重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button22_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("shutdown -r -t 00");
        }

        /// <summary>
        /// 取消关机/重启指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button21_Click(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("shutdown -a");
        }
    }
}
