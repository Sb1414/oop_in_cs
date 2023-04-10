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
    public partial class SquareForm : Form
    {
        Point lastPoint;
        public SquareForm()
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

        public int Size
        {
            get { return int.Parse(textBoxSize.Text); }
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
