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
            }
        }

        public void AddBusToRoute(int routeNumber, string licensePlate, string driverName)
        {
            BusRoute targetRoute = FindRoute(routeNumber);
            if (targetRoute != null)
            {
                targetRoute.AddBus(licensePlate, driverName);
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
