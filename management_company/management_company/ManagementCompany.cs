using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace management_company
{
	internal class ManagementCompany
	{
		private House[] houses; // Динамический массив для хранения домов
		private int front;      // Индекс начала очереди
		private int rear;       // Индекс конца очереди
		private int capacity;   // Вместимость очереди
		private int count;      // Текущее количество элементов в очереди

		public ManagementCompany(int capacity)
		{
			houses = new House[capacity];
			front = 0;
			rear = -1;
			this.capacity = capacity;
			count = 0;
		}

		// Добавить дом в очередь
		public void AddHouse(House house)
		{
			if (count == capacity)
			{
				// Если очередь полна, увеличиваем ее размер
				ResizeQueue();
			}

			rear = (rear + 1) % capacity;
			houses[rear] = house;
			count++;
		}

		// Извлечь дом из очереди
		public House DeleteHouse()
		{
			if (count == 0)
			{
				throw new InvalidOperationException("Очередь пуста.");
			}

			House house = houses[front];
			front = (front + 1) % capacity;
			count--;

			return house;
		}

		// метод для удаления квартиры из указанного дома
		public void RemoveApartmentFromHouse(string address, int apartmentNumber)
		{
			try
			{
				House house = FindHouseByAddress(address);

				if (house != null)
				{
					house.RemoveApartment(apartmentNumber);
				}
				else
				{
					// обработка случая, когда дом не найден
					throw new  Exception("дом не найден");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}");
			}
			
		}

		// Увеличение размера очереди при необходимости
		private void ResizeQueue()
		{
			int newCapacity = capacity * 2;
			House[] newHouses = new House[newCapacity];

			for (int i = 0; i < count; i++)
			{
				newHouses[i] = houses[(front + i) % capacity];
			}

			houses = newHouses;
			front = 0;
			rear = count - 1;
			capacity = newCapacity;
		}

		// Метод для получения всех домов
		public House[] GetAllHouses()
		{
			House[] allHouses = new House[count];
			int index = 0;

			for (int i = front; i <= rear; i++)
			{
				allHouses[index] = houses[i];
				index++;
			}

			return allHouses;
		}

		// Метод для получения общего числа квартир
		public int GetTotalApartsCount()
		{
			int totalApartsCount = 0;

			for (int i = front; i <= rear; i++)
			{
				totalApartsCount += houses[i].CountAparts();
			}

			return totalApartsCount;
		}

		// метод для добавления квартиры в дом по адресу
		public void AddApartToHouse(string address, int number, double monthlyServiceFee)
		{
			House house = FindHouseByAddress(address);

			if (house != null)
			{
				house.AddApartment(number, monthlyServiceFee);
			}
			else
			{
				// обработка случая, когда дом не найден
				Console.WriteLine("Дом с указанным адресом не найден.");
			}
		}

		public House FindHouseByAddress(string address)
		{
			for (int i = front; i <= rear; i++)
			{
				if (houses[i].Address == address)
				{
					return houses[i];
				}
			}

			return null; // дом с указанным адресом не найден
		}

		// метод для получения всех квартир в указанном доме
		public Apartment[] GetAllApartsOnHouse(string address)
		{
			House house = FindHouseByAddress(address);

			if (house != null)
			{
				Apartment[] apartments = house.GetAllApartments();
				return apartments;
			}
			else
			{
				// Обработка случая, когда дом не найден
				Console.WriteLine("Дом с указанным адресом не найден.");
				return new Apartment[0]; // Возвращаем пустой массив
			}
		}

		// метод для очистки всех домов
		public void ClearAllHouses()
		{
			front = 0;
			rear = -1;
			count = 0;
			houses = new House[capacity];
		}

		// метод для очистки всех квартир
		public void ClearAllAparts()
		{
			for (int i = front; i <= rear; i++)
			{
				houses[i].Apartments = null;
			}
		}

		// метод для проверки уникальности адреса
		public bool IsAddressUnique(string address)
		{
			foreach (var house in houses)
			{
				if (house != null && house.Address == address)
				{
					return false; // адрес уже существует
				}
			}
			return true; // адрес уникален
		}

	}

}
