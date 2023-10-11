using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus_network
{
    internal class BusNetwork
    {
        private BusRoute firstRoute;  // ссылка на первый маршрут в списке

        public BusNetwork()
        {
            firstRoute = null;  // изначально нет маршрутов
        }

        public void AddRoute(int routeNumber)
        {
            BusRoute newRoute = new BusRoute(routeNumber);

            if (firstRoute == null || routeNumber < firstRoute.RouteNumber)
            {
                // если список пуст или новый маршрут должен быть первым
                newRoute.Next = firstRoute;
                firstRoute = newRoute;
            }
            else
            {
                BusRoute currentRoute = firstRoute;
                while (currentRoute.Next != null && currentRoute.Next.RouteNumber < routeNumber)
                {
                    currentRoute = currentRoute.Next;
                }
                newRoute.Next = currentRoute.Next;
                currentRoute.Next = newRoute;
            }
        }


        public void CombineRoutes(int routeNumber1, int routeNumber2)
        {
            BusRoute route1 = FindRoute(routeNumber1);
            BusRoute route2 = FindRoute(routeNumber2);

            if (route1 != null && route2 != null)
            {
                route1.CombineWith(route2);

                // удаление route2 из списка
                if (route2 == firstRoute)
                {
                    firstRoute = route2.Next;  // обновляем firstRoute, если необходимо
                }
                BusRoute currentRoute = firstRoute;
                while (currentRoute.Next != firstRoute && currentRoute.Next != route2)
                {
                    currentRoute = currentRoute.Next;
                }
                currentRoute.Next = route2.Next;
            }
        }

        private BusRoute FindRoute(int routeNumber)
        {
            if (firstRoute == null)
            {
                return null;
            }

            BusRoute currentRoute = firstRoute;

            do
            {
                if (currentRoute.RouteNumber == routeNumber)
                {
                    return currentRoute;
                }
                currentRoute = currentRoute.Next;
            } while (currentRoute != firstRoute);

            return null;
        }

        public BusRoute[] GetAllRoutes()
        {
            if (firstRoute == null)
            {
                return new BusRoute[0]; // возвращаем пустой массив, если нет маршрутов
            }

            List<BusRoute> routesList = new List<BusRoute>();
            BusRoute currentRoute = firstRoute;

            while (currentRoute != null)
            {
                routesList.Add(currentRoute);
                currentRoute = currentRoute.Next;
            }

            return routesList.ToArray();
        }

    }

}
