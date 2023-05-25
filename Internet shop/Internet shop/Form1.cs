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
                
                if (shop.IsPersonExists(addForm.Name))
                {
                    int num = shop.GetOrderNumberByName(addForm.Name);
                    foreach (DataGridViewRow row in dataGridViewOrder.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == addForm.Name)
                        {
                            row.Cells[1].Value = addForm.Date;
                            row.Cells[2].Value = shop.GetTotalOrderAmount(addForm.Name);
                        }
                    }
                }
                else 
                {
                    shop.AddOrder(addForm.Name, addForm.Date);
                    int num = shop.GetOrderNumberByName(addForm.Name);
                    dataGridViewOrder.Rows.Add(addForm.Name, addForm.Date, shop.GetTotalOrderAmount(addForm.Name));

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

                string name_ = selectedRow.Cells[0].Value?.ToString();
                if (selectedRow.Cells[0].Value == null)
                {
                    dataGridViewProduct.Rows.Clear();
                    return;
                }
                Order order = shop.FindOrder(name_);
                if (order != null)
                {
                    Product[] prods = shop.GetProductsByCustomerName(name_);
                    for (int i = 0; i < prods.Count(); i++)
                    {
                        if (i == 0 && dataGridViewProduct.Rows[0].Cells[0].Value != null)
                        {
                            dataGridViewProduct.Rows.Clear();
                        }
                        string namePers = dataGridViewOrder.CurrentRow.Cells[0].Value?.ToString();
                        string date = dataGridViewOrder.CurrentRow.Cells[1].Value?.ToString();
                        dataGridViewProduct.Rows.Add(shop.GetOrderNumberByName(namePers), prods[i].GetName(), prods[i].GetPrice());
                    }
                    if (prods.Count() == 0)
                    {
                        dataGridViewProduct.Rows.Clear();
                    }
                }
                else
                {
                    dataGridViewProduct.Rows.Clear();

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

                dataGridViewOrder.Rows.Clear();
                dataGridViewProduct.Rows.Clear();

                shop.RemoveAllOrders();
                shop.RemoveAllProducts();

                Dictionary<string, bool> Entries = new Dictionary<string, bool>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split('\t');
                        string Key = columns[0] + columns[1] + columns[2];

                        if (!Entries.ContainsKey(Key))
                        {
                            shop.AddOrder(columns[0], columns[1]);
                            dataGridViewOrder.Rows.Add(columns[0], columns[1], columns[2]);
                            Entries.Add(Key, true);
                        }

                        if (columns[3] != "-" && columns[4] != "-" && columns[5] != "-")
                        {
                            shop.AddProductToOrder(columns[0], columns[4], Convert.ToInt32(columns[5]));
                        }
                    }
                }
                MessageBox.Show("Информация успешно загружена");
            }
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
