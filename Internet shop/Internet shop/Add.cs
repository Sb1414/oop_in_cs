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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Internet_shop
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
            ok.DialogResult = DialogResult.OK;

            this.AcceptButton = ok;
        }

        public string Name
        {
            get { return (textBoxNameHum.Text); }
        }

        public string Date
        {
            get { return dateTimePickerDate.Text; }
        }

        private void textBoxNameHum_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxNameHum.Text;
            string pattern = @"^[a-zA-Zф-яА-я]+$"; // Регулярное выражение для проверки на буквы

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxNameHum.Text = string.Empty;
                MessageBox.Show("Введите имя!");
            }
            else if (!Regex.IsMatch(input, pattern))
            {
                textBoxNameHum.Text = string.Empty;
                MessageBox.Show("Введите имя, используя только буквы!");
            }
        }

    }
}
