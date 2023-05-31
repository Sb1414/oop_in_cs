using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cargo_transportation
{
    // Класс, представляющий автомобиль
    // Класс, представляющий автомобиль
    internal class Vehicle
    {
        public string LicensePlate { get; set; }
        public string DriverSurname { get; set; }
        private Shipment[] shipments;

        public Vehicle(string licensePlate, string driverSurname)
        {
            LicensePlate = licensePlate;
            DriverSurname = driverSurname;
            shipments = new Shipment[0];
        }

        // Добавить рейс для автомобиля
        public void AddShipment(Shipment shipment)
        {
            Array.Resize(ref shipments, shipments.Length + 1);
            shipments[shipments.Length - 1] = shipment;
        }

        public void RemoveShipment(int index)
        {
            if (index >= 0 && index < shipments.Length)
            {
                for (int i = index; i < shipments.Length - 1; i++)
                {
                    shipments[i] = shipments[i + 1];
                }

                Array.Resize(ref shipments, shipments.Length - 1);
            }
            else
            {
                throw new ArgumentOutOfRangeException("index", "индекс за пределами массива");
            }
        }

        public void ClearShipments()
        {
            shipments = new Shipment[0];
        }

        // Получить все рейсы для автомобиля
        public Shipment[] GetShipments()
        {
            return shipments;
        }
    }
}
