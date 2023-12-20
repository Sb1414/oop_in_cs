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
	public partial class DepartmentForm : Form
	{
		public DepartmentForm()
		{
			InitializeComponent();
			buttonSave.DialogResult = DialogResult.OK;
			this.AcceptButton = buttonSave;
		}

		public string DepartmentName => textBoxName.Text; // геттер для названия кафедры

		private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
			{
				// если символ не является буквой или пробелом, блокируем его
				e.Handled = true;
			}
		}
	}
}
