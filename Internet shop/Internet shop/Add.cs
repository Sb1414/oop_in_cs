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
            get { return textBoxDate.Text; }
        }
                
        private void textBoxDate_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxDate.Text;
            string pattern = @"^\d{2}\.\d{2}\.\d{2}$"; // Регулярное выражение для формата даты "дд.мм.гг"

            if (!Regex.IsMatch(input, pattern))
            {
                // Если введенный текст не соответствует формату даты, очищаем поле
                textBoxDate.Text = string.Empty;
                MessageBox.Show("Вводите дату в формате: дд.мм.гг");
            }
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

        private void textBoxDate_Validating(object sender, CancelEventArgs e)
        {
            string input = textBoxDate.Text;
            string pattern = @"^\d{2}\.\d{2}\.\d{2}$"; // Регулярное выражение для формата даты "дд.мм.гг"

            if (!Regex.IsMatch(input, pattern))
            {
                e.Cancel = true; // Отменить событие, чтобы оставить фокус в поле ввода
                textBoxDate.SelectAll(); // Выделить весь текст в поле для удобного исправления
                MessageBox.Show("Вводите дату в формате: дд.мм.гг");
            }
        }

    }
}
