using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementCompany
{
    internal class HouseList : IEnumerable<House>
    {
        private HouseNode head;
        private int count;

        public int Count => count;

        private class HouseNode
        {
            public House House { get; }
            public ApartmentsList Apartments { get; } // Добавляем список квартир к каждому дому

            public HouseNode(House house)
            {
                House = house;
                Apartments = new ApartmentsList();
            }

            public HouseNode NextHouse { get; set; }
        }

        public void AddHouse(House house)
        {
            if (head == null)
            {
                head = new HouseNode(house);
            }
            else
            {
                HouseNode current = head;
                while (current.NextHouse != null)
                {
                    current = current.NextHouse;
                }
                current.NextHouse = new HouseNode(house);
            }
            count++;
        }

        public void RemoveHouse(string street, int numberHouse)
        {
            HouseNode current = head;
            HouseNode prev = null;
            while (current != null)
            {
                if (current.House.GetStreet() == street && current.House.GetNumberHouse() == numberHouse)
                {
                    current.Apartments.Clear();
                    if (prev == null)
                    {
                        head = current.NextHouse;
                    }
                    else
                    {
                        prev.NextHouse = current.NextHouse;
                    }
                    count--;
                    break;
                }
                prev = current;
                current = current.NextHouse;
            }
        }

        public int GetApartmentCountInHouse(string street, int numberHouse)
        {
            HouseNode current = head;
            while (current != null)
            {
                if (current.House.GetStreet() == street && current.House.GetNumberHouse() == numberHouse)
                {
                    return current.Apartments.GetCount();
                }
                current = current.NextHouse;
            }
            return 0;
        }

        public bool HouseExists(string street, int houseNumber)
        {
            HouseNode current = head;
            while (current != null)
            {
                if (current.House.GetStreet() == street && current.House.GetNumberHouse() == houseNumber)
                {
                    return true;
                }
                current = current.NextHouse;
            }
            return false;
        }


        public void RemoveAllHouses()
        {
            head = null;
            count = 0;
        }

        public void RemoveAllApartments()
        {
            HouseNode current = head;
            while (current != null)
            {
                current.Apartments.Clear();
                current = current.NextHouse;
            }
        }

        public void RemoveApartmentByNumber(int apartmentNumber)
        {
            HouseNode current = head;
            while (current != null)
            {
                current.Apartments.RemoveApartmentByNumber(apartmentNumber);
                current = current.NextHouse;
            }
        }

        public House FindHouse(string street, int numberHouse)
        {
            HouseNode current = head;
            while (current != null)
            {
                if (current.House.GetStreet() == street && current.House.GetNumberHouse() == numberHouse)
                {
                    return current.House;
                }
                current = current.NextHouse;
            }
            return null;
        }
        
        public bool ContainsNumber(int number)
        {
            HouseNode current = head;
            while (current != null)
            {
                if (current.House.GetNumberHouse() == number)
                {
                    return true;
                }
                current = current.NextHouse;
            }
            return false;
        }

        public int GetCountByNumber(int number)
        {
            HouseNode current = head;
            while (current != null)
            {
                if (current.House.GetNumberHouse() == number)
                {
                    return current.House.SizeApart;
                }
                current = current.NextHouse;
            }
            return -1;
        }

        public void AddApartmentToHouse(string street, int numberHouse, Apartment apartment)
        {
            HouseNode houseNode = FindHouseNode(street, numberHouse);
            if (houseNode != null)
            {
                houseNode.Apartments.AddApartment(apartment);
            }
            else
            {
                throw new ArgumentException("Дом не найден");
            }
        }

        private HouseNode FindHouseNode(string street, int numberHouse)
        {
            HouseNode current = head;
            while (current != null)
            {
                if (current.House.GetStreet() == street && current.House.GetNumberHouse() == numberHouse)
                {
                    return current;
                }
                current = current.NextHouse;
            }
            return null;
        }

        public int GetTotalPaymentByHouse(string street, int numberHouse)
        {
            HouseNode houseNode = FindHouseNode(street, numberHouse);
            if (houseNode != null)
            {
                int totalPayment = Convert.ToInt32(houseNode.Apartments.GetTotalPayments());
                return totalPayment;
            }
            else
            {
                return 0;
            }
        }


        public IEnumerable<House> GetAllHousesByStreet(string street)
        {
            HouseNode current = head;
            while (current != null)
            {
                if (current.House.GetStreet() == street)
                {
                    yield return current.House;
                }
                current = current.NextHouse;
            }
        }

        public Apartment[] GetAllApartments(string street, int numberHouse)
        {
            HouseNode houseNode = FindHouseNode(street, numberHouse);
            if (houseNode != null)
            {
                Apartment[] apartments = houseNode.Apartments.GetAllApartments();
                return apartments.ToArray();
            }
            else
            {
                // Возвращаем пустой массив, если дом не найден
                return new Apartment[0];
            }
        }

        public IEnumerator<House> GetEnumerator()
        {
            HouseNode current = head;
            while (current != null)
            {
                yield return current.House;
                current = current.NextHouse;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
