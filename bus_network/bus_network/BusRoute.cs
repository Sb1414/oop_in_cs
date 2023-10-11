﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus_network
{
    public class BusRoute
    {
        public BusRoute NextRoute { get; set; }

        private Bus _head;
        private int _count;

        public int RouteNumber { get; }

        public BusRoute(int routeNumber)
        {
            RouteNumber = routeNumber;
        }

        public Bus[] GetAllBuses()
        {
            if (_head == null)
                return new Bus[0];

            Bus[] buses = new Bus[_count];
            Bus current = _head;
            for (int i = 0; i < _count; i++)
            {
                buses[i] = current;
                current = current.NextBus;
            }
            return buses;
        }

        public void AddBus(string licensePlate, string driverName)
        {
            Bus newBus = new Bus(licensePlate, driverName);

            if (!IsLicensePlateUnique(licensePlate))
            {
                throw new Exception("Госномер должен быть уникальным");
            }

            if (_head == null)
            {
                _head = newBus;
            }
            else
            {
                Bus current = _head;
                while (current.NextBus != _head)
                {
                    current = current.NextBus;
                }
                current.NextBus = newBus;
                newBus.NextBus = _head;
            }

            _count++;
        }

        public int CountBuses()
        {
            return _count;
        }

        public bool IsLicensePlateUnique(string licensePlate)
        {
            foreach (Bus bus in GetAllBuses())
            {
                if (bus.LicensePlate == licensePlate)
                    return false;
            }

            return true;
        }
    }
}
