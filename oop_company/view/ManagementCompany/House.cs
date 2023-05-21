using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementCompany
{
    internal class House
    {
        public House NextHouse { get; set; } // Ссылка на следующий элемент списка
        private int NumberHouse { get; set; } //Hомер дом
        private string Street { get; set; } //Haзвание улишы
        public int SizeApart { get; set; } // Количество квартир которое помещается в доме
        public ApartmentsList apartmentsList;
        public string AdressStreet
        {
            get
            {
                string str = Street + " " + NumberHouse;
                return str;
            }

            private set { }
        }

        // Конструктор
        public House(string street, int numberHouse, int sizeApart)
        {
            this.Street = street;
            this.NumberHouse = numberHouse;
            this.apartmentsList = new ApartmentsList(sizeApart);
            this.SizeApart = sizeApart;
            this.NextHouse = null;
        } 
        
        //Добавление квартиpы
        public void AddApart(int numberApart, int payment)
        {
            Apartment apartment = new Apartment(numberApart, payment);
            apartmentsList.AddApartment(apartment);
        }
        
        
        //Yдаление квартиры
        public void DelApart(int numberApart)
        {
            try
            {
                apartmentsList.RemoveApartment(numberApart);
                SizeApart--;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } 
        public Apartment SearchApartment(int number)
        {
            try
            {
                return apartmentsList.FindApartment(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        } //Метод поиска квартиры по номеру

        public int SumPayment()
        {
            return (int)apartmentsList.GetTotalPayments();
        } // Сумма выплат по всем квартирам

        public void PrintHouseInfo()
        {
            Console.WriteLine("Адрес дома: " + AdressStreet);
            Console.WriteLine("Количество квартир: " + SizeApart);
            apartmentsList.PrintApartmentsList();
        }

    }
}
