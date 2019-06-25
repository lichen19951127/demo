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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            var json = Client.GetApi("post", "QueryUsers");
            var user = JsonConvert.DeserializeObject<List<Users>>(json);
            this.dataGridView1.DataSource = user;
        }
    }
}
