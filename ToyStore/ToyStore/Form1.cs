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

namespace ToyStore
{
    public partial class Form1 : Form
    {
        ToyStoreList toyStoreList;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddStore_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на пустоту полей ввода
                if (textBoxStName.Text == "" && textBoxStHours.Text == "")
                {
                    throw new Exception("Нечего не введено");
                }

                // Получение значений из полей ввода и удаление лишних пробелов
                string name = textBoxStName.Text.Trim();
                string hours = textBoxStHours.Text.Trim();

                // Проверка ввода с использованием регулярного выражения
                if (!Regex.IsMatch(name, @"^[A-Za-zА-Яа-я\s]+$"))
                {
                    throw new Exception("В поле \"Название магазина\" допускаются только буквы и пробел");
                }

                // Проверка ввода с использованием регулярного выражения
                if (!Regex.IsMatch(hours, @"^([01]\d|2[0-3]):([0-5]\d)-([01]\d|2[0-3]):([0-5]\d)$"))
                {
                    throw new Exception("Поле \"Часы работы\" должно выглядеть так: 00:00-15:00");
                }

                // Проверка наличия предыдущей фирмы и запрос подтверждения удаления
                if (labelNameStore.Text != "Название магазина:")
                {
                    DialogResult result = MessageBox.Show("Создать новый магазин? Предыдущий будет удален", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        ClearTextBox();
                        return;
                    }
                }

                // Очистка таблицы и создание новой фирмы
                dataGridViewToys.Rows.Clear();

                // Создание объекта
                toyStoreList = new ToyStoreList(name, hours);

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

        private void ClearTextBox()
        {
            // Очистка полей ввода
            textBoxStName.Text = "";
            textBoxStHours.Text = "";
        }

        private void UpdateInfo()
        {
            labelNameStore.Text = "Название магазина: " + toyStoreList.GetName();
            labelWorkingHours.Text = "Режим работы: " + toyStoreList.GetWorkingHours();
            totalSum.Text = "Общая сумма: " + toyStoreList.CalculateTotalPrice();
            countToys.Text = "Общее количество: " + toyStoreList.CalculateTotalQuantity();
        }

        private void buttonAddToy_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на пустоту полей ввода
                if (textBoxToyName.Text == "" || textBoxToyArticle.Text == "" || textBoxToyManufacturer.Text == "" 
                    || textBoxToyPrice.Text == "" || textBoxToyQuantity.Text == "")
                {
                    throw new Exception("Заполните все поля");
                }

                // Проверка наличия созданного магазина
                if (toyStoreList == null)
                {
                    throw new Exception("Вначале введите название магазина и часы работы");
                }

                // Получение значений из полей ввода и удаление лишних пробелов
                string nameToy = textBoxToyName.Text.Trim();
                string article = textBoxToyArticle.Text.Trim();
                string manufacturer = textBoxToyManufacturer.Text.Trim();
                string cost = textBoxToyPrice.Text.Trim();
                string quantity = textBoxToyQuantity.Text.Trim();

                // Проверка наличия только букв, цифр и пробелов в названии игрушки с использованием регулярного выражения
                if (!Regex.IsMatch(nameToy, @"^[a-zA-Zа-яА-Я\s]+$"))
                {
                    throw new Exception("Название игрушки должно состоять из букв и пробелов");
                }

                // Проверка формата ввода для артикула с использованием регулярного выражения
                if (!Regex.IsMatch(article, @"^[0-9]+$"))
                {
                    throw new Exception("Артикул должен содержать числа");
                }

                // Проверка формата ввода для производителя с использованием регулярного выражения
                if (!Regex.IsMatch(manufacturer, @"^[a-zA-Zа-яА-Я]+$"))
                {
                    throw new Exception("Поле производитель должно содержать только буквы");
                }

                // Проверка формата ввода для стоимости с использованием регулярного выражения
                if (!Regex.IsMatch(cost, @"^[0-9]+(\,[0-9]+)?$"))
                {
                    throw new Exception("Стоимость должна состоять из цифр и может включать десятичную точку");
                }

                // Проверка формата ввода для количества с использованием регулярного выражения
                if (!Regex.IsMatch(quantity, @"^[0-9]+$"))
                {
                    throw new Exception("Количество должно содержать целое число");
                }

                // Создание объекта Toy с указанными значениями
                Toy toy = new Toy(nameToy, Convert.ToInt32(article), manufacturer, Convert.ToDecimal(cost), Convert.ToInt32(quantity));

                // Проверка наличия игрушки с таким же названием
                if (toyStoreList.IsToyExists(nameToy))
                {
                    throw new Exception("Игрушка с таким названием уже существует");
                }

                if (toyStoreList.IsToyExists(Convert.ToInt32(article))) // Проверка наличия игрушки с таким же артикулом
                {
                    throw new Exception("Игрушка с таким артикулом уже существует");
                }

