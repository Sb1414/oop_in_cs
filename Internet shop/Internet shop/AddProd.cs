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

namespace Internet_shop
{
    public partial class AddProd : Form
    {
        public AddProd()
        {
            InitializeComponent();
            ok.DialogResult = DialogResult.OK;

            this.AcceptButton = ok;
        }

        public string NameProduct
        {
            get { return textBoxNameProd.Text; }
        }

        public int Price
        {
            get { return int.Parse(textBoxPrice.Text); }
        }

        private void textBoxNameProd_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxNameProd.Text;
            string pattern = @"^[a-zA-Zф-яА-я]+$"; // Регулярное выражение для проверки на буквы

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxNameProd.Text = string.Empty;
                MessageBox.Show("Введите наименование товара!");
            }
            else if (!Regex.IsMatch(input, pattern))
            {
                textBoxNameProd.Text = string.Empty;
                MessageBox.Show("Введите название, используя только буквы!");
            }
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxPrice.Text;
            string pattern = @"^[0-9]+$"; // Регулярное выражение для проверки на числа

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxPrice.Text = string.Empty;
                MessageBox.Show("Введите стоимость товара!");
            }
            else if (!Regex.IsMatch(input, pattern))
            {
                textBoxPrice.Text = string.Empty;
                MessageBox.Show("Вводите только числа!");
            }
        }
    }
}
