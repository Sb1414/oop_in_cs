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

        public PrinterContainer(int capacity)
        {
            printers = new Printer[capacity];
            count = 0;
        }

        public void AddPrinter(Printer printer)
        {
            if (count < printers.Length)
            {
                printers[count] = printer;
                count++;
            }
            else
            {
                Console.WriteLine("Контейнер принтера заполнен. Не удается добавить больше принтеров.");
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < count; i++)
            {
                printers[i].Print();
                Console.WriteLine();
            }
        }

        public void PrintDetailsAll()
        {
            for (int i = 0; i < count; i++)
            {
                printers[i].PrintDetails();
                Console.WriteLine();
            }
        }
    }
}
