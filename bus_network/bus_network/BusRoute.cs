using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus_network
{
    internal class BusRoute
    {
        public int RouteNumber { get; set; }
        public BusRoute Next { get; set; }  // ссылка на следующий маршрут в списке
        private Bus[] busArray;  // массив автобусов как очередь
        private int size;  // размер очереди
        private int front; // индекс начала очереди
        private int rear;  // индекс конца очереди

        public BusRoute(int routeNumber)
        {
            RouteNumber = routeNumber;
            Next = this;
            busArray = new Bus[10]; // начальный размер массива
            size = 0;
            front = 0;
            rear = -1;
        }

        public void AddBus(string licensePlate, string driverName)
        {
            if (size == busArray.Length)
            {
                // увеличение размера массива, если очередь переполнена
                Array.Resize(ref busArray, busArray.Length * 2);
            }

            rear = (rear + 1) % busArray.Length; // Циклическое добавление в массив
            busArray[rear] = new Bus(licensePlate, driverName);
            size++;
        }

        public void CombineWith(BusRoute otherRoute)
        {
            if (otherRoute != null)
            {
                int combinedSize = size + otherRoute.size;
                if (combinedSize > busArray.Length)
                {
                    // увеличение размера массива, если не хватает места
                    int newSize = Math.Max(busArray.Length * 2, combinedSize);
                    Array.Resize(ref busArray, newSize);
                }

                int otherSize = otherRoute.size;
                for (int i = 0; i < otherSize; i++)
                {
                    rear = (rear + 1) % busArray.Length; // циклическое добавление в массив
                    busArray[rear] = otherRoute.busArray[i];
                }

                size = combinedSize;
                otherRoute.size = 0; // очищаем другую очередь
            }
        }

        public void RemoveBus(string licensePlate)
        {
            for (int i = front, count = 0; count < size; i = (i + 1) % busArray.Length, count++)
            {
                if (busArray[i].LicensePlate == licensePlate)
                {
                    // если найден автобус, удаляем его из очереди
                    for (int j = i; j != rear; j = (j + 1) % busArray.Length)
                    {
                        busArray[j] = busArray[(j + 1) % busArray.Length];
                    }
                    rear = (rear - 1 + busArray.Length) % busArray.Length;
                    size--;
                    return;
                }
            }
        }
    }

}
