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
            try
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
                UpdateRoutes();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void UpdateRoutes()
        {
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

            textBoxNumberRoute.Clear();

            labelTotalCountBus.Text = "общее число автобусов: " + busNetwork.GetTotalBusesCount();
        }

        private void buttonAddBus_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dataGridViewRoutes.CurrentRow;

                if (dataGridViewRoutes.CurrentRow != null)
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

                    // получаем номер маршрута из выбранной строки таблицы
                    int routeNumber = (int)currentRow.Cells[0].Value;

                    // добавляем автобус в выбранный маршрут с использованием нового метода
                    busNetwork.AddBusToRoute(routeNumber, textBoxLicensePlate.Text, textBoxSurname.Text);

                    // очищаем текстовые поля
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
                    UpdateRoutes();
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

        private void dataGridViewRoutes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int routeNumber = (int)dataGridViewRoutes.Rows[e.RowIndex].Cells[0].Value;

                // получаем автобусы для выбранного маршрута
                Bus[] buses = busNetwork.GetAllBusesOnRoute(routeNumber);

                // очищаем dataGridViewBus перед обновлением
                dataGridViewBus.Rows.Clear();

                if (buses.Length > 0)
                {
                    // установка количества строк в таблице автобусов
                    dataGridViewBus.RowCount = buses.Length;
                }

                // заполняем таблицу с автобусами
                for (int i = 0; i < buses.Length; i++)
                {
                    dataGridViewBus.Rows[i].Cells[0].Value = buses[i].LicensePlate;
                    dataGridViewBus.Rows[i].Cells[1].Value = buses[i].DriverName;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }
    }
}
