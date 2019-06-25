using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 进制转换.net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Dictionary<int, string> kvDictonary = new Dictionary<int, string>();
            kvDictonary.Add(2, "二进制");
            kvDictonary.Add(8, "八进制");
            kvDictonary.Add(10, "十进制");
            kvDictonary.Add(16, "十六进制");
            BindingSource bs = new BindingSource();
            bs.DataSource = kvDictonary;
            formType.DataSource = bs;
            formType.ValueMember = "Key";
            formType.DisplayMember = "Value";

            BindingSource bs2 = new BindingSource();
            bs2.DataSource = kvDictonary;
            toType.DataSource = bs2;
            toType.ValueMember = "Key";
            toType.DisplayMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.Match(txtNum.Text, "^\\d+$").Success)
            {
                //var arr= txtNum.Text.Split();
                List<string> arr = new List<string>();
                for (int i = 0; i < txtNum.Text.Length; i++)
                {
                    arr.Add(txtNum.Text.Substring(i,1));
                }
                var isBool = true;
                foreach (var item in arr)
                {
                    if (Convert.ToInt32(formType.SelectedValue) < Convert.ToInt32(item))
                    {
                        isBool = false;
                        MessageBox.Show("请输入合法的进制数值");
                    }
                }
                if(isBool)
                txtResult.Text = ConvertGenericBinary(txtNum.Text, formType.Text, toType.Text);
            }
            else
            {
                MessageBox.Show("请输入数值");
            }
            
           
        }

        /// <summary>
        /// 进制转换
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fromType"></param>
        /// <param name="toType"></param>
        /// <returns></returns>
        public string ConvertGenericBinary(string input, string
             fromType, string toType)
        {
            string output = input;
            switch (fromType)
            {
                case "二进制":
                    output = ConvertGenericBinaryFromBinary(input, toType);
                    break;
                case "八进制":
                    output = ConvertGenericBinaryFromOctal(input, toType);
                    break;
                case "十进制":
                    output = ConvertGenericBinaryFromDecimal(input, toType);
                    break;
                case "十六进制":
                    output = ConvertGenericBinaryFromHexadecimal(input, toType);
                    break;
                default:
                    break;
            }
            return output;
        }

        /// <summary>
        /// 从二进制转换成其他进制
        /// </summary>
        /// <param name="input"></param>
        /// <param name="toType"></param>
        /// <returns></returns>
        private string ConvertGenericBinaryFromBinary(string input, string toType)
        {
            switch (toType)
            {
                case "八进制":
                    //先转换成十进制然后转八进制
                    input = Convert.ToString(Convert.ToInt32(input, 2), 8);
                    break;
                case "十进制":
                    input = Convert.ToInt32(input, 2).ToString();
                    break;
                case "十六进制":
                    input = Convert.ToString(Convert.ToInt32(input, 2), 16);
                    break;
                default:
                    break;
            }
            return input;
        }

        /// <summary>
        /// 从八进制转换成其他进制
        /// </summary>
        /// <param name="input"></param>
        /// <param name="toType"></param>
        /// <returns></returns>
        private string ConvertGenericBinaryFromOctal(string input, string toType)
        {
            switch (toType)
            {
                case "二进制":
                    input = Convert.ToString(Convert.ToInt32(input, 8), 2);
                    break;
                case "十进制":
                    input = Convert.ToInt32(input, 8).ToString();
                    break;
                case "十六进制":
                    input = Convert.ToString(Convert.ToInt32(input, 8), 16);
                    break;
                default:
                    break;
            }
            return input;
        }

        /// <summary>
        /// 从十进制转换成其他进制
        /// </summary>
        /// <param name="input"></param>
        /// <param name="toType"></param>
        /// <returns></returns>
        private string ConvertGenericBinaryFromDecimal(string input, string toType)
        {
            string output = "";
            int intInput = Convert.ToInt32(input);
            switch (toType)
            {
                case "二进制":
                    output = Convert.ToString(intInput, 2);
                    break;
                case "八进制":
                    output = Convert.ToString(intInput, 8);
                    break;
                case "十六进制":
                    output = Convert.ToString(intInput, 16);
                    break;
                default:
                    output = input;
                    break;
            }
            return output;
        }

        /// <summary>
        /// 从十六进制转换成其他进制
        /// </summary>
        /// <param name="input"></param>
        /// <param name="toType"></param>
        /// <returns></returns>
        private string ConvertGenericBinaryFromHexadecimal(string input, string toType)
        {
            switch (toType)
            {
                case "二进制":
                    input = Convert.ToString(Convert.ToInt32(input, 16), 2);
                    break;
                case "八进制":
                    input = Convert.ToString(Convert.ToInt32(input, 16), 8);
                    break;
                case "十进制":
                    input = Convert.ToInt32(input, 16).ToString();
                    break;
                default:
                    break;
            }
            return input;
        }

        /// <summary>
        /// 二进制之间的加法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string AddBetweenBinary(string x, string y)
        {
            int intSum = Convert.ToInt32(x, 2) + Convert.ToInt32(y, 2);
            return Convert.ToString(intSum, 2);
        }
    }
}
