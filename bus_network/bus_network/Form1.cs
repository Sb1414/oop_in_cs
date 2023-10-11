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

namespace bus_network
{
    public partial class Form1 : Form
    {
        BusNetwork busNetwork = new BusNetwork();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddRoute_Click(object sender, EventArgs e)
        {

            if (textBoxNumberRoute.Text == "")
            {
                MessageBox.Show("Введите номер маршрута");
                return;
            }

            if (!Regex.IsMatch(textBoxNumberRoute.Text, @"^\d+$") || textBoxNumberRoute.Text == "0")
            {
                MessageBox.Show("Номер маршрута должен состоять только из цифр\n\n" +
                    "Например: 10, 101");
                return;
            }
            // добавление маршрута в BusNetwork
            busNetwork.AddRoute(Convert.ToInt32(textBoxNumberRoute.Text));

            // очистка DataGridView перед обновлением
            dataGridViewRoutes.Rows.Clear();

            // массив маршрутов из BusNetwork
            BusRoute[] routes = busNetwork.GetAllRoutes();

            // установка количества строк в DataGridView равным количеству маршрутов
            dataGridViewRoutes.RowCount = routes.Length;

            // заполнение DataGridView
            for (int i = 0; i < routes.Length; i++)
            {
                dataGridViewRoutes.Rows[i].Cells[0].Value = routes[i].RouteNumber;
                dataGridViewRoutes.Rows[i].Cells[1].Value = routes[i].CountBuses();
            }

        }

        private void buttonAddBus_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dataGridViewRoutes.CurrentRow;

                if (currentRow.Cells[0].Value != null)
                {
                    if (!Regex.IsMatch(textBoxLicensePlate.Text, @"^[A-ZА-Я]{3}\d{3}$"))
                    {
                        MessageBox.Show("Госномер должен состоять из 3 заглавных букв и 3 цифр без пробелов");
                        return;
                    }

                    if (!Regex.IsMatch(textBoxSurname.Text, "^[A-ZА-Я][a-zа-я]*$"))
                    {
                        MessageBox.Show("Фамилия должна начинаться с заглавной буквы и содержать только буквы");
                        return;
                    }

                    // Получаем номер маршрута из выбранной строки таблицы
                    int routeNumber = (int)currentRow.Cells[0].Value;

                    // Добавляем автобус в выбранный маршрут с использованием нового метода
                    busNetwork.AddBusToRoute(routeNumber, textBoxLicensePlate.Text, textBoxSurname.Text);

                    // Очищаем текстовые поля
                    textBoxLicensePlate.Clear();
                    textBoxSurname.Clear();

                    // массив маршрутов из BusNetwork
                    Bus[] buses = busNetwork.GetAllBusesOnRoute(routeNumber);

                    // установка количества строк в DataGridView равным количеству маршрутов
                    dataGridViewBus.RowCount = buses.Length;

                    // заполнение DataGridView
                    for (int i = 0; i < buses.Length; i++)
                    {
                        dataGridViewBus.Rows[i].Cells[0].Value = buses[i].LicensePlate;
                        dataGridViewBus.Rows[i].Cells[1].Value = buses[i].DriverName;
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран маршрут, к которому нужно добавить автобус");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

    }
}
