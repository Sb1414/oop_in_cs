using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ManagementCompany
{
    public partial class ManagementCompanyMain : Form
    {
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
    }
}
