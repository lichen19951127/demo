using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace QRCode
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;
        }

        #region 窗体关闭
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("即将退出本系统，是否继续？"
                , "系统提示"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }
        #endregion

        #region 窗体载入
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.InitCmb();
            this.txtData.Text = "input data!";
            this.txtSize.Text = "4";
        }
        #endregion

        #region 初始化ComboBox
        /// <summary>
        /// 初始化ComboBox
        /// </summary>
        private void InitCmb()
        {
            this.cmbEncoding.Items.Add("AlphaNumeric");
            this.cmbEncoding.Items.Add("Numeric");
            this.cmbEncoding.Items.Add("Byte");
            this.cmbEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEncoding.SelectedIndex = 2;

            this.cmbLevel.Items.Add("L");
            this.cmbLevel.Items.Add("M");
            this.cmbLevel.Items.Add("Q");
            this.cmbLevel.Items.Add("H");
            this.cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLevel.SelectedIndex = 1;

            this.cmbVersion.Items.Add("1");
            this.cmbVersion.Items.Add("2");
            this.cmbVersion.Items.Add("3");
            this.cmbVersion.Items.Add("4");
            this.cmbVersion.Items.Add("5");
            this.cmbVersion.Items.Add("6");
            this.cmbVersion.Items.Add("7");
            this.cmbVersion.Items.Add("8");
            this.cmbVersion.Items.Add("9");
            this.cmbVersion.Items.Add("10");
            this.cmbVersion.Items.Add("11");
            this.cmbVersion.Items.Add("12");
            this.cmbVersion.Items.Add("13");
            this.cmbVersion.Items.Add("14");
            this.cmbVersion.Items.Add("15");
            this.cmbVersion.Items.Add("16");
            this.cmbVersion.Items.Add("17");
            this.cmbVersion.Items.Add("18");
            this.cmbVersion.Items.Add("19");
            this.cmbVersion.Items.Add("20");
            this.cmbVersion.Items.Add("21");
            this.cmbVersion.Items.Add("22");
            this.cmbVersion.Items.Add("23");
            this.cmbVersion.Items.Add("24");
            this.cmbVersion.Items.Add("25");
            this.cmbVersion.Items.Add("26");
            this.cmbVersion.Items.Add("27");
            this.cmbVersion.Items.Add("28");
            this.cmbVersion.Items.Add("29");
            this.cmbVersion.Items.Add("30");
            this.cmbVersion.Items.Add("31");
            this.cmbVersion.Items.Add("32");
            this.cmbVersion.Items.Add("33");
            this.cmbVersion.Items.Add("34");
            this.cmbVersion.Items.Add("35");
            this.cmbVersion.Items.Add("36");
            this.cmbVersion.Items.Add("37");
            this.cmbVersion.Items.Add("38");
            this.cmbVersion.Items.Add("39");
            this.cmbVersion.Items.Add("40");
            this.cmbVersion.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbVersion.SelectedIndex = 6;
        }
        #endregion

        #region  QRCodeEncodeMode
        /// <summary>
        /// QRCodeEncodeMode
        /// </summary>
        /// <returns></returns>
        private QRCodeEncoder.ENCODE_MODE GetQRCodeEncodeMode()
        {
            if (this.cmbEncoding.Text == "Byte")
            {
                return QRCodeEncoder.ENCODE_MODE.BYTE;
            }
            else if (this.cmbEncoding.Text == "AlphaNumeric")
            {
                return QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
            }
            else if (this.cmbEncoding.Text == "Numeric")
            {
                return QRCodeEncoder.ENCODE_MODE.NUMERIC;
            }
            else
            {
                return QRCodeEncoder.ENCODE_MODE.BYTE;
            }
        }
        #endregion

        #region QRCodeErrorCorrect
        /// <summary>
        /// QRCodeErrorCorrect
        /// </summary>
        /// <returns></returns>
        private QRCodeEncoder.ERROR_CORRECTION GetQRCodeErrorCorrect()
        {
            if (this.cmbLevel.Text == "L")
            {
                return QRCodeEncoder.ERROR_CORRECTION.L;
            }
            else if (this.cmbLevel.Text == "M")
            {
                return QRCodeEncoder.ERROR_CORRECTION.M;
            }
            else if (this.cmbLevel.Text == "Q")
            {
                return QRCodeEncoder.ERROR_CORRECTION.Q;
            }
            else if (this.cmbLevel.Text == "H")
            {
                return QRCodeEncoder.ERROR_CORRECTION.H;
            }
            else
            {
                return QRCodeEncoder.ERROR_CORRECTION.L;
            }
        }
        #endregion

        #region QRCodeVersion
        /// <summary>
        /// QRCodeVersion
        /// </summary>
        /// <returns></returns>
        private int GetQRCodeVersion()
        {
            try
            {
                int version = Convert.ToInt16(this.cmbVersion.Text);
                return version;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid version !");
                return 1;
            }
        }
        #endregion

        #region QRCodeScale
        /// <summary>
        /// QRCodeScale
        /// </summary>
        /// <returns></returns>
        private int GetQRCodeScale()
        {
            try
            {
                int size = Convert.ToInt32(this.txtSize.Text);
                return size;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid size!");
                return 1;
            }
        }
        #endregion

        #region 生成二维码
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtData.Text.Trim()))
            {
                MessageBox.Show("Data must not be empty!");
                return;
            }

            ThoughtWorks.QRCode.Codec.QRCodeEncoder qrEncoder = new QRCodeEncoder();
            qrEncoder.QRCodeEncodeMode = this.GetQRCodeEncodeMode();
            qrEncoder.QRCodeErrorCorrect = this.GetQRCodeErrorCorrect();
            qrEncoder.QRCodeVersion = this.GetQRCodeVersion();
            qrEncoder.QRCodeScale = this.GetQRCodeScale();
            Bitmap image = qrEncoder.Encode(this.txtData.Text, Encoding.Default);
            this.picEncode.Image = image;
        }
        #endregion

        #region 保存图片
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
            save.Title = "Save";
            save.FileName = string.Empty;
            save.ShowDialog();

            if (!string.IsNullOrEmpty(save.FileName))
            {
                System.IO.FileStream fs = (System.IO.FileStream)save.OpenFile();
                switch (save.FilterIndex)
                {
                    case 1:
                        this.picEncode.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.picEncode.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        this.picEncode.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:
                        this.picEncode.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }
        #endregion

        #region 打印图片
        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            print.Document = printDocument;
            if (DialogResult.OK == print.ShowDialog())
            {
                printDocument.Print();
            }
        }
        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(this.picEncode.Image, 0, 0);
        }
        #endregion

        #region 打开文件
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            openFile.FileName = string.Empty;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFile.FileName;
                this.picDecode.Image = new Bitmap(fileName);
            }
        }
        #endregion

        #region 读取二维码
        /// <summary>
        /// 读取二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecode_Click(object sender, EventArgs e)
        {
            try
            {
                QRCodeDecoder decoder = new QRCodeDecoder();
                //QRCodeDecoder.Canvas = new ConsoleCanvas();
                String decodedString = decoder.decode(new QRCodeBitmapImage(new Bitmap(this.picDecode.Image)));
                this.txtShow.Text = decodedString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
