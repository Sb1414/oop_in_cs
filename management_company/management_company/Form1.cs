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
				}

				textBoxAdress.Clear();
			}
			labelTotalCountApart.Text = "общее число квартир: " + managementCompany.GetTotalApartsCount();
		}
	}
}
