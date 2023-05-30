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
        private int capacity;

        public PrinterContainer(int initialCapacity)
        {
            printers = new Printer[initialCapacity];
            capacity = initialCapacity;
            count = 0;
        }

        public int prCn()
        {
            return count;
        }

        public void AddPrinter(Printer printer)
        {
            if (count >= capacity)
            {
                Console.WriteLine("Увеличьте размер массива, он переполнен!");
                return;
            }

            printers[count] = printer;
            count++;
        }

        public void IncreaseCapacity(int additionalCapacity)
        {
            int newCapacity = capacity + additionalCapacity;
            Printer[] newPrinters = new Printer[newCapacity];
            Array.Copy(printers, newPrinters, capacity);
            printers = newPrinters;
            capacity = newCapacity;
        }

        public void RemovePrinter(Printer printer)
        {
            for (int i = 0; i < count; i++)
            {
                if (printers[i] == printer)
                {
                    for (int j = i; j < count; j++)
                    {
                        Console.WriteLine("заменяю " + j + " i = " + i);
                        printers[j] = printers[j + 1];
                    }

                    printers[count - 1] = null;
                    count--;
                    return;
                }
            }

            Console.WriteLine("Принтер не найден в контейнере.");
        }

        public void RemovePrinterL(int cartridgeSize)
        {
            for (int i = 0; i < count; i++)
            {
                if (printers[i] is LaserPrinter printer && printer.CartridgeSize == cartridgeSize)
                {
                    Remove(i);
                    return;
                }
            }

            Console.WriteLine("Статья с таким заголовком не найдена.");
        }

        public void RemovePrinterI(int colorCount)
        {
            for (int i = 0; i < count; i++)
            {
                if (printers[i] is InkjetPrinter printer && printer.ColorCount == colorCount)
                {
                    Remove(i);
                    return;
                }
            }

            Console.WriteLine("Статья с таким заголовком не найдена.");
        }

        private void Remove(int index)
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
