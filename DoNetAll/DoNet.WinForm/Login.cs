using DoNet.Common;
using DoNet.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoNet.WinForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var json = Client.GetApi("post", "Login?name=" + txtName.Text + "&pwd=" + txtName.Text);
            var user = JsonConvert.DeserializeObject<Users>(json);
            if (user != null)
            {
                MessageBox.Show("success");
                Index f2 = new Index();
                f2.ShowDialog(this);
                this.Close();

            }
            else
                MessageBox.Show("error");
        }
    }
}
