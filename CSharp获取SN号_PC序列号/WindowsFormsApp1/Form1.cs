using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            var abc = GetPcsnString();
            MessageBox.Show(abc);
        }

        /// <summary>
        /// 获得pc号 sn号
        /// </summary>
        public static string GetPcsnString()
        {
            var pcsn = "";
            try
            {
                var search = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                var mobos = search.Get();
                foreach (var temp in mobos)
                {
                    //wmic bios get serialnumber
                    object serial = temp["SerialNumber"]; // ProcessorID if you use Win32_CPU
                    pcsn = serial.ToString();
                    Console.WriteLine(pcsn);

                    if
                    (
                      !string.IsNullOrEmpty(pcsn)
                      && pcsn != "To be filled by O.E.M" //没有找到
                      && !pcsn.Contains("O.E.M")
                      && !pcsn.Contains("OEM")
                      && !pcsn.Contains("Default")
                    )
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("默认值");
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                // 无法处理
            }

            return pcsn;
        }

    }
}
