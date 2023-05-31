using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cargo_transportation
{
    public partial class Form1 : Form
    {
        int count_ = 7;
        TransportQueue transportQueue;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSurname.Text == "" && textBoxLicensePlate.Text == "")
                {
                    throw new Exception("Ничего не введено");
                }

                // Проверка ввода для textBoxSurname с использованием регулярного выражения
                if (!Regex.IsMatch(textBoxSurname.Text, @"^(\w+\s){2}\w+$"))
                {
                    throw new Exception("ФИО должно содержать 3 слова: Фамилию, Имя, Отчество");
                }

                // Проверка ввода для textBoxLicensePlate с использованием регулярного выражения
                if (!Regex.IsMatch(textBoxLicensePlate.Text, @"^[A-ZА-Я]{3}\d{3}$"))
                {
                    throw new Exception("Госномер должен состоять из 3 заглавных букв и 3 цифр без пробелов");
                }

                if (transportQueue == null)
                {
                    throw new Exception("Установите количество автомобилей в кольцевой очереди на массиве (кнопка сверху \"Выбрать\")");
                }

                transportQueue.AddVehicle(textBoxLicensePlate.Text, textBoxSurname.Text);

                // Получение всех транспортов
                Vehicle[] vehicles = transportQueue.GetAllVehicles();

                // Очистка dataGridView1 перед обновлением данных
                dataGridView1.Rows.Clear();

                // Вывод данных в dataGridView1
                foreach (Vehicle vehicle in vehicles)
                {
                    dataGridView1.Rows.Add(vehicle.LicensePlate, vehicle.DriverSurname, transportQueue.GetTotalCargoVolume(vehicle));
                }
                toolStripLabelAllVol.Text = "Общий объем груза: " + transportQueue.CalculateTotalCargoVolume();
                textBoxSurname.Text = "";
                textBoxLicensePlate.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void editCount_Click(object sender, EventArgs e)
        {
            edit editForm = new edit();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                count_ = editForm.CountQueue;
                transportQueue = new TransportQueue(count_);
                toolStripLabelMaxSize.Text = "Max Size = " + count_;
            }
        }

        private void removeVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                if (transportQueue == null || transportQueue.Count() == 0)
                {
                    throw new Exception("Очередь автомобилей пуста");
                }

                transportQueue.RemoveVehicle();
                UpdateTransport();
                toolStripLabelAllVol.Text = "Общий объем груза: " + transportQueue.CalculateTotalCargoVolume();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTransport()
        {
            // Получение всех транспортов
            Vehicle[] transportVehicles = transportQueue.GetAllVehicles();

            // Очистка dataGridView1 перед обновлением данных
            dataGridView1.Rows.Clear();

            // Вывод данных в dataGridView1
            foreach (Vehicle vehicle in transportVehicles)
            {
                dataGridView1.Rows.Add(vehicle.LicensePlate, vehicle.DriverSurname, transportQueue.GetTotalCargoVolume(vehicle));
            }
        }

        private void buttonAddShipment_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dataGridView1.CurrentRow;

                if (currentRow.Cells[0].Value != null)
                {
                    if (textBoxTime.Text == "" && textBoxVolume.Text == "")
                    {
                        MessageBox.Show("Ничего не введено");
                        return;
                    }

                    // Проверка формата времени
                    if (!TimeSpan.TryParseExact(textBoxTime.Text, "hh\\:mm", CultureInfo.InvariantCulture, out _))
                    {
                        throw new Exception("Неправильный формат времени. Используйте формат 'чч:мм'");
                    }

                    // Проверка формата числа
                    if (!double.TryParse(textBoxVolume.Text, out _))
                    {
                        throw new Exception("Неправильный формат объема. Введите числовое значение.");
                    }

                    string licensePlate = currentRow.Cells[0].Value?.ToString();

                    if (transportQueue.IsLicensePlateExists(licensePlate))
                    {
                        string startTime = textBoxTime.Text;
                        double cargoVolume = double.Parse(textBoxVolume.Text);

                        transportQueue.AddShipmentToVehicle(licensePlate, startTime, cargoVolume);

                        // Обновление dataGridView2
                        UpdateDataGridView2(licensePlate);
                        // Обновление значения общего объема в dataGridView1
                        Vehicle vehicle = transportQueue.FindVehicle(licensePlate);
                        if (vehicle != null)
                        {
                            currentRow.Cells[2].Value = transportQueue.GetTotalCargoVolume(vehicle);
                        }
                        toolStripLabelAllVol.Text = "Общий объем груза: " + transportQueue.CalculateTotalCargoVolume();
                        textBoxVolume.Text = "";
                        textBoxTime.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Госномер не существует в очереди");
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрана машина, к которой нужно добавить рейс");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void UpdateDataGridView2(string licensePlate)
        {
            // Очистка dataGridView2 перед обновлением данных
            dataGridView2.Rows.Clear();

            // Получение рейсов по госномеру
            Shipment[] shipments = transportQueue.GetShipments(licensePlate);

            // Вывод данных в dataGridView2
            foreach (Shipment shipment in shipments)
            {
                dataGridView2.Rows.Add(shipment.StartTime, shipment.CargoVolume);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string licensePlate = selectedRow.Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(licensePlate))
                {
                    dataGridView2.Rows.Clear(); ;
                    return;
                }
                // Получение рейсов по госномеру
                Shipment[] shipments = transportQueue.GetShipments(licensePlate);

                if (shipments != null)
                {
                    UpdateDataGridView2(licensePlate);
                }
                else
                {
                    dataGridView2.Rows.Clear();
                }
            }
        }

        private void removeShipment_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView2.CurrentRow;

            if (selectedRow != null && !selectedRow.IsNewRow)
            {
                DataGridViewCellCollection cells = selectedRow.Cells;

                string licensePlate = dataGridView1.CurrentRow.Cells[0].Value?.ToString();
                string startTime = cells[0].Value?.ToString();
                double cargoVolume;

                if (double.TryParse(cells[1].Value?.ToString(), out cargoVolume))
                {
                    Vehicle vehicle = transportQueue.FindVehicle(licensePlate);

                    if (vehicle != null)
                    {
                        transportQueue.RemoveShipment(licensePlate, startTime, cargoVolume);

                        // Обновление dataGridView2
                        UpdateDataGridView2(licensePlate);
                        dataGridView1.CurrentRow.Cells[2].Value = transportQueue.GetTotalCargoVolume(vehicle);
                        toolStripLabelAllVol.Text = "Общий объем груза: " + transportQueue.CalculateTotalCargoVolume();
                    }
                    else
                    {
                        MessageBox.Show("Автомобиль не найден");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат объема груза или не выбрана нужная строка");
                }
            }
            else
            {
                MessageBox.Show("Не выбран рейс для удаления");
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                openFileDialog.Title = "Выберите файл с данными";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                        {
                            if (transportQueue != null)
                                transportQueue.Clear(); // Очищаем очередь перед загрузкой данных

                            // Считываем максимальное количество автомобилей в очереди
                            int maxCapacity = int.Parse(reader.ReadLine());
                            transportQueue = new TransportQueue(maxCapacity);

                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] data = line.Split('\t');
                                if (data.Length == 4)
                                {
                                    string licensePlate = data[0];
                                    string driverSurname = data[1];
                                    string startTime = data[2];
                                    double cargoVolume = double.Parse(data[3]);

                                    Vehicle vehicle = transportQueue.FindVehicle(licensePlate);
                                    if (vehicle == null)
                                    {
                                        transportQueue.AddVehicle(licensePlate, driverSurname);
                                    }
                                    if (startTime != "0" && cargoVolume != 0)
                                    {
                                        transportQueue.AddShipmentToVehicle(licensePlate, startTime, cargoVolume);
                                    }
                                }
                            }
                            toolStripLabelMaxSize.Text = "Max Size = " + maxCapacity;
                        }
                        UpdateTransport();
                        toolStripLabelAllVol.Text = "Общий объем груза: " + transportQueue.CalculateTotalCargoVolume();
                        MessageBox.Show("Данные успешно загружены.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                    }
                }
            }
        }


        private void save_Click(object sender, EventArgs e)
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
                            // Записываем максимальное количество автомобилей в очереди
                            int maxCapacity = transportQueue.GetCapacity();
                            writer.WriteLine(maxCapacity);
                            // Записываем данные об автомобилях
                            Vehicle[] vehicles = transportQueue.GetAllVehicles();
                            foreach (Vehicle vehicle in vehicles)
                            {
                                Shipment[] shipments = vehicle.GetShipments();
                                Console.WriteLine(shipments.Length + " <--- len");
                                if (shipments.Length == 0)
                                {
                                    writer.WriteLine($"{vehicle.LicensePlate}\t{vehicle.DriverSurname}\t0\t0");
                                }
                                foreach (Shipment shipment in shipments)
                                {
                                    writer.Write($"{vehicle.LicensePlate}\t{vehicle.DriverSurname}\t");
                                    writer.WriteLine($"{shipment.StartTime}\t{shipment.CargoVolume}");
                                }
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

        private void clear_Click(object sender, EventArgs e)
        {
            transportQueue.Clear(); // Очищаем объект TransportQueue
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            toolStripLabelAllVol.Text = "Общий объем груза: 0";
            toolStripLabelMaxSize.Text = "Max Size = 0";
        }

    }
}
