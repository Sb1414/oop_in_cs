using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    abstract class Printer
    {
        public int PrintSpeed { get; }

        public Printer(int printSpeed)
        {
            PrintSpeed = printSpeed;
        }

        public abstract void Print();
        public abstract void PrintDetails();
    }

    class LaserPrinter : Printer
    {
        public int CartridgeSize { get; }

        public LaserPrinter(int printSpeed, int cartridgeSize) : base(printSpeed)
        {
            CartridgeSize = cartridgeSize;
        }

        public override void Print()
        {
            Console.WriteLine("Печать лазерного принтера");
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Лазерный принтер - Скорость: {PrintSpeed}, Объем картириджа: {CartridgeSize}");
        }
    }

    class InkjetPrinter : Printer
    {
        public int ColorCount { get; }

        public InkjetPrinter(int printSpeed, int colorCount) : base(printSpeed)
        {
            ColorCount = colorCount;
        }

        public override void Print()
        {
            Console.WriteLine("Печать струйного принтера");
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Струйный принтер - Скорость: {PrintSpeed}, Количество цветов: {ColorCount}");
        }
    }
}
