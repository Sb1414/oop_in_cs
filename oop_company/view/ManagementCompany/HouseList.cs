using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementCompany
{
    internal class HouseList
    {
        private House head;
        private int count;

        public int Count => count;

        public void AddHouse(House house)
        {
            if (head == null)
            {
                head = house;
            }
            else
            {
                House current = head;
                while (current.NextHouse != null)
                {
                    current = current.NextHouse;
                }
                current.NextHouse = house;
            }
            count++;
        }

        public void RemoveHouse(House house)
        {
            House current = head;
            House prev = null;
            while (current != null)
            {
                if (current == house)
                {
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

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public House FindHouse(string street, int numberHouse)
        {
            House current = head;
            while (current != null)
            {
                if (current.GetStreet() == street && current.GetNumberHouse() == numberHouse)
                {
                    return current;
                }
                current = current.NextHouse;
            }
            return null;
        }

        public bool ContainsNumber(int number)
        {
            House current = head;
            Console.WriteLine(" = = = = = = = ЧЕЛ, я ТУТ ", current.ToString());
            while (current != null)
            {
                Console.WriteLine(current.GetStreet() + " " + current.GetNumberHouse());
                if (current.GetNumberHouse() == number)
                {
                    return true;
                }
                current = current.NextHouse;
            }
            return false;
        }

    }
}
