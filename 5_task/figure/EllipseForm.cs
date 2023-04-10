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

namespace figure
{
    public partial class EllipseForm : Form
    {
        Point lastPoint;
        public EllipseForm()
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

        public int Radius1
        {
            get { return int.Parse(textBoxRadius1.Text); }
        }

        public int Radius2
        {
            get { return int.Parse(textBoxRadius2.Text); }
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
