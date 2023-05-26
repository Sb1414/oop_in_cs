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
        public ManagementCompanyMain()
        {
            InitializeComponent();
            readOnly(true);
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
                            dataGridViewHouse.Rows.Add(columns[0], columns[1], columns[2]);
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
                readOnly(false);
                checkBox1.Checked = true;
                MessageBox.Show("Информация успешно загружена\nДля вывода квартир нажмите на ячейку дома");
            }
        }

        private void readOnly(bool flag)
        {
            foreach (DataGridViewRow row in dataGridViewHouse.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = flag;
                }
            }

            foreach (DataGridViewRow row in dataGridViewApart.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = flag;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                readOnly(false);
            } else
            {
                readOnly(true);
            }
        }

        private void dataGridViewHouse_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверка, что происходит редактирование строки, а не заголовка столбца
            {
                DataGridView dataGridView = (DataGridView)sender;
                string columnName = dataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "Column1") // Первый столбец
                {
                    string cellValue = e.FormattedValue.ToString();
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        bool isCyrillicOrLatin = IsCyrillicOrLatin(cellValue);
                        if (!isCyrillicOrLatin)
                        {
                            dataGridView.Rows[e.RowIndex].ErrorText = "В первом столбце должны быть только буквы кириллица или латиница";
                            e.Cancel = true; // Отменить изменение значения ячейки
                        }
                    }
                }
                else if (columnName == "Column2") // Второй столбец
                {
                    string cellValue = e.FormattedValue.ToString();
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        bool isNumeric = IsNumOrSym(cellValue);
                        if (!isNumeric)
                        {
                            dataGridView.Rows[e.RowIndex].ErrorText = "Во втором столбце должна быть только цифра, либо цифра и буква";
                            e.Cancel = true; // Отменить изменение значения ячейки
                        }
                    }
                }
                else if (columnName == "Column3")
                {
                    string cellValue = e.FormattedValue.ToString();
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        bool isNumeric = IsNumeric(cellValue);
                        if (!isNumeric)
                        {
                            dataGridView.Rows[e.RowIndex].ErrorText = "В третьем столбце должна быть только цифра";
                            e.Cancel = true; // Отменить изменение значения ячейки
                        }
                    }
                }
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex >= 0) // Проверка, что редактирование происходит в строке данных
            {
                dataGridView.Rows[e.RowIndex].ErrorText = string.Empty; // Очистить текст ошибки для строки
            }
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            if (IsRowFilled(row))
            {
                // AddInfoForClass();
                string street = row.Cells[0].Value.ToString();
                int numberHouse = Convert.ToInt32(row.Cells[1].Value);
                int sizeApart = Convert.ToInt32(row.Cells[2].Value);

                HouseList.AddHouse(new House(street, numberHouse, sizeApart));
            }
        }

        private bool IsCyrillicOrLatin(string text)
        {
            // Проверка, что строка содержит только буквы кириллица или латиница
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-Я]+$");
        }

        private bool IsNumeric(string text)
        {
            // Проверка, что строка содержит только цифры
            return Regex.IsMatch(text, @"^[0-9]+$");
        }

        private bool IsNumOrSym(string text)
        {
            return Regex.IsMatch(text, @"^\d+[a-zA-Zа-яА-Я]?$");
        }

        private bool IsRowFilled(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsRowFilled2(DataGridViewRow row)
        {
            for (int columnIndex = 0; columnIndex < row.Cells.Count; columnIndex++)
            {
                if (row.Cells[columnIndex].Value == null)
                {
                    return false;
                }
            }
            return true;
        }

        private void dataGridViewApart_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверка, что происходит редактирование строки, а не заголовка столбца
            {
                DataGridView dataGridView = (DataGridView)sender;
                string columnName = dataGridView.Columns[e.ColumnIndex].Name;
                
                if (columnName == "Column2_") // Второй столбец
                {
                    string cellValue = e.FormattedValue.ToString();
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        bool isNumeric = IsNumeric(cellValue);
                        if (!isNumeric)
                        {
                            dataGridView.Rows[e.RowIndex].ErrorText = "Во втором столбце должен быть только номер квартиры";
                            e.Cancel = true; // Отменить изменение значения ячейки
                        }
                        else
                        {
                            // int countMax = HouseList.GetCountByNumber(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
                            DataGridViewRow currentRowHouse = dataGridViewHouse.CurrentRow;
                            int num_house = -1;
                            if (currentRowHouse != null)
                            {
                                DataGridViewCell cell2 = currentRowHouse.Cells[2]; // Получение второй ячейки (индекс 1)

                                if (cell2.Value != null)
                                {
                                    num_house = Convert.ToInt32(cell2.Value); // Значение второй ячейки в виде строки
                                }
                            }

                            if (num_house == -1)
                            {
                                dataGridView.Rows[e.RowIndex].ErrorText = "Выбрана некорректная ячейка в первой таблице";
                                e.Cancel = true; // Отменить изменение значения ячейки
                            }

                            if (num_house < Convert.ToInt32(cellValue))
                            {
                                dataGridView.Rows[e.RowIndex].ErrorText = "Номер квартиры превышает количество квартир";
                                e.Cancel = true; // Отменить изменение значения ячейки
                            }

                        }
                    }
                }
                else if (columnName == "Column3_")
                {
                    string cellValue = e.FormattedValue.ToString();
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        bool isNumeric = IsNumeric(cellValue);
                        if (!isNumeric)
                        {
                            dataGridView.Rows[e.RowIndex].ErrorText = "В третьем столбце должна быть только выплата";
                            e.Cancel = true; // Отменить изменение значения ячейки
                        }
                    }
                }

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
            AddForm moveForm = new AddForm();
            if (moveForm.ShowDialog() == DialogResult.OK)
            {
                if (moveForm.Street != "" && moveForm.House != 0 && moveForm.Count != 0)
                {
                    int rowIndex = dataGridViewHouse.CurrentCell.RowIndex; // Получаем индекс текущей строки
                    dataGridViewHouse.Rows.Insert(rowIndex + 1, moveForm.Street, moveForm.House, moveForm.Count); // Вставляем новую строку после текущей
                    HouseList.AddHouse(new House(moveForm.Street, moveForm.House, moveForm.Count));
                    if (moveForm.Apart != 0 && moveForm.Payment != 0)
                        HouseList.AddApartmentToHouse(moveForm.Street, moveForm.House, new Apartment(moveForm.Apart, moveForm.Payment));
                    // dataGridViewApart.Rows.Add(moveForm.House, moveForm.Apart, moveForm.Payment);
                }
                else
                {
                    MessageBox.Show("Введена не вся информация");
                }
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

        private void dataGridViewApart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            if (e.RowIndex >= 0) // Проверка, что редактирование происходит в строке данных
            {
                dataGridView.Rows[e.RowIndex].ErrorText = string.Empty; // Очистить текст ошибки для строки
            }

            if (IsRowFilled2(row))
            {
                DataGridViewRow currentRowHouse = dataGridViewHouse.CurrentRow;
                if (currentRowHouse != null)
                {
                    DataGridViewCell cell1 = currentRowHouse.Cells[0];
                    DataGridViewCell cell2 = currentRowHouse.Cells[1];

                    if (cell1.Value != null && cell2.Value != null)
                    {
                        string street = cell1.Value.ToString();
                        int num_house = Convert.ToInt32(cell2.Value);

                        // AddInfoForClass();
                        int number_apart = Convert.ToInt32(row.Cells[0].Value);
                        int payment = Convert.ToInt32(row.Cells[1].Value);

                        HouseList.AddApartmentToHouse(street, num_house, new Apartment(number_apart, payment));
                    }
                }
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
