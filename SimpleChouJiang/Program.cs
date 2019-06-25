using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lucky
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (args.Length < 6)
            //{
            //    return;
            
            //}

            switch (args.Length)
            {
                case 0:
                    break;
                case 1:
                    UserHelper.setwin = args[0];
                    break;
                case 2:
                    UserHelper.setwin = args[0];
                    UserHelper.setwin1 = args[1].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case 3:
                    UserHelper.setwin = args[0];
                    UserHelper.setwin1 = args[1].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin2 = args[2].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case 4:
                    UserHelper.setwin = args[0];
                    UserHelper.setwin1 = args[1].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin2 = args[2].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin3 = args[3].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case 5:
                    UserHelper.setwin = args[0];
                    UserHelper.setwin1 = args[1].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin2 = args[2].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin3 = args[3].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin4 = args[4].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case 6:
                    UserHelper.setwin = args[0];
                    UserHelper.setwin1 = args[1].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin2 = args[2].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin3 = args[3].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin4 = args[4].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin5 = args[5].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                default:
                    UserHelper.setwin = args[0];
                    UserHelper.setwin1 = args[1].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin2 = args[2].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin3 = args[3].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin4 = args[4].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    UserHelper.setwin5 = args[5].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    break;

            }
            Application.Run(new LoginForm());
        }
    }
}