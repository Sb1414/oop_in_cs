using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_company
{
	internal class House
	{
		public string Address { get; set; }
		public Apartment Apartments { get; set; }

		public House(string address)
		{
			Address = address;
			Apartments = null;
		}

		// Метод для добавления квартиры в дом с упорядочиванием по номеру квартиры
		public void AddApartment(int number, double monthlyServiceFee)
		{
			Apartment newApartment = new Apartment(number, monthlyServiceFee);

			// Если список квартир пуст или новая квартира имеет номер меньший, чем текущая голова
			if (Apartments == null || number < Apartments.Number)
			{
				newApartment.NextApartment = Apartments;
				Apartments = newApartment;
			}
			else
			{
				Apartment currentApartment = Apartments;

				while (currentApartment.NextApartment != null && number > currentApartment.NextApartment.Number)
				{
					currentApartment = currentApartment.NextApartment;
				}

				newApartment.NextApartment = currentApartment.NextApartment;
				currentApartment.NextApartment = newApartment;
			}
		}

		// Метод для подсчета количества квартир в доме
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
	}

}
