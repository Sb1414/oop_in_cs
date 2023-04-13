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
        private bool isDragging = false;

        private Shape selectedShape;

        private Point lastLocation;
        private Point mouseDownLocation;
        public Form1()
        {
            InitializeComponent();
        }

        Point lastPoint;

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CircleForm circleForm = new CircleForm();
            if (circleForm.ShowDialog() == DialogResult.OK)
            {
                Circle circle = new Circle(circleForm.X, circleForm.Y, circleForm.Radius);
                shapes.Add(circle);
                DrawShapes(pictureBox1.CreateGraphics());
                labelInfo.Text = circle.Show();
            }
        }

        
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SquareForm squareForm = new SquareForm();
            if (squareForm.ShowDialog() == DialogResult.OK)
            {
                Square square = new Square(squareForm.X, squareForm.Y, squareForm.Size);
                shapes.Add(square);
                DrawShapes(pictureBox1.CreateGraphics());
                labelInfo.Text = square.Show();
            }
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EllipseForm ellipseForm = new EllipseForm();
            if (ellipseForm.ShowDialog() == DialogResult.OK)
            {
                Ellipse ellipse = new Ellipse(ellipseForm.X, ellipseForm.Y, ellipseForm.Radius1, ellipseForm.Radius2);
                shapes.Add(ellipse);
                DrawShapes(pictureBox1.CreateGraphics());
                labelInfo.Text = ellipse.Show();
            }
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RectangleForm rectangleForm = new RectangleForm();
            if (rectangleForm.ShowDialog() == DialogResult.OK)
            {
                Rectangle rectangle = new Rectangle(rectangleForm.X, rectangleForm.Y, rectangleForm.Side, rectangleForm.Width);
                shapes.Add(rectangle);
                DrawShapes(pictureBox1.CreateGraphics());
                labelInfo.Text = rectangle.Show();
            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
                selectedShape = null;
                foreach (Shape shape in shapes)
                {
                    if (shape.GetX() >= e.X - 15 && shape.GetX() <= e.X &&
                        shape.GetY() >= e.Y - 15 && shape.GetY() <= e.Y)
                    {
                        selectedShape = shape;
                        break;
                    }

                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedShape != null)
                {
                    int dx = e.X - mouseDownLocation.X;
                    int dy = e.Y - mouseDownLocation.Y;
                    // использовать dx и dy для перемещения выбранного изображения
                    
                    foreach (Shape shape in shapes)
                    {
                        if (shape.GetX() == selectedShape.GetX())
                        {
                            shape.MoveTo(dx, dy);
                        }
                    }
                    DrawShapes(pictureBox1.CreateGraphics());
                }
                else
                {
                    // не выбрано изображение, но можно обработать перемещение мыши
                }
            }
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            DrawShapes(pictureBox1.CreateGraphics());
            mouseDownLocation = Point.Empty;
        }

        // метод отрисовки фигур
        private void DrawShapes(Graphics g)
        {
            // Очищаем pictureBox1
            g.Clear(Color.White);

            // Рисуем фигуры
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
