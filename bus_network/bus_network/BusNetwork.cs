using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus_network
{
    public class BusNetwork
    {
        private BusRoute _head;

        public void AddRoute(int routeNumber)
        {
            BusRoute newRoute = new BusRoute(routeNumber);

            if (!IsRouteNumberUnique(routeNumber))
            {
                throw new Exception("Номер маршрута должен быть уникальным");
            }

            if (_head == null)
            {
                _head = newRoute;
                _head.NextRoute = _head;
            }
            else
            {
                BusRoute current = _head;
                while (current.NextRoute != _head)
                {
                    current = current.NextRoute;
                }
                current.NextRoute = newRoute;
                newRoute.NextRoute = _head;
                SortRoutes();
            }
        }

        private BusRoute[] GetRouteArray()
        {
            BusRoute[] routes = new BusRoute[CountRoutes()];

            BusRoute current = _head;
            for (int i = 0; i < routes.Length; i++)
            {
                routes[i] = current;
                current = current.NextRoute;
            }

            return routes;
        }

        private void SortRoutes()
        {
            BusRoute[] routes = GetRouteArray();

            // сортировка массива 
            Array.Sort(routes, (r1, r2) => r1.RouteNumber - r2.RouteNumber);

            // перезапись ссылок из отсортированного массива
            _head = routes[0];

            for (int i = 0; i < routes.Length - 1; i++)
            {
                routes[i].NextRoute = routes[i + 1];
            }

            routes[routes.Length - 1].NextRoute = _head;

        }

        public void AddBusToRoute(int routeNumber, string licensePlate, string driverName)
        {
            BusRoute targetRoute = FindRoute(routeNumber);
            if (targetRoute != null)
            {
                targetRoute.AddBus(licensePlate, driverName);
            }
        }

        // удаление маршрута
        public void RemoveRoute(int routeNumber)
        {
            if (_head == null)
                return;

            BusRoute current = _head;
            BusRoute prev = null;

            do
            {
                if (current.RouteNumber == routeNumber)
                {
                    // нашли элемент для удаления
                    if (_head.RouteNumber == routeNumber)
                    {
                        // сохраняем ссылку на текущий head
                        BusRoute removed = _head;

                        // первый элемент - ссылка на следующий
                        _head = _head.NextRoute;

                        // прикрепляем текущий head в конец
                        BusRoute tail = FindTail();
                        tail.NextRoute = removed;
                        removed.NextRoute = _head;

                        // удаляем все автобусы
                        removed.ClearBuses();

                        return;
                    }

                    // изменяем ссылку предыдущего элемента
                    if (prev != null)
                    {
                        prev.NextRoute = current.NextRoute;
                    }
                    else
                    {
                        // первый элемент, указываем хвост списка
                        _head = FindTail();
                    }

                    // перемещаем в конец списка  
                    AttachToTail(current);

                    // удаляем все автобусы
                    current.ClearBuses();

                    return;
                }

                prev = current;
                current = current.NextRoute;
            } while (current != _head);
        }

        // поиск последнего элемента списка 
        private BusRoute FindTail()
        {
            BusRoute current = _head;
            if (_head == null)
            {
                return null;
            }

            while (current.NextRoute != _head)
            {
                current = current.NextRoute;
            }

            return current;
        }

        // прикрепление маршрута в конец списка
        private void AttachToTail(BusRoute route)
        {
            BusRoute tail = FindTail();

            route.NextRoute = _head;
            tail.NextRoute = route;
        }

        public void RemoveBusFromRoute(int routeNumber)
        {
            BusRoute route = FindRoute(routeNumber);

            if (route != null)
            {
                route.RemoveBus();
            }
        }


        public BusRoute[] GetAllRoutes()
        {
            if (_head == null)
                return new BusRoute[0];

            BusRoute[] routes = new BusRoute[CountRoutes()];
            BusRoute current = _head;
            for (int i = 0; i < routes.Length; i++)
            {
                routes[i] = current;
                current = current.NextRoute;
            }
            return routes;
        }

        private BusRoute FindRoute(int routeNumber)
        {
            BusRoute current = _head;
            do
            {
                if (current.RouteNumber == routeNumber)
                    return current;

                current = current.NextRoute;
            }
            while (current != _head);

            return null;
        }

        public void ClearAllRoutes()
        {
            _head = null; // удаление всех маршрутов
        }

        public void ClearAllBuses()
        {
            BusRoute current = _head;
            while (current != null)
            {
                current.ClearBuses(); // очищаем автобусы в текущем маршруте
                current = current.NextRoute;
            }
        }


        private int CountRoutes()
        {
            if (_head == null)
                return 0;

            int count = 1;
            BusRoute current = _head;
            while (current.NextRoute != _head)
            {
                count++;
                current = current.NextRoute;
            }
            return count;
        }

        public int GetTotalBusesCount()
        {
            int count = 0;
            foreach (BusRoute route in GetAllRoutes())
            {
                count += route.CountBuses();
            }

            return count;
        }

        public Bus[] GetAllBusesOnRoute(int routeNumber)
        {
            BusRoute route = FindRoute(routeNumber);

            if (route == null)
            {
                return new Bus[0];
            }

            return route.GetAllBuses();
        }

        public bool IsRouteNumberUnique(int routeNumber)
        {
            foreach (BusRoute route in GetAllRoutes())
            {
                if (route.RouteNumber == routeNumber)
                    return false;
            }
            return true;
        }
    }

}
