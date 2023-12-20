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

namespace educational_institution
{
	public partial class Form1 : Form
	{
		University university = new University();
		public Form1()
		{
			InitializeComponent();
		}

		private void UpdateGrids()
		{
			// очистка DataGridView перед обновлением
			dataGridViewDepartment.Rows.Clear();

			// массив кафедр из 
			Department[] departments = university.GetDepartments();
			if (departments.Length > 0)
			{
				// установка количества строк в DataGridView равным количеству кафедр
				dataGridViewDepartment.RowCount = departments.Length;

				// заполнение DataGridView
				for (int i = 0; i < departments.Length; i++)
				{
					dataGridViewDepartment.Rows[i].Cells[0].Value = departments[i].DepartmentName;
					dataGridViewDepartment.Rows[i].Cells[1].Value = departments[i].TotalCountTeachers();
					dataGridViewDepartment.Rows[i].Cells[2].Value = departments[i].TotalCount();
				}
			}
			labelTotalCountDepart.Text = "общее число кафедр: " + university.GetTotalDepartmentCount();
		}

		private void addDepartment_Click(object sender, EventArgs e)
		{
			try
			{
				DepartmentForm add = new DepartmentForm();

				if (add.ShowDialog() == DialogResult.OK)
				{
					string name = add.DepartmentName;

					// Проверка на уникальность адреса
					if (!university.IsDepartmentUnique(name))
					{
						throw new Exception("Кафедра с таким названием уже существует.");
					}

					// добавление дома
					Department department = new Department(name);
					university.AddDepartment(department);
					UpdateGrids();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}");
			}
		}

		private void addTeacher_Click(object sender, EventArgs e)
		{
			try
			{
				DataGridViewRow currentRow = dataGridViewDepartment.CurrentRow;

				if (currentRow == null)
				{
					throw new Exception("Не выбрана кафедра, к которой нужно добавить преподавателя");
				}
				// получаем название кафедры из выбранной строки таблицы
				string name = currentRow.Cells[0].Value?.ToString();

				TeacherForm add = new TeacherForm();

				if (add.ShowDialog() == DialogResult.OK)
				{
					string lastName = add.LastName;
					string position = add.Position;
					int workload = add.Workload;

					// добавляем преподавателя в выбранную кафедру
					university.AddTeacherToDepartment(name, lastName, position, workload);

					// массив квартир у дома
					Teacher[] teachers = university.GetTeachers(name);

					// установка количества строк в DataGridView равным количеству квартир
					dataGridViewTeacher.RowCount = teachers.Length;

					// заполнение DataGridView
					for (int i = 0; i < teachers.Length; i++)
					{
						dataGridViewTeacher.Rows[i].Cells[0].Value = teachers[i].LastName;
						dataGridViewTeacher.Rows[i].Cells[1].Value = teachers[i].Position;
						dataGridViewTeacher.Rows[i].Cells[2].Value = teachers[i].Workload;
					}
					UpdateGrids();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}");
			}
		}

		private void ClearAll()
		{
			dataGridViewDepartment.Rows.Clear();
			dataGridViewTeacher.Rows.Clear();

			university.ClearAllDepartment();
			university.ClearAllTeacher();
			labelTotalCountDepart.Text = "общее число кафедр: " + university.GetTotalDepartmentCount();
		}

		private void Load_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

			// предупреждение о потере данных
			if (dataGridViewDepartment.Rows[0].Cells[0].Value != null)
			{
				DialogResult result = MessageBox.Show("Внимание! Все введенные данные будут удалены. Вы уверены, что хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result != DialogResult.Yes)
				{
					return; // отмена загрузки данных
				}
			}

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string filePath = openFileDialog.FileName;

				// очищаем перед загрузкой новых данных
				ClearAll();

				try
				{
					using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
					{
						string line;
						Dictionary<string, Department> existingDepartment = new Dictionary<string, Department>();

						while ((line = reader.ReadLine()) != null)
						{
							// разбиваем строку на части по разделителю (здесь используется табуляция)
							string[] parts = line.Split('\t');

							if (parts.Length == 4)
							{
								string name = parts[0];
								string lastName = parts[1];
								string position = parts[2];
								int workload = int.Parse(parts[3]);

								Department currentDepartment;

								if (existingDepartment.ContainsKey(name))
								{
									// если кафедра уже существует, используем существующий
									currentDepartment = existingDepartment[name];
								}
								else
								{
									// создаем новую кафедру, если она не существует
									currentDepartment = new Department(name);
									university.AddDepartment(currentDepartment);
									existingDepartment.Add(name, currentDepartment);
								}
								if (workload != 0 && lastName != "0" && position != "0")
								{
									// добавляем препода к текущей кафедре
									university.AddTeacherToDepartment(name, lastName, position, workload);
								}

								UpdateGrids();
								UpdateTeacher(name);
							}
						}
						MessageBox.Show("Данные успешно загружены.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
				}
			}
		}

		private void UpdateTeacher(string name)
		{
			// очистка таблицы перед обновлением
			dataGridViewTeacher.Rows.Clear();

			// получаем преподов по кафедре
			Teacher[] teachers = university.GetTeachers(name);

			if (teachers.Length > 0)
			{
				// установка количества строк в таблице преподов
				dataGridViewTeacher.RowCount = teachers.Length;
			}

			// заполняем таблицу с преподами
			for (int i = 0; i < teachers.Length; i++)
			{
				dataGridViewTeacher.Rows[i].Cells[0].Value = teachers[i].LastName;
				dataGridViewTeacher.Rows[i].Cells[1].Value = teachers[i].Position;
				dataGridViewTeacher.Rows[i].Cells[2].Value = teachers[i].Workload;
			}
		}
		private void dataGridViewDepartment_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex >= 0)
				{
					if (dataGridViewDepartment.Rows[e.RowIndex].Cells[0].Value != null)
					{
						string name = dataGridViewDepartment.Rows[e.RowIndex].Cells[0].Value?.ToString();

						// получаем преподов по кафедре
						Teacher[] teachers = university.GetTeachers(name);

						// очищаем dataGridView перед обновлением
						dataGridViewTeacher.Rows.Clear();

						if (teachers.Length > 0)
						{
							// установка количества строк в таблице 
							dataGridViewTeacher.RowCount = teachers.Length;
						}

						// заполняем таблицу с преподами
						for (int i = 0; i < teachers.Length; i++)
						{
							dataGridViewTeacher.Rows[i].Cells[0].Value = teachers[i].LastName;
							dataGridViewTeacher.Rows[i].Cells[1].Value = teachers[i].Position;
							dataGridViewTeacher.Rows[i].Cells[2].Value = teachers[i].Workload;
						}
					}
				}
			}
			catch (Exception)
			{
				dataGridViewTeacher.Rows.Clear();
			}
		}

		private void Save_Click(object sender, EventArgs e)
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
							// перебираем все кафедры
							Department[] departments = university.GetDepartments();
							foreach (var department in departments)
							{
								// перебираем преподов в данной кафедре
								Teacher[] teachers = university.GetTeachers(department.DepartmentName);
								if (teachers.Length == 0)
								{
									writer.WriteLine($"{department.DepartmentName}\t0\t0\t0");
								}
								foreach (var t in teachers)
								{
									// записываем информацию о преподе
									writer.WriteLine($"{department.DepartmentName}\t{t.LastName}\t{t.Position}\t{t.Workload}");
								}

								writer.WriteLine(); // пустая строка между кафедрами
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
	}
}
