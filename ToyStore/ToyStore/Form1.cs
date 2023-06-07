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
                    throw new Exception("Такая игрушка уже существует");
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
    }
}
