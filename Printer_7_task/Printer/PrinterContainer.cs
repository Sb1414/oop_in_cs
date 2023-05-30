using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    class PrinterContainer
    {
        private Printer[] printers;
        private int count;

        public PrinterContainer()
        {
            printers = new Printer[4]; // Начальный размер массива
            count = 0;
        }

        public int prCn()
        {
            return count;
        }

        public void AddPrinter(Printer printer)
        {
            if (count >= printers.Length)
            {
                IncreaseCapacity();
            }

            printers[count] = printer;
            count++;
        }

        private void IncreaseCapacity()
        {
            int newCapacity = printers.Length * 2; // Увеличение вдвое
            Printer[] newPrinters = new Printer[newCapacity];
            Array.Copy(printers, newPrinters, count);
            printers = newPrinters;
        }

        public void RemovePrinter(Printer printer)
        {
            int index = Array.IndexOf(printers, printer);
            if (index >= 0)
            {
                RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Принтер не найден в контейнере.");
            }
        }

        public void RemovePrinterL(int cartridgeSize)
        {
            for (int i = 0; i < count; i++)
            {
                if (printers[i] is LaserPrinter printer && printer.CartridgeSize == cartridgeSize)
                {
                    RemoveAt(i);
                    return;
                }
            }

            Console.WriteLine("Принтер с таким размером картриджа не найден.");
        }

        public void RemovePrinterI(int colorCount)
        {
            for (int i = 0; i < count; i++)
            {
                if (printers[i] is InkjetPrinter printer && printer.ColorCount == colorCount)
                {
                    RemoveAt(i);
                    return;
                }
            }

            Console.WriteLine("Принтер с таким количеством цветов не найден.");
        }

        private void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Некорректный индекс.");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                printers[i] = printers[i + 1];
            }

            printers[count - 1] = null;
            count--;
        }

        public void PrintAll()
        {
            for (int i = 0; i < count; i++)
            {
                if (printers[i] != null)
                {
                    printers[i].Print();
                    Console.WriteLine();
                }
            }
        }

        public void PrintDetailsAll()
        {
            for (int i = 0; i < count; i++)
            {
                if (printers[i] != null)
                {
                    printers[i].PrintDetails();
                    Console.WriteLine();
                }
            }
        }
    }

}
