using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cargo_transportation
{
    internal class TransportQueue
    {
        private Vehicle[] vehicles;
        private int count;
        private int capacity;
        private int head; // Индекс начала очереди
        private int tail; // Индекс конца очереди

        public TransportQueue(int capacity)
        {
            vehicles = new Vehicle[capacity];
            count = 0;
            this.capacity = capacity;
            head = 0;
            tail = 0;
        }

        public int Count()
        {
            return count;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public void Clear()
        {
            while (count > 0)
            {
                RemoveVehicle();
            }
        }

        public void AddVehicle(string licensePlate, string driverSurname)
        {
            try
            {
                if (count == capacity)
                {
                    // удаление первого из очереди
                    Vehicle removedVehicle = vehicles[head];
                    head = (head + 1) % capacity;
                    count--;

                    Console.WriteLine($"Автомобиль {removedVehicle.LicensePlate} был удален из очереди.");
                }

                Vehicle vehicle = new Vehicle(licensePlate, driverSurname);
                vehicles[tail] = vehicle;
                tail = (tail + 1) % capacity; // Обновление индекса конца очереди
                count++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении автомобиля: {ex.Message}");
            }
        }

        public void RemoveVehicle()
        {
            if (count > 0)
            {
                Vehicle removedVehicle = vehicles[head];
                // Удаление всех рейсов связанных с удаленной машиной
                removedVehicle.ClearShipments();
                // сдвиг
                for (int i = 0; i < count - 1; i++)
                {
                    int current = (head + i) % vehicles.Length;
                    int next = (head + i + 1) % vehicles.Length;
                    vehicles[current] = vehicles[next];
                }

                tail = (tail - 1 + vehicles.Length) % vehicles.Length;
                count--;

            }
        }

        public bool IsLicensePlateExists(string licensePlate)
        {
            for (int i = 0; i < count; i++)
            {
                int index = (head + i) % capacity;
                if (vehicles[index].LicensePlate == licensePlate)
                {
                    return true;
                }
            }

            return false;
        }


        public void AddShipmentToVehicle(string licensePlate, string startTime, double cargoVolume)
        {
            Vehicle vehicle = FindVehicle(licensePlate);

            if (vehicle != null)
            {
                try
                {
                    Shipment shipment = new Shipment { StartTime = startTime, CargoVolume = cargoVolume };
                    vehicle.AddShipment(shipment);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при добавлении рейса для автомобиля: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Автомобиль не найден");
            }
        }

        public void RemoveShipment(string licensePlate, string startTime, double cargoVolume)
        {
            Vehicle vehicle = FindVehicle(licensePlate);

            if (vehicle != null)
            {
                Shipment[] shipments = vehicle.GetShipments();

                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i].StartTime == startTime && shipments[i].CargoVolume == cargoVolume)
                    {
                        vehicle.RemoveShipment(i);
                        return; // Выход из метода после удаления рейса
                    }
                }
            }
            else
            {
                Console.WriteLine("Автомобиль не найден");
            }
        }


        public double GetTotalCargoVolume(Vehicle vehicle)
        {
            Shipment[] shipments = vehicle.GetShipments();
            double totalCargoVolume = 0;
            if (shipments != null)
            {
                foreach (Shipment shipment in shipments)
                {
                    totalCargoVolume += shipment.CargoVolume;
                }
            }
            return totalCargoVolume;
        }

        public double CalculateTotalCargoVolume()
        {
            double totalCargoVolume = 0;
            for (int i = 0; i < count; i++)
            {
                int index = (head + i) % capacity;
                totalCargoVolume += GetTotalCargoVolume(vehicles[index]);
            }
            return totalCargoVolume;
        }

        public Shipment[] GetShipments(string licensePlate)
        {
            Vehicle vehicle = FindVehicle(licensePlate);

            if (vehicle != null)
            {
                return vehicle.GetShipments();
            }
            else
            {
                Console.WriteLine("Автомобиль не найден");
                return null;
            }
        }

        public Vehicle[] GetAllVehicles()
        {
            Vehicle[] allVehicles = new Vehicle[count];
            int index = 0;

            for (int i = 0; i < count; i++)
            {
                int currentIndex = (head + i) % capacity;
                allVehicles[index] = vehicles[currentIndex];
                index++;
            }

            return allVehicles;
        }

        public Vehicle FindVehicle(string licensePlate)
        {
            for (int i = 0; i < count; i++)
            {
                int index = (head + i) % capacity; // Вычисление индекса текущего элемента
                if (vehicles[index].LicensePlate == licensePlate)
                {
                    return vehicles[index];
                }
            }

            return null;
        }

    }

}
