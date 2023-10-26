using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace management_company
{
	public partial class Form1 : Form
	{
		ManagementCompany managementCompany = new ManagementCompany(3);
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonAddHouse_Click(object sender, EventArgs e)
		{
			try
			{
				if (textBoxAdress.Text == "")
				{
					MessageBox.Show("Введите адрес");
					return;
				}

				if (!Regex.IsMatch(textBoxAdress.Text, @"^[A-Za-zА-Яа-я\s]+\s\d+$"))
				{
					MessageBox.Show("Адрес должен содержать буквы (название улицы) и число (номер дома)\n\n" +
						"Например: Чуйкова 20");
					return;
				}
				// добавление дома
				House house = new House(textBoxAdress.Text);
				managementCompany.AddHouse(house);
				UpdateGrids();

			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}");
			}
		}

		private void UpdateGrids()
		{
			// очистка DataGridView перед обновлением
			dataGridViewHouses.Rows.Clear();

			// массив домов из 
			House[] houses = managementCompany.GetAllHouses();
			if (houses.Length > 0)
			{
				// установка количества строк в DataGridView равным количеству домов
				dataGridViewHouses.RowCount = houses.Length;

				// заполнение DataGridView
				for (int i = 0; i < houses.Length; i++)
				{
					dataGridViewHouses.Rows[i].Cells[0].Value = houses[i].Address;
					dataGridViewHouses.Rows[i].Cells[1].Value = houses[i].CountAparts();
					dataGridViewHouses.Rows[i].Cells[2].Value = houses[i].TotalCount();
				}

				textBoxAdress.Clear();
			}
			labelTotalCountApart.Text = "общее число квартир: " + managementCompany.GetTotalApartsCount();
		}

		private void buttonAddApart_Click(object sender, EventArgs e)
		{
			try
			{
				DataGridViewRow currentRow = dataGridViewHouses.CurrentRow;

				if (dataGridViewHouses.CurrentRow != null)
				{
					// получаем адрес дома из выбранной строки таблицы
					string address = currentRow.Cells[0].Value?.ToString();

					int apartmentNumber = (int)numericUpDownNumApart.Value;

					// проверяем уникальность номера квартиры
					if (!IsApartmentNumberUnique(address, apartmentNumber))
					{
						MessageBox.Show("Номер квартиры должен быть уникальным, такой номер уже используется");
						return;
					}

					// получаем адрес дома из выбранной строки таблицы
					string adress = currentRow.Cells[0].Value?.ToString();

					// добавляем квартиру в выбранный дом
					managementCompany.AddApartToHouse(adress, apartmentNumber, Convert.ToDouble(textBoxPrice.Text));

					// очищаем текстовое поле
					textBoxPrice.Clear();

					// массив квартир у дома
					Apartment[] aparts = managementCompany.GetAllApartsOnHouse(adress);

					// установка количества строк в DataGridView равным количеству квартир
					dataGridViewApartments.RowCount = aparts.Length;

					// заполнение DataGridView
					for (int i = 0; i < aparts.Length; i++)
					{
						dataGridViewApartments.Rows[i].Cells[0].Value = aparts[i].Number;
						dataGridViewApartments.Rows[i].Cells[1].Value = aparts[i].MonthlyServiceFee;
					}
					UpdateGrids();
				}
				else
				{
					MessageBox.Show("Не выбран дом, к которому нужно добавить квартиру");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}");
			}
		}

		private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // отмена ввода, если символ не является цифрой
			}
		}

		// метод для проверки уникальности номера квартиры в указанном доме
		private bool IsApartmentNumberUnique(string address, int apartmentNumber)
		{
			House house = managementCompany.FindHouseByAddress(address);

			if (house != null)
			{
				Apartment[] apartments = house.GetAllApartments();

				foreach (Apartment apartment in apartments)
				{
					if (apartment.Number == apartmentNumber)
					{
						return false; // номер квартиры уже используется
					}
				}
			}

			return true; // номер квартиры уникален
		}

	}
}
