using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus_network
{
    internal class BusNetwork
    {
        private BusRoute[] routes;  // динамический массив ссылок на маршруты
        private int count;  // количество маршрутов в сети

        public BusNetwork()
        {
            routes = new BusRoute[10];  // изначальный размер массива
            count = 0;  // начальное количество маршрутов
        }

        public void AddRoute(int routeNumber)
        {
            if (count == routes.Length)
            {
                // расширяем массив, если не хватает места
                Array.Resize(ref routes, routes.Length * 2);
            }
            routes[count] = new BusRoute(routeNumber);
            count++;
        }

        public void AddBusToRoute(int routeNumber, string licensePlate, string driverName)
        {
            BusRoute route = FindRoute(routeNumber);
            if (route != null)
            {
                route.AddBus(licensePlate, driverName);
            }
        }

        public void CombineRoutes(int routeNumber1, int routeNumber2)
        {
            BusRoute route1 = FindRoute(routeNumber1);
            BusRoute route2 = FindRoute(routeNumber2);

            if (route1 != null && route2 != null)
            {
                route1.CombineWith(route2);

                // удаляем route2 из массива, сдвигая элементы влево
                int index2 = Array.IndexOf(routes, route2);
                for (int i = index2; i < count - 1; i++)
                {
                    routes[i] = routes[i + 1];
                }
                count--;
            }
        }

        private BusRoute FindRoute(int routeNumber)
        {
            return Array.Find(routes, r => r != null && r.RouteNumber == routeNumber);
        }
    }

}
