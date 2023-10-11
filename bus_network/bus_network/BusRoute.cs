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
        public BusRoute Next { get; set; } // ссылка на следующий маршрут в списке
        public Bus FirstBus { get; set; }  // ссылка на первый автобус в маршруте

        public BusRoute(int routeNumber)
        {
            RouteNumber = routeNumber;
            Next = this;  // изначально маршрут ссылается сам на себя, создавая цикл
            FirstBus = null;  // изначально нет автобусов
        }

        public void AddBus(string licensePlate, string driverName)
        {
            Bus newBus = new Bus(licensePlate, driverName);
            if (FirstBus == null)
            {
                FirstBus = newBus;
                newBus.NextBus = newBus;  // автобус ссылается сам на себя
            }
            else
            {
                Bus lastBus = FirstBus;
                while (lastBus.NextBus != FirstBus)
                {
                    lastBus = lastBus.NextBus;
                }
                lastBus.NextBus = newBus;
                newBus.NextBus = FirstBus;  // новый автобус ссылается на первый
            }
        }

        public void CombineWith(BusRoute otherRoute)
        {
            if (otherRoute != null)
            {
                // последний узел текущего маршрута
                BusRoute lastNode = this;
                while (lastNode.Next != this)
                {
                    lastNode = lastNode.Next;
                }

                // объединяем маршруты
                lastNode.Next = otherRoute.Next;  // присоединяем другой маршрут к концу текущего
                if (FirstBus != null && otherRoute.FirstBus != null)
                {
                    Bus lastBus = FirstBus;
                    while (lastBus.NextBus != FirstBus)
                    {
                        lastBus = lastBus.NextBus;
                    }
                    lastBus.NextBus = otherRoute.FirstBus;  // обновляем связи для объединенных автобусов
                }
            }
        }

        public void RemoveBus(string licensePlate)
        {
            if (FirstBus != null)
            {
                if (FirstBus.LicensePlate == licensePlate)
                {
                    if (FirstBus.NextBus == FirstBus)
                    {
                        FirstBus = null;  // если был только один автобус, удаляем его
                    }
                    else
                    {
                        FirstBus = FirstBus.NextBus;  // перемещаем начало списка
                    }
                }
                else
                {
                    Bus currentBus = FirstBus;
                    while (currentBus.NextBus != FirstBus)
                    {
                        if (currentBus.NextBus.LicensePlate == licensePlate)
                        {
                            currentBus.NextBus = currentBus.NextBus.NextBus;  // удаляем автобус из середины списка
                            return;
                        }
                        currentBus = currentBus.NextBus;
                    }
                }
            }
        }
    }
}
