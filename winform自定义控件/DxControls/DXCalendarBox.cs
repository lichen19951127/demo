using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxControls
{
    public partial class DxCalendarBox : UserControl
    {
        public DxCalendarBox()
        {
            InitializeComponent();
        }

        private bool _showClearButton=true;

        public bool ShowClearButton
        {
            get { return _showClearButton; }
            set
            {
                _showClearButton = value;
                if (!_showClearButton)
                {
                    Height = Height - mbClear.Height;
                }
            }
        }

        private bool _showTimBox=false;

        public bool ShowTimeBox
        {
            get { return _showTimBox; }
            set
            {
                _showTimBox = value;
                dateTimePicker1.Visible = _showTimBox;
                if (!_showTimBox)
                {
                    Height = Height - dateTimePicker1.Height;
                }
            }
        }

        public DateTimePicker TimeBox => dateTimePicker1;

        public MonthCalendar CalendarBox => monthCalendar1;

        public delegate void ClearClickHandler(object sender, EventArgs e);
        public event ClearClickHandler ClearClick;

        private void mbClear_Click(object sender, EventArgs e)
        {
            ClearClick?.Invoke(sender, e);
        }
    }
}
