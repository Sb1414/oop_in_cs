using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_company
{
	internal class House
	{
		public string Address { get; set; } // адрес
		public Apartment Apartments { get; set; }
		public double TotalPayments { get; set; } // поле для хранения суммы всех выплат


		public House(string address)
		{
			Address = address;
			Apartments = null;
			TotalPayments = 0.0; // инициализируем сумму выплат
		}

		// метод для добавления квартиры в дом с упорядочиванием по номеру квартиры
		public void AddApartment(int number, double monthlyServiceFee)
		{
			Apartment newApartment = new Apartment(number, monthlyServiceFee);

			// обновляем сумму выплат при добавлении новой квартиры
			TotalPayments += monthlyServiceFee;

			if (Apartments == null)
			{
				// если список пуст, устанавливаем новую квартиру как заголовок
				Apartments = newApartment;
				return;
			}

			Apartment current = Apartments;
			while (current.NextApartment != null)
			{
				if (number <= current.NextApartment.Number)
				{
					// Вставляем новую квартиру перед квартирой с большим номером
					newApartment.NextApartment = current.NextApartment;
					current.NextApartment = newApartment;
					return;
				}
				current = current.NextApartment;
			}
			
			// если новая квартира имеет номер больше, чем все имеющиеся квартиры, добавляем ее в конец списка
			current.NextApartment = newApartment;
		}

		// метод для подсчета количества квартир в доме
		public int CountAparts()
		{
			int count = 0;
			Apartment currentApartment = Apartments;

			while (currentApartment != null)
			{
				count++;
				currentApartment = currentApartment.NextApartment;
			}

			return count;
		}

		// метод для подсчета суммы всех выплат по квартирам в доме
		public double TotalCount()
		{
			return TotalPayments;
		}

		// метод для получения всех квартир в доме
		public Apartment[] GetAllApartments()
		{
			List<Apartment> apartmentList = new List<Apartment>();
			Apartment currentApartment = Apartments;

			while (currentApartment != null)
			{
				apartmentList.Add(currentApartment);
				currentApartment = currentApartment.NextApartment;
			}

			return apartmentList.ToArray();
		}

		// метод для удаления квартиры по номеру
		public void RemoveApartment(int apartmentNumber)
		{
			if (Apartments == null)
			{
				return; // нет квартир для удаления
			}

			// если первая квартира имеет заданный номер, удаляем ее
			if (Apartments.Number == apartmentNumber)
			{
				Apartments = Apartments.NextApartment;
				return;
			}

			// иначе ищем квартиру для удаления
			Apartment currentApartment = Apartments;
			while (currentApartment.NextApartment != null)
			{
				if (currentApartment.NextApartment.Number == apartmentNumber)
				{
					TotalPayments -= currentApartment.NextApartment.MonthlyServiceFee; // минусуем выплаты по удаляемой квартире из общих
					currentApartment.NextApartment = currentApartment.NextApartment.NextApartment;
					return;
				}
				currentApartment = currentApartment.NextApartment;
			}
		}
	}
}
