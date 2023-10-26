using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_company
{
	internal class Apartment // класс, представляющий квартиру
	{
		public int Number { get; set; }
		public double MonthlyServiceFee { get; set; }
		public Apartment NextApartment { get; set; }

		public Apartment(int number, double monthlyServiceFee)
		{
			Number = number;
			MonthlyServiceFee = monthlyServiceFee;
			NextApartment = null;
		}
	}
}
