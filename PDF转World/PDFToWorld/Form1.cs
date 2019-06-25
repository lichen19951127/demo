using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFToWorld
{
    using Microsoft.Office.Interop.Word;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择文件夹
        /// </summary>
        /// <returns></returns>
        public string GetSavePath()
        {
            string filePath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //对话框描述
            dialog.Description = "请选择要保存的文件夹";
            //是否显示对话框左下角新建文件夹按钮,默认true
            dialog.ShowNewFolderButton = false;
            //首次filePath为空,按FolderBrowserDialog默认设置(即桌面)选择
            if (filePath == "")
            {
                //设置此默认目录为上一次选中记录
                dialog.SelectedPath = filePath;
            }
            //按下确定选择按钮
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.SelectedPath;
            }
            return filePath;
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <returns></returns>
        public string GetFilePath()
        {
            string filePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            return filePath;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var filePath = GetFilePath();
            MessageBox.Show(filePath);


            var a = WordToPDF(filePath,@"F:\\");

        }
        /// <summary>
        /// 基于Office
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <returns></returns>
        //Microsoft.Office.Interop.Word.dll
        public bool WordToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Document document = null;
            try
            {
                application.Visible = false;
                document = application.Documents.Open(sourcePath);
                document.ExportAsFixedFormat(targetPath, WdExportFormat.wdExportFormatPDF);
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            finally
            {
                document.Close();
            }
            return result;
        }

        /// <summary>
        /// 基于wps
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <returns></returns>
        //public bool WordToPdfWithWPS(string sourcePath, string targetPath)
        //{
        //    WPS.ApplicationClass app = new WPS.ApplicationClass();
        //    WPS.Document doc = null;
        //    try
        //    {
        //        doc = app.Documents.Open(sourcePath, true, true, false, null, null, false, "", null, 100, 0, true, true, 0, true);
        //        doc.ExportPdf(targetPath, "", "");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        doc.Close();
        //    }
        //    return true;
        //}
    }
}