                if (dataGridViewToys.CurrentRow == null || dataGridViewToys.CurrentRow.IsNewRow)
                {
                    // Если выбрана последняя строка или пустая строка, вызвать метод AddToy
                    toyStoreList.AddToy(toy);
                    // вставка в таблицу
                    dataGridViewToys.Rows.Add(toy.Name, toy.ArticleNumber, toy.Manufacturer, toy.Price, toy.Quantity);
                }
                else
                {
                    // Получить позицию текущей строки
                    int position = dataGridViewToys.CurrentRow.Index;
                    // Вставить игрушку на указанную позицию
                    toyStoreList.InsertToyAtPosition(toy, position);
                    // вставка в таблицу
                    dataGridViewToys.Rows.Insert(position, toy.Name, toy.ArticleNumber, toy.Manufacturer, toy.Price, toy.Quantity);
                }

                // Обновление меток с информацией
                UpdateInfo();

                // Очистка полей ввода
                textBoxToyName.Text = "";
                textBoxToyArticle.Text = "";
                textBoxToyManufacturer.Text = "";
                textBoxToyPrice.Text = "";
                textBoxToyQuantity.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на наличие выбранной строки в таблице
                if (dataGridViewToys.CurrentRow == null || dataGridViewToys.CurrentRow.IsNewRow)
                {
                    throw new Exception("Выберите игрушку для удаления");
                }

                // Получение значения артикула выбранной игрушки
                int articleNumber = Convert.ToInt32(dataGridViewToys.CurrentRow.Cells[1].Value);

                // Удаление игрушки из магазина
                toyStoreList.RemoveToy(articleNumber);

                int countToys = Convert.ToInt32(dataGridViewToys.CurrentRow.Cells[4].Value);

                if (countToys == 1)
                {
                    // Удаление выбранной строки из таблицы
                    dataGridViewToys.Rows.Remove(dataGridViewToys.CurrentRow);
                } else
                {
                    dataGridViewToys.CurrentRow.Cells[4].Value = countToys - 1;
                }

                // Обновление меток с информацией
                UpdateInfo();
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
                // Проверка наличия созданного магазина и запрос подтверждения открытия нового магазина
                if (toyStoreList != null)
                {
                    DialogResult result = MessageBox.Show("Действительно открыть новый магазин? Предыдущий будет удален", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                // Очистка таблицы и списка
                if (toyStoreList != null)
                    toyStoreList.Clear();
                dataGridViewToys.Rows.Clear();

                // Открытие диалогового окна для выбора файла
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                openFileDialog.Title = "Открыть магазин";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Чтение данных из файла и создание объектов магазина и игрушек
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] store = line.Split('\t');
                            if (store.Length == 7)
                            {
                                string nameStore = store[0];
                                string workingHours = store[1];
                                string toyName = store[2];
                                int toyArticle = int.Parse(store[3]);
                                string manufacturer = store[4];
                                decimal cost = decimal.Parse(store[5]);
                                int count = int.Parse(store[6]);

                                // Создание магазина, если он не был создан
                                if (toyStoreList == null)
                                {
                                    toyStoreList = new ToyStoreList(nameStore, workingHours);
                                }

                                // Создание объекта toy и добавление его в магазин и таблицу
                                Toy toy = new Toy(toyName, toyArticle, manufacturer, cost, count);
                                toyStoreList.AddToy(toy);
                                dataGridViewToys.Rows.Add(toy.Name, toy.ArticleNumber, toy.Manufacturer, toy.Price, toy.Quantity);
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
                if (toyStoreList == null) // Проверка наличия созданного магазина
                {
                    throw new Exception("Магазин игрушек не был создан");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog(); // Создание нового диалогового окна для сохранения файла
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Установка фильтра для выбора только текстовых файлов
                saveFileDialog.Title = "Сохранить магазин игрушек"; // Заголовок диалогового окна
                if (saveFileDialog.ShowDialog() == DialogResult.OK) // Проверка, была ли нажата кнопка "ОК" в диалоговом окне
                {
                    string filePath = saveFileDialog.FileName; // Получение выбранного пути файла

                    using (StreamWriter writer = new StreamWriter(filePath)) // Создание объекта для записи данных в файл
                    {
                        Toy[] toy = toyStoreList.GetAllToys();
                        for (int i = 0; i < toyStoreList.GetCount(); i++) // Перебор всех объектов игрушек
                        {
                            // Запись информации о магазине и игрушке в файл, разделяя значения табуляцией
                            writer.WriteLine($"{toyStoreList.GetName()}\t{toyStoreList.GetWorkingHours()}" +
                            $"\t{toy[i].Name}\t{toy[i].ArticleNumber}\t{toy[i].Manufacturer}\t{toy[i].Price}\t{toy[i].Quantity}");
                        }
                    }

                    MessageBox.Show("Магазин успешно сохранён", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information); // Отображение сообщения об успешном сохранении
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop); // Отображение сообщения об ошибке
            }
        }
    }
}
