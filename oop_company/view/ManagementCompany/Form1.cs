using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static ManagementCompany.HouseList;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ManagementCompany
{
    public partial class ManagementCompanyMain : Form
    {
        HouseList HouseList = new HouseList();
        public bool isHouse = true;
        public ManagementCompanyMain()
        {
            InitializeComponent();
        }

        private void buttonSaveInfo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Фильтр для выбора только текстовых файлов
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (House house in HouseList)
                    {
                        string street = house.GetStreet();
                        int numberHouse = house.GetNumberHouse();
                        int sizeApart = house.SizeApart;

                        // Получите список квартир для текущего дома
                        List<Apartment> apartments = HouseList.GetAllApartments(street, numberHouse);
                        if (apartments.Count > 0)
                        {
                            // Запись информации о каждой квартире в файл
                            foreach (Apartment apartment in apartments)
                            {
                                int apartmentNumber = apartment.GetNumber();
                                int payment = apartment.GetPayment();

                                writer.Write($"{street}\t{numberHouse}\t{sizeApart}\t"); // Запись информации о доме в файл
                                writer.WriteLine($"{apartmentNumber}\t{payment}"); // Запись информации о квартире в файл
                            }
                        } else
                        {
                            writer.Write($"{street}\t{numberHouse}\t{sizeApart}\t"); // Запись информации о доме в файл
                            writer.WriteLine($"0\t0");
                        }
                    }
                }
                MessageBox.Show("Информация успешно сохранена");
            }
        }


        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Открытие диалогового окна для выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Фильтр для выбора только текстовых файлов

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Очищаем перед загрузкой новых данных
                ClearRows();

                Dictionary<string, bool> houseEntries = new Dictionary<string, bool>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split('\t');
                        string houseKey = columns[0] + columns[1] + columns[2];

                        // Проверяем, была ли уже добавлена запись с таким ключом в dataGridViewHouse
                        if (!houseEntries.ContainsKey(houseKey))
                        {
                            HouseList.AddHouse(new House(columns[0], Convert.ToInt32(columns[1]), Convert.ToInt32(columns[2])));

                            // Записываем данные в dataGridViewHouse
                            dataGridViewHouse.Rows.Add(columns[0], columns[1], columns[2], 
                                HouseList.GetApartmentCountInHouse(columns[0], Convert.ToInt32(columns[1])));
                            houseEntries.Add(houseKey, true);
                        }

                        // Записываем данные в dataGridViewApart
                        if (columns[3] != "0" && columns[4] != "0")
                        {
                            HouseList.AddApartmentToHouse(columns[0], Convert.ToInt32(columns[1]), 
                                new Apartment(Convert.ToInt32(columns[3]), Convert.ToInt32(columns[4])));
                            // dataGridViewApart.Rows.Add(columns[3], columns[4]);
                        }
                    }
                }
                for (int rowIndex = 0; rowIndex < dataGridViewHouse.Rows.Count - 1; rowIndex++)
                {
                    Console.WriteLine(" = " + dataGridViewHouse.Rows[rowIndex]);
                    string street = dataGridViewHouse.Rows[rowIndex].Cells[0].Value.ToString();
                    int houseNumber = Convert.ToInt32(dataGridViewHouse.Rows[rowIndex].Cells[1].Value);
                    dataGridViewHouse.Rows[rowIndex].Cells[3].Value = HouseList.GetApartmentCountInHouse(street, houseNumber);
                }

                MessageBox.Show("Информация успешно загружена\nДля вывода квартир нажмите на ячейку дома");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearRows();
        }

        private void ClearRows()
        {
            for (int i = 0; i < dataGridViewHouse.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewApart.RowCount; j++)
                    dataGridViewApart.Rows[j].SetValues(Enumerable.Repeat<object>(null, dataGridViewApart.Columns.Count).ToArray());
                dataGridViewHouse.Rows[i].SetValues(Enumerable.Repeat<object>(null, dataGridViewHouse.Columns.Count).ToArray());
            }
            dataGridViewApart.RowCount = 1;
            dataGridViewHouse.RowCount = 1;
            HouseList.RemoveAllApartments();
            HouseList.RemoveAllHouses();
        }

        private void buttonNewInfo_Click(object sender, EventArgs e)
        {
            isHouse = true;
            AddForm addForm = new AddForm(isHouse, "", "", "");
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (addForm.Street != "" && addForm.House != 0 && addForm.Count != 0)
                {
                    if (!HouseList.HouseExists(addForm.Street, addForm.House))
                    {
                        HouseList.AddHouse(new House(addForm.Street, addForm.House, addForm.Count));
                        dataGridViewHouse.Rows.Add(addForm.Street, addForm.House, addForm.Count, HouseList.GetApartmentCountInHouse(addForm.Street, addForm.House));
                        // dataGridViewApart.Rows.Add(addForm.House, addForm.Apart, addForm.Payment);
                    } else
                    {
                        MessageBox.Show("такой дом/улица уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Введена не вся информация");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewHouse.Rows.Count > 0)
                {
                    if (dataGridViewHouse.CurrentRow == null)
                    {
                        throw new Exception("Вначале выберите дом");
                    }

                    if (!string.IsNullOrEmpty(dataGridViewHouse.CurrentRow.Cells[0].Value as string))
                    {
                        string street = dataGridViewHouse.CurrentRow.Cells[0].Value?.ToString();
                        string number = dataGridViewHouse.CurrentRow.Cells[1].Value?.ToString();
                        string count = dataGridViewHouse.CurrentRow.Cells[2].Value?.ToString();
                        isHouse = false;

                        AddForm addForm = new AddForm(isHouse, street, number, count);
                        if (addForm.ShowDialog() == DialogResult.OK)
                        {
                            if (addForm.Apart > Convert.ToInt32(count))
                            {
                                throw new Exception("Номер квартиры не может превышать максимальное количество квартир в доме!");
                            }

                            if (addForm.Apart != 0 && addForm.Payment != 0)
                            {
                                HouseList.AddApartmentToHouse(addForm.Street, addForm.House, new Apartment(addForm.Apart, addForm.Payment));

                                int insertIndex = 0;
                                while (insertIndex < dataGridViewApart.Rows.Count && Convert.ToInt32(dataGridViewApart.Rows[insertIndex].Cells[0].Value) < addForm.Apart)
                                {
                                    insertIndex++;
                                }

                                if (insertIndex >= dataGridViewApart.Rows.Count)
                                {
                                    dataGridViewApart.Rows.Add(addForm.Apart, addForm.Payment);
                                }
                                else
                                {
                                    dataGridViewApart.Rows.Insert(insertIndex, addForm.Apart, addForm.Payment);
                                }
                            }

                            dataGridViewHouse.CurrentRow.Cells[3].Value = HouseList.GetApartmentCountInHouse(addForm.Street, addForm.House);
                        }
                    }
                    else
                    {
                        throw new Exception("Вначале выберите дом");
                    }
                }
                else
                {
                    throw new Exception("Не указана строка с домом!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewHouse.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dataGridViewHouse.Rows[0].Cells[0].Value as string))
                    {
                        string street = dataGridViewHouse.CurrentRow.Cells[0].Value?.ToString();
                        string number = dataGridViewHouse.CurrentRow.Cells[1].Value?.ToString();
                        HouseList.RemoveHouse(street, Convert.ToInt32(number));
                        dataGridViewHouse.Rows.RemoveAt(0);

                        for (int j = 0; j < dataGridViewApart.RowCount; j++)
                            dataGridViewApart.Rows[j].SetValues(Enumerable.Repeat<object>(null, dataGridViewApart.Columns.Count).ToArray());
                        dataGridViewApart.RowCount = 1;
                    }
                }
                else
                {
                    throw new Exception("Нечего удалять!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonDelApart_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewApart.CurrentRow != null)
                {
                    // Получаем текущую строку в dataGridViewHouse
                    DataGridViewRow currentRowHouse = dataGridViewApart.CurrentRow;

                    // Получаем значение второй ячейки текущей строки
                    string value = currentRowHouse.Cells[0].Value?.ToString();

                    HouseList.RemoveApartmentByNumber(Convert.ToInt32(value));
                    // Удаляем текущую строку из dataGridViewHouse
                    dataGridViewApart.Rows.Remove(currentRowHouse);
                    dataGridViewHouse.CurrentRow.Cells[3].Value = 
                        HouseList.GetApartmentCountInHouse(dataGridViewHouse.CurrentRow.Cells[0].Value.ToString(), 
                        Convert.ToInt32(dataGridViewHouse.CurrentRow.Cells[1].Value));
                }
                else
                {
                    throw new Exception("Не указана строка для удаления!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void dataGridViewHouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверяем, что была нажата строка (а не заголовок столбца)
            {
                DataGridViewRow selectedRow = dataGridViewHouse.Rows[e.RowIndex];

                // Получение значений ячеек из выбранной строки
                string street = selectedRow.Cells[0].Value?.ToString();
                int numberHouse = Convert.ToInt32(selectedRow.Cells[1].Value);

                // Находим соответствующий дом, зная street и numberHouse
                House house = HouseList.FindHouse(street, numberHouse);
                if (house != null)
                {
                    // Обновляем dataGridViewApart с информацией о квартирах в выбранном доме
                    List<Apartment> apps = HouseList.GetAllApartments(street, numberHouse);
                    for (int i = 0; i < apps.Count; i++)
                    {
                        if (i == 0 && dataGridViewApart.Rows[0].Cells[0].Value != null)
                        {
                            dataGridViewApart.Rows[0].SetValues(Enumerable.Repeat<object>(null, dataGridViewApart.Columns.Count).ToArray());
                            dataGridViewApart.Rows.Clear();
                        }
                        dataGridViewApart.Rows.Add(apps[i].GetNumber(), apps[i].GetPayment());
                    }
                    if (apps.Count == 0)
                    {
                        dataGridViewApart.Rows.Clear();
                    }
                }
                else
                {
                    // Дом не найден
                    dataGridViewApart.Rows[0].SetValues(Enumerable.Repeat<object>(null, dataGridViewApart.Columns.Count).ToArray());
                    dataGridViewApart.Rows.Clear();

                }
            }
        }

        
    }
}
