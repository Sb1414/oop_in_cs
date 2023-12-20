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

			// Проверяем, что поле не пустое
			if (!string.IsNullOrEmpty(textBox.Text))
			{
				// Преобразуем первую букву в заглавную
				textBox.Text = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1);
			}
		}

		private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Проверяем, является ли введенный символ буквой
			if (!char.IsLetter(e.KeyChar))
			{
				// Если символ не является буквой, блокируем его
				e.Handled = true;
			}
		}
	}
}
