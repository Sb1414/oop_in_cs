using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace educational_institution
{
	public partial class TeacherForm : Form
	{
		public TeacherForm()
		{
			InitializeComponent();
			buttonSave.DialogResult = DialogResult.OK;
			this.AcceptButton = buttonSave;
		}

		public string LastName => textBoxLastName.Text; // геттер для фамилии
		public string Position => textBoxPosition.Text; // геттер для должности
		public int Workload => Convert.ToInt32(numWorkload.Value); // геттер для количества часов

		private void textBoxLastName_Leave(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;

			// проверяем, что поле не пустое
			if (!string.IsNullOrEmpty(textBox.Text))
			{
				// преобразуем первую букву в заглавную
				textBox.Text = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1);
			}
		}

		private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
		{
			// проверяем, является ли введенный символ буквой
			if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
			{
				// если символ не является буквой, блокируем его
				e.Handled = true;
			}
		}

		private void textBoxPosition_KeyPress(object sender, KeyPressEventArgs e)
		{
			// разрешаем ввод только букв, пробела и Backspace
			if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true; // запрещаем ввод других символов
			}
		}

	}
}
