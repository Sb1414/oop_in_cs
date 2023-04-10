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
    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CircleForm circleForm = new CircleForm();
            if (circleForm.ShowDialog() == DialogResult.OK)
            {
                Circle circle = new Circle(circleForm.X, circleForm.Y, circleForm.Radius);
                shapes.Add(circle);
                // pictureBox1.Refresh();
            }
        }
    }
}
