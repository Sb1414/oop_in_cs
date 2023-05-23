using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ManagementCompany
{
    public partial class ManagementCompanyMain : Form
    {
        ApartmentsList ApartmentsList = new ApartmentsList();
        HouseList HouseList = new HouseList();
        public ManagementCompanyMain()
        {
            InitializeComponent();
            readOnly(true);
        }

        private void AddInfoForClass()
        {
            HouseList.Clear();
            ApartmentsList.Clear();
            int i = 1;
            // Сохранение информации из dataGridViewHouse
            foreach (DataGridViewRow row in dataGridViewHouse.Rows)
            {
                if (i == dataGridViewHouse.RowCount)
                {
                    break;
                }

                string street = row.Cells[0].Value.ToString();
                int numberHouse = Convert.ToInt32(row.Cells[1].Value);
                int sizeApart = Convert.ToInt32(row.Cells[2].Value);

                HouseList.AddHouse(new House(street, numberHouse, sizeApart));
                int j = 1;
                // Поиск соответствующей информации в dataGridViewApart
                foreach (DataGridViewRow apartRow in dataGridViewApart.Rows)
                {
                    if (j == dataGridViewApart.RowCount)
                    {
                        break;
                    }
                    if (dataGridViewApart.Rows.Count > 0 && dataGridViewApart.Rows[0].Cells.Count > 0 && dataGridViewApart.Rows[0].Cells[0].Value != null)
                    {
                        string apartColumn = apartRow.Cells[0].Value.ToString();
                        if (apartColumn == row.Cells[1].Value.ToString())
                        {
                            int price;
                            int area;
                            if (int.TryParse(apartRow.Cells[1].Value?.ToString(), out price) && int.TryParse(apartRow.Cells[2].Value?.ToString(), out area))
                            {
                                ApartmentsList.AddApartment(new Apartment(price, area));
                            }
                        }
                    }
                    j++;
                }
                i++;

            }
        }

        private void buttonSaveInfo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Фильтр для выбора только текстовых файлов
            bool flag = false;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    int i = 1;
                    // Сохранение информации из dataGridViewHouse
                    foreach (DataGridViewRow row in dataGridViewHouse.Rows)
                    {
                        if (i == dataGridViewHouse.RowCount)
                        {
                            break;
                        }

                        string street = row.Cells[0].Value.ToString();
                        int numberHouse = Convert.ToInt32(row.Cells[1].Value);
                        int sizeApart = Convert.ToInt32(row.Cells[2].Value);

                        // Поиск соответствующей информации в dataGridViewApart
                        foreach (DataGridViewRow apartRow in dataGridViewApart.Rows)
                        {
                            if (Convert.ToString(apartRow.Cells[0].Value) == Convert.ToString(row.Cells[1].Value))
                            {
                                // Console.WriteLine(">> in dataGridViewApart в if");
                                flag = true;
                                writer.Write(street + "\t" + numberHouse.ToString() + "\t" + sizeApart.ToString());
                                writer.Write("\t" + apartRow.Cells[1].Value + "\t" + apartRow.Cells[2].Value);
                                writer.WriteLine(); // Переход на новую строку
                            }
                        }
                        // Console.WriteLine(" вышел из foreach || flag = " + flag.ToString());

                        if (!flag)
                        {
                            writer.Write(street + "\t" + numberHouse.ToString() + "\t" + sizeApart.ToString());
                            writer.Write("\t" + 0 + "\t" + 0);
                            writer.WriteLine(); // Переход на новую строку
                        }

                        i++;
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
                dataGridViewHouse.Rows.Clear();
                dataGridViewApart.Rows.Clear();

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
                            // Записываем данные в dataGridViewHouse
                            dataGridViewHouse.Rows.Add(columns[0], columns[1], columns[2]);
                            houseEntries.Add(houseKey, true);
                        }

                        // Записываем данные в dataGridViewApart
                        dataGridViewApart.Rows.Add(columns[1], columns[3], columns[4]);
                    }
                }

                AddInfoForClass();
                MessageBox.Show("Информация успешно загружена");
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
                AddInfoForClass();
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

        private void dataGridViewApart_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверка, что происходит редактирование строки, а не заголовка столбца
            {
                DataGridView dataGridView = (DataGridView)sender;
                string columnName = dataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "Column1_") // Первый столбец
                {
                    string cellValue = e.FormattedValue.ToString();
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        bool isCyrillicOrLatin = IsNumeric(cellValue);
                        bool containsNumber = HouseList.ContainsNumber(int.Parse(cellValue));
                        if (!isCyrillicOrLatin)
                        {
                            dataGridView.Rows[e.RowIndex].ErrorText = "В первом столбце должен быть только номер дома";
                            e.Cancel = true; // Отменить изменение значения ячейки
                        } else if (!containsNumber)
                        {
                            dataGridView.Rows[e.RowIndex].ErrorText = "Такого номера дома не существует";
                            e.Cancel = true; // Отменить изменение значения ячейки
                        }
                    }
                }
                else if (columnName == "Column2_") // Второй столбец
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
            dataGridViewHouse.Rows.Clear();
            dataGridViewApart.Rows.Clear();
        }
    }
}
