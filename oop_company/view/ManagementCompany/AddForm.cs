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

namespace ManagementCompany
{
    public partial class AddForm : Form
    {
        public AddForm(bool isHouse, string street, string number, string count)
        {
            InitializeComponent();

            if (isHouse)
            {
                textBoxApart.Visible = false;
                textBoxPay.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
            } else
            {
                textBoxStreet.Text = street;
                textBoxHouse.Text = number;
                textBoxCount.Text = count;
                textBoxStreet.ReadOnly = true;
                textBoxHouse.ReadOnly = true;
                textBoxCount.ReadOnly = true;
            }

            okButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
        }
        public string Street
        {
            get { return (textBoxStreet.Text); }
        }

        public int House
        {
            get
            {
                if (!string.IsNullOrEmpty(textBoxHouse.Text))
                {
                    return int.Parse(textBoxHouse.Text);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Count
        {
            get
            {
                if (!string.IsNullOrEmpty(textBoxCount.Text))
                {
                    return int.Parse(textBoxCount.Text);
                }
                else
                {
                    return 0;
                }
            }
        }


        public int Apart
        {
            get
            {
                if (!string.IsNullOrEmpty(textBoxApart.Text))
                {
                    return int.Parse(textBoxApart.Text);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Payment
        {
            get
            {
                if (!string.IsNullOrEmpty(textBoxPay.Text))
                {
                    return int.Parse(textBoxPay.Text);
                }
                else
                {
                    return 0;
                }
            }
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string input = textBox.Text;

            // Проверяем, что введены только буквы
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^\p{L}*$"))
            {
                // Введены недопустимые символы
                e.Cancel = true; // Отменить событие, чтобы предотвратить переход к другому элементу
                textBox.Focus(); // Установить фокус на TextBox для повторного ввода

                // Отобразить предупреждающее сообщение
                MessageBox.Show("Введите только буквенные символы.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxNums_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string input = textBox.Text;

            // Проверяем, что введены только числа
            if (!string.IsNullOrWhiteSpace(input) && !int.TryParse(input, out int intValue))
            {
                // Введены недопустимые символы
                e.Cancel = true; // Отменить событие, чтобы предотвратить переход к другому элементу
                textBox.Focus(); // Установить фокус на TextBox для повторного ввода

                // Отобразить предупреждающее сообщение
                MessageBox.Show("Введите только числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
