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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

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
                if (dataGridViewRoutes.Rows[e.RowIndex].Cells[0].Value != null)
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
        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveFileDialog.Title = "Сохранить данные";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                        {
                            // перебираем все маршруты
                            BusRoute[] routes = busNetwork.GetAllRoutes();
                            foreach (var route in routes)
                            {
                                // перебираем автобусы на данном маршруте
                                Bus[] buses = busNetwork.GetAllBusesOnRoute(route.RouteNumber);
                                if (buses.Length == 0)
                                {
                                    writer.WriteLine($"{route.RouteNumber}\t0\t0");
                                }
                                foreach (var bus in buses)
                                {
                                    // записываем информацию об автобусе
                                    writer.WriteLine($"{route.RouteNumber}\t{bus.LicensePlate}\t{bus.DriverName}");
                                }

                                writer.WriteLine(); // пустая строка между маршрутами
                            }
                        }

                        MessageBox.Show("Данные успешно сохранены.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
                    }
                }
            }
        }

        private void ClearAll()
        {
            dataGridViewBus.Rows.Clear();
            dataGridViewRoutes.Rows.Clear();

            busNetwork.ClearAllRoutes();
            busNetwork.ClearAllBuses();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            // предупреждение о потере данных
            if (dataGridViewRoutes.Rows[0].Cells[0].Value != null)
            {
                DialogResult result = MessageBox.Show("Внимание! Все введенные данные будут удалены. Вы уверены, что хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    return; // отмена загрузки данных
                }
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // очищаем перед загрузкой новых данных
                ClearAll();

                try
                {
                    using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                    {
                        string line;
                        Dictionary<int, BusRoute> existingRoutes = new Dictionary<int, BusRoute>();

                        while ((line = reader.ReadLine()) != null)
                        {
                            // разбиваем строку на части по разделителю (здесь используется табуляция)
                            string[] parts = line.Split('\t');

                            if (parts.Length == 3)
                            {
                                int routeNumber = int.Parse(parts[0]);
                                string licensePlate = parts[1];
                                string driverName = parts[2];

                                BusRoute currentRoute;

                                if (existingRoutes.ContainsKey(routeNumber))
                                {
                                    // если маршрут уже существует, используем существующий
                                    currentRoute = existingRoutes[routeNumber];
                                }
                                else
                                {
                                    // создаем новый маршрут, если он не существует
                                    busNetwork.AddRoute(routeNumber);
                                    currentRoute = new BusRoute(routeNumber);
                                    existingRoutes.Add(routeNumber, currentRoute);
                                }
                                if (licensePlate != "0" && driverName != "0")
                                {
                                    // добавляем автобус к текущему маршруту
                                    busNetwork.AddBusToRoute(routeNumber, licensePlate, driverName);
                                }
                                
                                UpdateRoutes();
                            }
                        }

                        MessageBox.Show("Данные успешно загружены.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
