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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
                        }
                        else
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

                Dictionary<string, bool> streetEntries = new Dictionary<string, bool>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split('\t');
                        string street = columns[0];
                        int houseNumber = Convert.ToInt32(columns[1]);

                        string streetKey = street;

                        // Проверяем, была ли уже добавлена запись с таким ключом в dataGridViewStreet
                        if (!streetEntries.ContainsKey(streetKey))
                        {
                            // Добавляем улицу в dataGridViewStreet
                            dataGridViewStreet.Rows.Add(street);
                            streetEntries.Add(streetKey, true);
                        }

                        // Проверяем, был ли уже добавлен дом на этой улице
                        if (!HouseList.HouseExists(street, houseNumber))
                        {
                            HouseList.AddHouse(new House(street, houseNumber, Convert.ToInt32(columns[2])));
                        }

                        // Добавляем квартиру в дом
                        HouseList.AddApartmentToHouse(street, houseNumber, new Apartment(Convert.ToInt32(columns[3]), Convert.ToInt32(columns[4])));
                    }
                }

                MessageBox.Show("Информация успешно загружена\nДля вывода домов и квартир нажмите на название улицы");
            }
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearRows();
        }

        private void ClearRows()
        {
            for (int i = 0; i < dataGridViewStreet.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewApart.RowCount; j++)
                    dataGridViewApart.Rows[j].SetValues(Enumerable.Repeat<object>(null, dataGridViewApart.Columns.Count).ToArray());
                dataGridViewStreet.Rows[i].SetValues(Enumerable.Repeat<object>(null, dataGridViewStreet.Columns.Count).ToArray());
            }
            dataGridViewHouse.Rows.Clear();
            dataGridViewApart.RowCount = 1;
            dataGridViewStreet.RowCount = 1;
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
                        if (!StreetExists(addForm.Street))
                        {
                            dataGridViewStreet.Rows.Add(addForm.Street);
                        }
                        dataGridViewHouse.Rows.Add(addForm.House, addForm.Count, 
                            HouseList.GetApartmentCountInHouse(addForm.Street, addForm.House), 
                            HouseList.GetTotalPaymentByHouse(addForm.Street, addForm.House));
                    }
                    else
                    {
                        MessageBox.Show("такой дом на этой улице уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Введена не вся информация");
                }
            }
        }

        private bool StreetExists(string street)
        {
            foreach (DataGridViewRow row in dataGridViewStreet.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == street)
                {
                    return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewStreet.Rows.Count <= 0)
                {
                    throw new Exception("Не указана строка с домом!");
                }
                if (dataGridViewStreet.CurrentRow == null)
                {
                    throw new Exception("Вначале выберите дом");
                }

                if (!string.IsNullOrEmpty(dataGridViewStreet.CurrentRow.Cells[0].Value as string))
                {
                    string street = dataGridViewStreet.CurrentRow.Cells[0].Value?.ToString();
                    string number = dataGridViewHouse.CurrentRow.Cells[0].Value?.ToString();
                    string count = dataGridViewHouse.CurrentRow.Cells[1].Value?.ToString();
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

                        dataGridViewHouse.CurrentRow.Cells[2].Value = HouseList.GetApartmentCountInHouse(addForm.Street, addForm.House);
                        dataGridViewHouse.CurrentRow.Cells[3].Value = HouseList.GetTotalPaymentByHouse(addForm.Street, addForm.House);
                    }
                }
                else
                {
                    throw new Exception("Вначале выберите дом");
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
                if (dataGridViewHouse.Rows.Count <= 0)
                {
                    throw new Exception("Нечего удалять!");
                }

                if (dataGridViewHouse.Rows[0].Cells[0].Value == null)
                {
                    throw new Exception("Пустое значение!");
                }

                if (dataGridViewStreet.CurrentRow.Index != 0)
                {
                    throw new Exception("Для удаления нажмите на дом той улицы, которая находится вначале очереди!");
                }

                if (dataGridViewHouse.Rows.Count == 2)
                {
                    dataGridViewStreet.Rows.RemoveAt(0);
                }

                string street = dataGridViewStreet.CurrentRow.Cells[0].Value?.ToString();
                string number = dataGridViewHouse.Rows[0].Cells[0].Value?.ToString();
                HouseList.RemoveHouse(street, Convert.ToInt32(number));
                dataGridViewHouse.Rows.RemoveAt(0);

                for (int j = 0; j < dataGridViewApart.RowCount; j++)
                    dataGridViewApart.Rows[j].SetValues(Enumerable.Repeat<object>(null, dataGridViewApart.Columns.Count).ToArray());
                dataGridViewApart.RowCount = 1;
                
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

                    // Получаем значение первой ячейки текущей строки
                    string num = currentRowHouse.Cells[0].Value?.ToString();

                    HouseList.RemoveApartmentByNumber(Convert.ToInt32(num));
                    // Удаляем текущую строку из dataGridViewHouse
                    dataGridViewApart.Rows.Remove(currentRowHouse);
                    dataGridViewHouse.CurrentRow.Cells[2].Value =
                        HouseList.GetApartmentCountInHouse(dataGridViewStreet.CurrentRow.Cells[0].Value.ToString(),
                        Convert.ToInt32(dataGridViewHouse.CurrentRow.Cells[0].Value));
                    dataGridViewHouse.CurrentRow.Cells[3].Value = HouseList.GetTotalPaymentByHouse(dataGridViewStreet.CurrentRow.Cells[0].Value.ToString(),
                        Convert.ToInt32(dataGridViewHouse.CurrentRow.Cells[0].Value));
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

        private void dataGridViewStreet_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверяем, что была нажата строка (а не заголовок столбца)
            {
                DataGridViewRow selectedRow = dataGridViewStreet.Rows[e.RowIndex];

                // Получение значений ячеек из выбранной строки
                string street = selectedRow.Cells[0].Value?.ToString();
                dataGridViewHouse.Rows.Clear();

                foreach (House house in HouseList.GetAllHousesByStreet(street))
                {
                    if (house != null)
                    {
                        dataGridViewHouse.Rows.Add(house.GetNumberHouse(), house.SizeApart, HouseList.GetApartmentCountInHouse(street, house.GetNumberHouse()),
                            HouseList.GetTotalPaymentByHouse(street, house.GetNumberHouse()));
                        // Обновляем dataGridViewApart с информацией о квартирах в выбранном доме
                        List<Apartment> apps = HouseList.GetAllApartments(street, Convert.ToInt32(dataGridViewHouse.CurrentRow.Cells[0].Value));
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

        private void dataGridViewHouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверяем, что была нажата строка (а не заголовок столбца)
            {
                DataGridViewRow selectedRowHouse = dataGridViewHouse.Rows[e.RowIndex];
                DataGridViewRow selectedRowStreet = dataGridViewStreet.CurrentRow;

                // Получение значений ячеек из выбранной строки
                string street = selectedRowStreet.Cells[0].Value?.ToString();
                string numberHouseValue = selectedRowHouse.Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(numberHouseValue))
                {
                    dataGridViewApart.Rows.Clear();
                    return;
                }

                int numberHouse = Convert.ToInt32(numberHouseValue);

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
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            Info infoForm = new Info();
            if (infoForm.ShowDialog() == DialogResult.OK)
            {
                infoForm.Close();
                return;
            }
        }
    }
}
