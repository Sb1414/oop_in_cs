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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Internet_shop
{
    public partial class Form1 : Form
    {
        Shop shop = new Shop();
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonAddInfo_Click(object sender, EventArgs e)
        {
            Add addForm = new Add();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                string name = addForm.Name;
                string date = addForm.Date;

                if (shop.IsPersonExists(name))
                {
                    int orderNumber = shop.GetOrderNumberByName(name);

                    foreach (DataGridViewRow row in dataGridViewOrder.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == name)
                        {
                            row.Cells[1].Value = date;
                            row.Cells[2].Value = shop.GetTotalOrderAmount(name);
                        }
                    }
                }
                else
                {
                    shop.AddOrder(name, date);
                    dataGridViewOrder.Rows.Add(name, date, shop.GetTotalOrderAmount(name));
                }
            }
        }


        private void AddOrder_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewOrder.CurrentRow;
            if (currentRow.Cells[0].Value != null)
            {
                AddProd addForm = new AddProd();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    string name = currentRow.Cells[0].Value?.ToString();
                    if (shop.IsPersonExists(name))
                    {
                        int num = shop.GetOrderNumberByName(name);
                        shop.AddProductToOrder(num, addForm.NameProduct, addForm.Price);
                        dataGridViewProduct.Rows.Add(num, addForm.NameProduct, addForm.Price);
                        currentRow.Cells[2].Value = Convert.ToInt32(currentRow.Cells[2].Value) + shop.GetTotalOrderAmount(name);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбран заказчик, которому нужно добавить заказ");
            }
        }

        private void dataGridViewOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewOrder.Rows[e.RowIndex];
                string name = selectedRow.Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(name))
                {
                    dataGridViewProduct.Rows.Clear();;
                    return;
                }

                Order order = shop.FindOrder(name);
                if (order != null)
                {
                    Product[] products = shop.GetProductsByCustomerName(name);
                    UpdateProductRows(name, products);
                }
                else
                {
                    dataGridViewProduct.Rows.Clear();;
                }
            }
        }

        private void UpdateProductRows(string customerName, Product[] products)
        {
            if (products.Length == 0)
            {
                dataGridViewProduct.Rows.Clear();;
            }
            else
            {
                if (dataGridViewProduct.Rows[0].Cells[0].Value != null)
                {
                    dataGridViewProduct.Rows.Clear();;
                }

                foreach (Product product in products)
                {
                    string productName = product.GetName();
                    decimal price = product.GetPrice();
                    int orderNumber = shop.GetOrderNumberByName(customerName);

                    dataGridViewProduct.Rows.Add(orderNumber, productName, price);
                }
            }
        }


        private void LoadFromFileInfo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                ClearData();

                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] columns = line.Split('\t');
                    string name = columns[0];
                    string date = columns[1];
                    string totalOrderAmount = columns[2];

                    if (!shop.IsPersonExists(name))
                    {
                        shop.AddOrder(name, date);
                        dataGridViewOrder.Rows.Add(name, date, totalOrderAmount);
                    }

                    if (columns[3] != "-" && columns[4] != "-" && columns[5] != "-")
                    {
                        string productName = columns[4];
                        int price = Convert.ToInt32(columns[5]);
                        shop.AddProductToOrder(name, productName, price);
                    }
                }

                MessageBox.Show("Информация успешно загружена");
            }
        }

        private void ClearData()
        {
            dataGridViewOrder.Rows.Clear();
            dataGridViewProduct.Rows.Clear();
            shop.RemoveAllOrders();
            shop.RemoveAllProducts();
        }


        private void SaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    Order[] orders = shop.GetAllOrders();

                    foreach (Order order in orders)
                    {
                        string name_ = order.GetName();
                        string date_ = order.GetDate();
                        int sum = shop.GetTotalOrderAmount(name_);

                        Product[] products = shop.GetAllProductsByName(name_);

                        if (products.Count() > 0)
                        {
                            foreach (Product prod in products)
                            {
                                int num = shop.GetOrderNumberByName(name_);
                                string nameProd_ = prod.GetName();
                                int price_ = prod.GetPrice();

                                writer.WriteLine($"{name_}\t{date_}\t{sum}\t{num}\t{nameProd_}\t{price_}");
                            }
                        }
                        else
                        {
                            writer.WriteLine($"{name_}\t{date_}\t{sum}\t-\t-\t-");
                        }
                    }
                }
                MessageBox.Show("Сохранено");
            }
        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProduct.CurrentRow != null)
                {
                    DataGridViewRow currentRow = dataGridViewProduct.Rows[0];

                    string name_ = dataGridViewProduct.Rows[0].Cells[1].Value?.ToString();
                    int price_ = Convert.ToInt32(currentRow.Cells[2].Value?.ToString());

                    shop.RemoveProduct(name_, price_);
                    dataGridViewProduct.Rows.Remove(currentRow);
                }
                else
                {
                    throw new Exception("Нечего удалять!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void deleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewOrder.CurrentRow != null)
                {
                    DataGridViewRow currentRow = dataGridViewOrder.CurrentRow;

                    string name = currentRow.Cells[0].Value?.ToString();

                    dataGridViewProduct.Rows.Clear();

                    dataGridViewOrder.Rows.Remove(currentRow);
                    shop.RemoveOrderAndProductsByCustomerName(name);
                }
                else
                {
                    throw new Exception("Наведите курсор в ячейку, которую нужно удалить!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void toolStripButtonsearch_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "" && Regex.IsMatch(toolStripTextBox1.Text, @"^[0-9]+$"))
            {
                int orderNumber = int.Parse(toolStripTextBox1.Text);
                Order order = shop.FindOrderByNumber(orderNumber);
                if (order != null)
                {
                    string orderInfo = $"Номер заказа: {orderNumber}\n";
                    orderInfo += $"Имя заказчика: {order.GetName()}\n";
                    orderInfo += $"Дата: {order.GetDate()}\n";
                    orderInfo += $"Общая сумма: {order.GetSumOfOrder()}";

                    MessageBox.Show(orderInfo, "Информация о заказе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не найдено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ничего не введено в поле слева! Нужно ввести число (номер заказа)");
            }
        }

        private void AllPrice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Суммарная стоимость всех заказов: " + shop.CalculateTotalOrderCost().ToString(), "Информация о сумме из всех заказов");
        }
    }
}
