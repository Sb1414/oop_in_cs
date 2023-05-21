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

        private void buttonSaveInfo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Фильтр для выбора только текстовых файлов

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    int i = 1;
                    // Сохранение информации из datagrid
                    foreach (DataGridViewRow row in dataGridViewHouse.Rows)
                    {
                        if (i == dataGridViewHouse.RowCount)
                        {
                            break;
                        }
                        writer.Write(row.Cells[0].Value.ToString() + "\t" + row.Cells[1].Value.ToString() + "\t" + row.Cells[2].Value.ToString());
                        writer.WriteLine(); // Переход на новую строку
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

                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Очистка существующих данных в datagrid
                    dataGridViewHouse.Rows.Clear();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] cells = line.Split('\t'); // Разделение строки на ячейки по разделителю '\t'

                        // Добавление строки в datagrid
                        dataGridViewHouse.Rows.Add(cells);
                    }
                }

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

        private void checkRegular()
        {
            int i = 0;
            foreach (DataGridViewRow row in dataGridViewHouse.Rows)
            {
                if (i == dataGridViewHouse.RowCount)
                {
                    break;
                }
                HouseList.AddHouse(new House(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value), Convert.ToInt32(row.Cells[2].Value)));
                i++;
            }
            
        }

        private void dataGridViewHouse_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            readOnly(false);
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
            if (e.RowIndex >= 0) // Проверка, что редактирование происходит в строке данных
            {
                DataGridView dataGridView = (DataGridView)sender;
                dataGridView.Rows[e.RowIndex].ErrorText = string.Empty; // Очистить текст ошибки для строки
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
            return Regex.IsMatch(text, @"^\d+[a-zA-Z]?$");
        }
    }
}
