using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace DxControls
{
    public partial class DxTileGroup : UserControl
    {
        public DxTileGroup()
        {
            InitializeComponent();
        }
        public string Title
        {
            set { this.metroLabel1.Text = value; }
            get { return this.metroLabel1.Text; }
        }
        private IEnumerable<string> _tileText;

        public IEnumerable<string> TileText
        {
            get { return _tileText; }
            set
            {
                _tileText = value;
                TileItems  =  FillTiles(_tileText);
            }
        }

        List<MetroTile> FillTiles(IEnumerable<string> lst)
        {
            List<MetroTile> mtlst = new List<MetroTile>();
            MetroFramework.MetroColorStyle[] colors = Enum.GetValues(typeof(MetroFramework.MetroColorStyle)) as MetroFramework.MetroColorStyle[];
            Random random = new Random();
            MetroFramework.MetroColorStyle color = colors[random.Next(5, colors.Length)];
            foreach (var str in lst)
            {
                MetroTile mt = new MetroTile();
                mt.Size = new Size(200, 38);
                mt.TileTextFontSize = MetroFramework.MetroTileTextSize.Medium;
                mt.Text = str;
                mt.TextAlign = ContentAlignment.TopCenter;
                mt.UseStyleColors = true;
                mt.Style = color;
                mtlst.Add(mt);
            }
            return mtlst;
        }
        public List<MetroTile> TileItems
        {
            set
            {
                List<MetroTile> mtlst = value;
                if (mtlst != null)
                {
                    int tilecount = ((mtlst.Count / 100) + ((mtlst.Count % 100) == 0 ? 0 : 1));
                    int width = tilecount * 200 + tilecount * 10;
                    int height = (mtlst.Count / 100 + mtlst.Count % 100) > mtlst.Count % 100 ? 100 : mtlst.Count % 100;
                    //int width = 150;
                    this.Width = width;
                    this.Height = (height + 1) * 44;
                    foreach (MetroTile mt in mtlst)
                    {
                        mt.Click += mt_Click;
                        this.flowLayoutPanel1.Controls.Add(mt);
                    }
                }
            }
        }
        private void mt_Click(object sender, EventArgs e)
        {
            TileClick?.Invoke(this, e);
        }
        public delegate void TileClickHandler(object sender, EventArgs e);
        public event TileClickHandler TileClick;

        public string Result
        {
            get
            {
                string result = this.metroLabel1.Text;
                foreach (MetroTile mt in flowLayoutPanel1.Controls)
                {
                    if (mt.Focused)
                        result += $"-{ mt.Text}";
                }
                return result;
            }
        }
    }
}
