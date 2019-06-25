using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = "server=127.0.0.1;database=test;uid=sa;pwd=1";
        private void BtnBackDataBase_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                DialogResult dr = sf.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string path = sf.FileName;
                    string sql = " BACKUP DATABASE test to DISK = '" + path + "'";
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("数据库备份成功");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    string cmdText = @"restore database test from disk='" + ofd.FileName + "' with REPLACE ";
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    string setOffline = "use test  Alter database test Set Offline With rollback immediate ";
                    string setOnline = " Alter database test Set Online With Rollback immediate";
                    string sql = setOffline + cmdText + setOnline;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
