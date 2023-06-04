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

        public CreditContainer()
        {
            credits = new Credit[4];
            count = 0;
        }

        public int printCount()
        {
            return count;
        }

        public void AddCredit(Credit credit)
        {
            if (count >= credits.Length)
            {
                IncreaseCapacity();
            }
            credits[count] = credit;
            count++;
        }

        private void IncreaseCapacity()
        {
            int newCapacity = credits.Length * 2;
            Credit[] newCredit = new Credit[newCapacity];
            Array.Copy(credits, newCredit, count);
            credits = newCredit;
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
            int index = Array.IndexOf(credits, credit);
            if (index >= 0)
            {
                RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Кредит не найден в контейнере.");
            }
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
