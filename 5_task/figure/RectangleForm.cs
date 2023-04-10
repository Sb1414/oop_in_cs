using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace figure
{
    public partial class RectangleForm : Form
    {
        Point lastPoint;
        public RectangleForm()
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

        public int Side
        {
            get { return int.Parse(textBoxSide.Text); }
        }

        public int Width
        {
            get { return int.Parse(textBoxWidth.Text); }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
