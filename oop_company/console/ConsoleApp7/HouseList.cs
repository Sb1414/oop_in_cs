using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class ApartmentsList
    {
        private Apartment[] apartments;
        private int size;
        private int count;

        public ApartmentsList(int size)
        {
            this.apartments = new Apartment[size];
            this.size = size;
            this.count = 0;
        }

        public int GetCount()
        {
            return count;
        }

        public void AddApartment(Apartment apartment)
        {
            if (count >= size)
            {
                throw new Exception("Количество квартир в доме превышает допустимое значение.");
            }
            if (count == 0)
            {
                apartments[0] = apartment;
            }
            else
            {
                int i = count - 1;
                while (i >= 0 && apartments[i].Number > apartment.Number)
                {
                    apartments[i + 1] = apartments[i];
                    i--;
                }
                apartments[i + 1] = apartment;
            }
            count++;
        }

        public void RemoveApartment(int numberApart)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (apartments[i].Number == numberApart)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                for (int i = index; i < count - 1; i++)
                {
                    apartments[i] = apartments[i + 1];
                }
                count--;
            }
            else
            {
                throw new Exception("Квартиры с таким номером не существует.");
            }
        }

        public Apartment FindApartment(int numberApart)
        {
            for (int i = 0; i < count; i++)
            {
                if (apartments[i].Number == numberApart)
                {
                    return apartments[i];
                }
            }
            return null;
        }

        public decimal GetTotalPayments()
        {
            decimal total = 0;
            for (int i = 0; i < count; i++)
            {
                total += apartments[i].Payment;
            }
            return total;
        }

        public void PrintApartmentsList()
        {
            foreach (Apartment apartment in apartments)
            {
                if (apartment != null)
                {
                    Console.WriteLine("Номер квартиры: " + apartment.Number);
                    Console.WriteLine("Выплата: " + apartment.Payment);
                }
            }
        }
    }

}
