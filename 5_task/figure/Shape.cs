using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figure
{
    public abstract class Shape
    {
        protected int x, y; // координаты базовой точки примитива

        // конструктор
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // методы доступа к координатам
        public int GetX() { return x; }
        public int GetY() { return y; }
        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }

        // неабстрактный метод перемещения
        public void MoveTo(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // абстрактный виртуальный метод прорисовки
        public abstract string Show();

        // абстрактный метод прорисовки
        public abstract void Draw(Graphics g);
    }


    // класс окружности, наследующий класс фигур
    public class Circle : Shape
    {
        protected int radius; // радиус окружности

        // конструктор
        public Circle(int x, int y, int radius) : base(x, y)
        {
            this.radius = radius;
        }

        // метод доступа к радиусу
        public int GetRadius() { return radius; }
        public void SetRadius(int radius) { this.radius = radius; }

        // реализация абстрактного метода прорисовки
        public override string Show()
        {
            return($"Drawing circle with center at ({x},{y}) and radius {radius}");
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
        }
    }

    // класс квадрата, наследующий класс фигур
    public class Square : Shape
    {
        protected int size; // длина стороны квадрата

        // конструктор
        public Square(int x, int y, int size) : base(x, y)
        {
            this.size = size;
        }

        // метод доступа к размеру стороны
        public int GetSize() { return size; }
        public void SetSize(int size) { this.size = size; }

        // реализация абстрактного метода прорисовки
        public override string Show()
        {
            return $"Drawing square with bottom left corner at ({x},{y}) and side length {size}";
        }
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, x, y, size, size);
        }
    }


    // класс эллипса, наследующий класс окружностей
    public class Ellipse : Circle
    {
        protected int radius2; // радиус эллипса по второй оси

        // конструктор
        public Ellipse(int x, int y, int radius1, int radius2) : base(x, y, radius1)
        {
            this.radius2 = radius2;
        }

        // метод доступа к радиусу по второй оси
        public int GetRadius2() { return radius2; }
        public void SetRadius2(int radius2) { this.radius2 = radius2; }

        // реализация абстрактного метода прорисовки
        public override string Show()
        {
            return($"Drawing ellipse with center at ({x},{y}) and radii {radius} and {radius2}");
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Black, x - radius, y - radius2, radius * 2, radius2 * 2);
        }
    }


    // класс прямоугольника, наследующий класс квадратов
    public class Rectangle : Square
    {
        protected int width; // ширина прямоугольника
        protected int side;

        // конструктор
        public Rectangle(int x, int y, int side, int width) : base(x, y, side)
        {
            this.side = side;
            this.width = width;
        }

        // метод доступа к ширине
        public int GetWidth() { return width; }
        public void SetWidth(int width) { this.width = width; }

        public int GetSide() { return side; }
        public void SetSide(int side) { this.side = side; }

        // реализация абстрактного метода прорисовки
        public override string Show()
        {
            return($"Drawing rectangle with center at ({x},{y}), size length {side}, and width {width}");
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, x - side / 2, y - width / 2, side, width);
        }


    }
}
