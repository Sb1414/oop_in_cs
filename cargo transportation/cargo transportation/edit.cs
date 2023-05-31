using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cargo_transportation
{
    public partial class edit : Form
    {
        public edit()
        {
            InitializeComponent();
            buttonOk.DialogResult = DialogResult.OK;

            this.AcceptButton = buttonOk;
        }

        public int CountQueue
        {
            get { return Convert.ToInt32(numericUpDown1.Value); }
        }
    }
}
