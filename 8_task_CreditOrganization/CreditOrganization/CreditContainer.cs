using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreditOrganization
{
    internal class CreditContainer
    {
        private Credit[] credits;
        private int count;
        private int capacity;

        public CreditContainer(int initialCapacity)
        {
            credits = new Credit[initialCapacity];
            capacity = initialCapacity;
            count = 0;
        }

        public int printCount()
        {
            return count;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public void AddCredit(Credit credit)
        {
            if (count >= capacity)
            {
                Console.WriteLine("Увеличьте размер массива, он переполнен!");
                return;
            }

            credits[count] = credit;
            count++;
        }

        public void IncreaseCapacity(int additionalCapacity)
        {
            int newCapacity = capacity + additionalCapacity;
            Credit[] newCredit = new Credit[newCapacity];
            Array.Copy(credits, newCredit, capacity);
            credits = newCredit;
            capacity = newCapacity;
        }

        private void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Некорректный индекс.");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                credits[i] = credits[i + 1];
            }

            credits[count - 1] = null;
            count--;
        }

        public void RemoveCredit(Credit credit)
        {
            for (int i = 0; i < count; i++)
            {
                if (credits[i] == credit)
                {
                    for (int j = i; j < count; j++)
                    {
                        credits[j] = credits[j + 1];
                    }

                    credits[count - 1] = null;
                    count--;
                    return;
                }
            }
            Console.WriteLine("Кредит не найден в контейнере.");
        }

        public void RemoveMortgageCredit(string address)
        {
            for (int i = 0; i < count; i++)
            {
                if (credits[i] is MortgageCredit credit && credit.Address == address)
                {
                    RemoveAt(i);
                    return;
                }
            }

            Console.WriteLine("Такой кредит не найден.");
        }

        public void RemoveAutoCredit(string carBrand)
        {
            for (int i = 0; i < count; i++)
            {
                if (credits[i] is AutoCredit credit && credit.CarBrand == carBrand)
                {
                    RemoveAt(i);
                    return;
                }
            }

            Console.WriteLine("Такой кредит не найден.");
        }

        public void DisplayAllCredits()
        {
            for (int i = 0; i < count; i++)
            {
                credits[i].DisplayData();
                Console.WriteLine();
            }
        }
    }
}
