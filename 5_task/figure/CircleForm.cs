using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace figure
{
    public partial class CircleForm : Form
    {
        private Label xLabel, yLabel, radiusLabel;
        public CircleForm()
        {
            InitializeComponent();
            okButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;

            this.AcceptButton = okButton;
            this.cancelButton = cancelButton;
        }

       
        public int X
        {
            get { return int.Parse(textBoxX.Text); }
        }

        public int Y
        {
            get { return int.Parse(textBoxY.Text); }
        }

        public int Radius
        {
            get { return int.Parse(textBoxRadius.Text); }
        }
    }
}
