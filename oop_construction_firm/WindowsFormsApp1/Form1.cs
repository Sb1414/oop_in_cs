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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ConstructionFirm constructionFirm;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddFirm_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на пустоту полей ввода
                if (textBoxName.Text == "" && textBoxDirector.Text == "" && textBoxCount.Text == "")
                {
                    throw new Exception("Нечего не введено");
                }

                // Получение значений из полей ввода и удаление лишних пробелов
                string name = textBoxName.Text.Trim();
                string director = textBoxDirector.Text.Trim();

                // Проверка ввода для textBoxName с использованием регулярного выражения
                if (!Regex.IsMatch(name, @"^[A-Za-zА-Яа-я\s]+$"))
                {
                    throw new Exception("В поле \"Название фирмы\" допускаются только буквы и пробел");
                }

                // Проверка ввода для textBoxDirector с использованием регулярного выражения
                if (!Regex.IsMatch(director, @"^(\w+\s){2}\w+$"))
                {
                    throw new Exception("Поле \"Руководитель\" должно содержать ФИО, разделенные одним пробелом");
                }

                // Проверка ввода для textBoxCount с использованием регулярного выражения
                if (!Regex.IsMatch(textBoxCount.Text, @"^[0-9]+$"))
                {
                    throw new Exception("Поле \"Максимальное количество объектов\" должно содержать число");
                }

                // Проверка наличия предыдущей фирмы и запрос подтверждения удаления
                if (labelNameFirmAndFIO.Text != "Название фирмы: -")
                {
                    DialogResult result = MessageBox.Show("Создать новую фирму? Предыдущая будет удалена", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        ClearTextBox();
                        return;
                    }
                }

                // Очистка таблицы и создание новой фирмы
                dataGridView1.Rows.Clear();

                // Создание объекта ConstructionFirm с указанными значениями
                constructionFirm = new ConstructionFirm(name, director, Convert.ToInt32(textBoxCount.Text));

                // Обновление меток с информацией о фирме
                UpdateInfo();

                // Очистка полей ввода
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void UpdateInfo()
        {
            labelCount.Text = "  |  Количество объектов: " + constructionFirm.GetBuildingCount();
            labelNameFirmAndFIO.Text = "Название фирмы: " + constructionFirm.GetNameFirm()
                + "  |  ФИО руководителя: " + constructionFirm.GetDirectorFirm();
            totalSum.Text = "Общая сумма: " + constructionFirm.CalculateTotalConstructionCost();
        }

        private void ClearTextBox()
        {
            // Очистка полей ввода
            textBoxName.Text = "";
            textBoxDirector.Text = "";
            textBoxCount.Text = "";
        }

        private void buttonAddBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на пустоту полей ввода
                if (textBoxAddress.Text == "" || textBoxCost.Text == "" || textBoxPeriod.Text == "")
                {
                    throw new Exception("Заполните все поля");
                }

                // Проверка наличия созданной фирмы
                if (constructionFirm == null)
                {
                    throw new Exception("Вначале введите название и руководителя фирмы");
                }

                // Получение значений из полей ввода и удаление лишних пробелов
                string address = textBoxAddress.Text.Trim();
                string cost = textBoxCost.Text.Trim();
                string period = textBoxPeriod.Text.Trim();

                // Проверка наличия только букв, цифр и пробелов в адресе с использованием регулярного выражения
                if (!Regex.IsMatch(address, @"^[a-zA-Zа-яА-Я0-9\s]+$"))
                {
                    throw new Exception("Адрес должен состоять из букв, цифр и пробелов");
                }

                // Проверка формата ввода для стоимости с использованием регулярного выражения
                if (!Regex.IsMatch(cost, @"^[0-9]+(\,[0-9]+)?$"))
                {
                    throw new Exception("Стоимость должна состоять из цифр и может включать десятичную точку");
                }

                // Проверка формата ввода для периода с использованием регулярного выражения
                if (!Regex.IsMatch(period, @"^[0-9]+$"))
                {
                    throw new Exception("Период должен содержать целое число - количество месяцев");
                }

                // Создание объекта Building с указанными значениями
                Building building = new Building(address, Convert.ToDecimal(cost), Convert.ToInt32(period));

                // Проверка наличия объекта с таким же адресом в фирме
                if (constructionFirm.IsBuildingExists(address))
                {
                    throw new Exception("Такой объект уже существует");
                }

                // Проверка наличия максимального количества объектов в фирме
                if (constructionFirm.GetCapacity() == constructionFirm.GetBuildingCount())
                {
                    // Очистка таблицы и добавление объекта в фирму
                    dataGridView1.Rows.Clear();
                    constructionFirm.AddBuilding(address, Convert.ToDecimal(cost), Convert.ToInt32(period));

                    // Обновление таблицы
                    for (int i = 0; i < constructionFirm.GetBuildingCount(); i++)
                    {
                        Building building2 = constructionFirm.GetBuilding(i);
                        dataGridView1.Rows.Add(building2.Address, building2.ConstructionCost, building2.ConstructionPeriod);
                    }
                }
                else
                {
                    // Добавление объекта в фирму и таблицу
                    constructionFirm.AddBuilding(address, Convert.ToDecimal(cost), Convert.ToInt32(period));
                    dataGridView1.Rows.Add(building.Address, building.ConstructionCost, building.ConstructionPeriod);
                }

                // Обновление меток с информацией о фирме
                UpdateInfo();

                // Очистка полей ввода
                textBoxAddress.Text = "";
                textBoxCost.Text = "";
                textBoxPeriod.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка наличия созданной фирмы и запрос подтверждения открытия новой фирмы
                if (constructionFirm != null)
                {
                    DialogResult result = MessageBox.Show("Действительно открыть новую фирму? Предыдущая будет удалена", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                // Очистка таблицы и фирмы
                if (constructionFirm != null)
                    constructionFirm.Clear();
                dataGridView1.Rows.Clear();

                // Открытие диалогового окна для выбора файла
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                openFileDialog.Title = "Открыть фирму";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Чтение данных из файла и создание объектов фирмы и зданий
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] firm = line.Split('\t');
                            if (firm.Length == 6)
                            {
                                string nameFirm = firm[0];
                                string dirFirm = firm[1];
                                int maxCount = int.Parse(firm[2]);
                                string address = firm[3];
                                decimal cost = decimal.Parse(firm[4]);
                                int period = int.Parse(firm[5]);

                                // Создание фирмы, если она не была создана ранее
                                if (constructionFirm == null)
                                {
                                    constructionFirm = new ConstructionFirm(nameFirm, dirFirm, maxCount);
                                }

                                // Создание объекта Building и добавление его в фирму и таблицу
                                Building building = new Building(address, cost, period);
                                constructionFirm.AddBuilding(address, cost, period);
                                dataGridView1.Rows.Add(building.Address, building.ConstructionCost, building.ConstructionPeriod);
                            }
                        }
                    }

                    // Обновление меток с информацией о фирме
                    UpdateInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                if (constructionFirm == null) // Проверка наличия созданной фирмы
                {
                    throw new Exception("Фирма не была создана");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog(); // Создание нового диалогового окна для сохранения файла
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Установка фильтра для выбора только текстовых файлов
                saveFileDialog.Title = "Сохранить фирму"; // Заголовок диалогового окна
                if (saveFileDialog.ShowDialog() == DialogResult.OK) // Проверка, была ли нажата кнопка "ОК" в диалоговом окне
                {
                    string filePath = saveFileDialog.FileName; // Получение выбранного пути файла

                    using (StreamWriter writer = new StreamWriter(filePath)) // Создание объекта для записи данных в файл
                    {
                        for (int i = 0; i < constructionFirm.GetBuildingCount(); i++) // Перебор всех объектов фирмы
                        {
                            Building building = constructionFirm.GetBuilding(i); // Получение текущего объекта здания
                                                                                 // Запись информации о фирме и здании в файл, разделяя значения табуляцией
                            writer.WriteLine($"{constructionFirm.GetNameFirm()}\t{constructionFirm.GetDirectorFirm()}" +
                                $"\t{constructionFirm.GetCapacity()}\t{building.Address}\t{building.ConstructionCost}\t{building.ConstructionPeriod}");
                        }
                    }

                    MessageBox.Show("Фирма успешно сохранена", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information); // Отображение сообщения об успешном сохранении
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop); // Отображение сообщения об ошибке
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (constructionFirm == null) // Проверка наличия созданной фирмы
                {
                    throw new Exception("Фирма не создана");
                }

                if (constructionFirm.IsEmpty()) // Проверка, есть ли объекты для удаления
                {
                    throw new Exception("Фирма пуста. Нет объектов для удаления.");
                }

                constructionFirm.Remove(); // Удаление объекта фирмы

                // Обновление таблицы
                dataGridView1.Rows.Clear(); // Очистка всех строк таблицы
                for (int i = 0; i < constructionFirm.GetBuildingCount(); i++) // Перебор всех объектов фирмы
                {
                    Building building = constructionFirm.GetBuilding(i); // Получение текущего объекта здания
                    dataGridView1.Rows.Add(building.Address, building.ConstructionCost, building.ConstructionPeriod); // Добавление информации о здании в таблицу
                }

                // Обновление меток с информацией о фирме
                UpdateInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop); // Отображение сообщения об ошибке
            }
        }
    }
}
