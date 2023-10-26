using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

				string address = textBoxAdress.Text;

				// Проверка на уникальность адреса
				if (!managementCompany.IsAddressUnique(address))
				{
					MessageBox.Show("Дом с таким адресом уже существует.");
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

					// добавляем квартиру в выбранный дом
					managementCompany.AddApartToHouse(address, apartmentNumber, Convert.ToDouble(textBoxPrice.Text));

					// очищаем текстовое поле
					textBoxPrice.Clear();

					// массив квартир у дома
					Apartment[] aparts = managementCompany.GetAllApartsOnHouse(address);

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

		private void dataGridViewHouses_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (dataGridViewHouses.Rows[e.RowIndex].Cells[0].Value != null)
				{
					string address = dataGridViewHouses.Rows[e.RowIndex].Cells[0].Value?.ToString();

					// получаем квартиры для выбранного дома
					Apartment[] apartments = managementCompany.GetAllApartsOnHouse(address);

					// очищаем dataGridViewBus перед обновлением
					dataGridViewApartments.Rows.Clear();

					if (apartments.Length > 0)
					{
						// установка количества строк в таблице квартир
						dataGridViewApartments.RowCount = apartments.Length;
					}

					// заполняем таблицу с квартирами
					for (int i = 0; i < apartments.Length; i++)
					{
						dataGridViewApartments.Rows[i].Cells[0].Value = apartments[i].Number;
						dataGridViewApartments.Rows[i].Cells[1].Value = apartments[i].MonthlyServiceFee;
					}
				}
			}
		}

		private void Save_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
				saveFileDialog.Title = "Сохранить данные";

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog.FileName;

					try
					{
						using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
						{
							// перебираем все дома
							House[] houses = managementCompany.GetAllHouses();
							foreach (var house in houses)
							{
								// перебираем квартиры в данном доме
								Apartment[] current = managementCompany.GetAllApartsOnHouse(house.Address);
								if (current.Length == 0)
								{
									writer.WriteLine($"{house.Address}\t0\t0");
								}
								foreach (var apart in current)
								{
									// записываем информацию о квартире
									writer.WriteLine($"{house.Address}\t{apart.Number}\t{apart.MonthlyServiceFee}");
								}

								writer.WriteLine(); // пустая строка между домами
							}
						}

						MessageBox.Show("Данные успешно сохранены.");
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
					}
				}
			}
		}

		private void Load_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

			// предупреждение о потере данных
			if (dataGridViewHouses.Rows[0].Cells[0].Value != null)
			{
				DialogResult result = MessageBox.Show("Внимание! Все введенные данные будут удалены. Вы уверены, что хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result != DialogResult.Yes)
				{
					return; // отмена загрузки данных
				}
			}

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string filePath = openFileDialog.FileName;

				// очищаем перед загрузкой новых данных
				ClearAll();

				try
				{
					using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
					{
						string line;
						Dictionary<string, House> existingHouse = new Dictionary<string, House>();

						while ((line = reader.ReadLine()) != null)
						{
							// разбиваем строку на части по разделителю (здесь используется табуляция)
							string[] parts = line.Split('\t');

							if (parts.Length == 3)
							{
								string address = parts[0];
								int numApp = int.Parse(parts[1]);
								double pay = double.Parse(parts[2]);

								House currentHouse;

								if (existingHouse.ContainsKey(address))
								{
									// если дом уже существует, используем существующий
									currentHouse = existingHouse[address];
								}
								else
								{
									// создаем новый дом, если он не существует
									currentHouse = new House(address);
									managementCompany.AddHouse(currentHouse);
									existingHouse.Add(address, currentHouse);
								}
								if (numApp != 0 && pay != 0)
								{
									// добавляем квартиру к текущему дому
									managementCompany.AddApartToHouse(address, numApp, pay);
								}

								UpdateGrids();
								UpdateHouse(address);
							}
						}

						MessageBox.Show("Данные успешно загружены.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
				}
			}
		}

		private void ClearAll()
		{
			dataGridViewApartments.Rows.Clear();
			dataGridViewHouses.Rows.Clear();

			managementCompany.ClearAllHouses();
			managementCompany.ClearAllAparts();
			labelTotalCountApart.Text = "общее число квартир: " + managementCompany.GetTotalApartsCount();
		}

		private void UpdateHouse(string address)
		{
			// очистка таблицы перед обновлением
			dataGridViewApartments.Rows.Clear();

			// получаем квартиры для выбранного дома
			Apartment[] aparts = managementCompany.GetAllApartsOnHouse(address);

			if (aparts.Length > 0)
			{
				// установка количества строк в таблице квартир
				dataGridViewApartments.RowCount = aparts.Length;
			}

			// заполняем таблицу с квартирами
			for (int i = 0; i < aparts.Length; i++)
			{
				dataGridViewApartments.Rows[i].Cells[0].Value = aparts[i].Number;
				dataGridViewApartments.Rows[i].Cells[1].Value = aparts[i].MonthlyServiceFee;
			}
		}

		private void clearAll_Click(object sender, EventArgs e)
		{
			ClearAll();
		}

		private void DeleteHouse_Click(object sender, EventArgs e)
		{
			// удаляем первый дом из очереди
			House deletedHouse = managementCompany.DeleteHouse();

			if (deletedHouse != null)
			{
				MessageBox.Show($"Дом с адресом '{deletedHouse.Address}' удален из очереди");
				UpdateGrids(); // обновляем таблицу после удаления
			}
			else
			{
				MessageBox.Show("Ошибка при удалении дома.");
			}
		}

		private void DeleteApart_Click(object sender, EventArgs e)
		{
			if (dataGridViewApartments.CurrentRow != null)
			{
				int selectedRow = dataGridViewApartments.CurrentRow.Index;
				string address = dataGridViewHouses.CurrentRow.Cells[0].Value?.ToString();

				// проверка, что заголовочный элемент не был выбран
				if (selectedRow > 0)
				{
					// получаем номер квартиры, которую нужно удалить
					int apartmentNumber = (int)dataGridViewApartments.Rows[selectedRow].Cells[0].Value;

					// удаляем квартиру из выбранного дома
					managementCompany.RemoveApartmentFromHouse(address, apartmentNumber);

					// обновляем таблицу квартир
					UpdateGrids();
					UpdateHouse(address);
				}
				else
				{
					MessageBox.Show("Вы не можете удалить заголовочный элемент.");
				}
			}
			else
			{
				MessageBox.Show("Выберите квартиру, которую нужно удалить.");
			}
		}

	}
}
