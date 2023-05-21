using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class ManagementCompany
    {
        private House house{get; set; } //Ссылка на первый элемент очереди
        public int CountHouse{get; private set; } //Количество домов в очереди
        public ManagementCompany() {
            this.CountHouse = 0;
        }
        public void AddHouse(string StreetName, int NumberHouse, int countApartment)
        {
            House newHouse = new House(StreetName, NumberHouse, countApartment);
            if (house == null)
            {
                house = newHouse;
            }
            else
            {
                House lastHouse = house;
                while (lastHouse.NextHouse != null)
                {
                    lastHouse = lastHouse.NextHouse;
                }
                lastHouse.NextHouse = newHouse;
            }
            CountHouse++;
        } //Добавление дома в очередь
        public void DelHouse()
        {
            if (house == null)
            {
                Console.WriteLine("нет домов");
                return;
            }
            if (house.NextHouse == null)
            {
                house = null;
                CountHouse--;
                return;
            }
            House prevHouse = house;
            while (prevHouse.NextHouse != null && prevHouse.NextHouse.NextHouse != null)
            {
                prevHouse = prevHouse.NextHouse;
            }
            prevHouse.NextHouse = null;
            CountHouse--;
        } //Удаление дома из очереди
        public House SearchHouse(string streetName, int numberHouse) //Поиск дома по адресу (названию улицы и номеру дома)
        {
            House currentHouse = house;
            while (currentHouse != null)
            {
                if (currentHouse.AdressStreet == $"{streetName} {numberHouse}")
                {
                    return currentHouse;
                }
                currentHouse = currentHouse.NextHouse;
            }
            return null;
        } 
        public void Printinformation() {
            House currentHouse = house;
            while (currentHouse != null)
            {
                Console.WriteLine($"Адрес дома: {currentHouse.AdressStreet}");
                Console.WriteLine($"Количество квартир: {currentHouse.SizeApart}");
                Console.WriteLine($"Количество квартир с выплатами: {currentHouse.apartmentsList.GetCount()}");
                Console.WriteLine("--------------------------------------------------");
                currentHouse = currentHouse.NextHouse;
            }
            
        } // Вывод информации (Тестовый для консоли)

    }
}
