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

            // Очистка DataGridView перед обновлением
            dataGridViewRoutes.Rows.Clear();

            // Массив маршрутов из BusNetwork
            BusRoute[] routes = busNetwork.GetAllRoutes();

            // Установка количества строк в DataGridView равным количеству маршрутов
            dataGridViewRoutes.RowCount = routes.Length;

            // Заполнение DataGridView
            for (int i = 0; i < routes.Length; i++)
            {
                dataGridViewRoutes.Rows[i].Cells[0].Value = routes[i].RouteNumber;
            }

        }
    }
}
