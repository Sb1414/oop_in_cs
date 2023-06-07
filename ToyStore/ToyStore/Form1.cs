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

        }
    }
}
