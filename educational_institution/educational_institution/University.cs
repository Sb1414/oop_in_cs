using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace educational_institution
{
	internal class University
	{
		private class DepartmentNode
		{
			public Department Department { get; set; }
			public DepartmentNode Next { get; set; }
			public DepartmentNode Previous { get; set; }

			public DepartmentNode(Department department)
			{
				Department = department;
				Next = null;
				Previous = null;
			}
		}

		private DepartmentNode head;

		public University()
		{
			// создаем заголовочный узел
			head = new DepartmentNode(null);
			head.Next = head;
			head.Previous = head;
		}

		public void AddDepartment(Department department)
		{
			DepartmentNode newNode = new DepartmentNode(department);

			if (head.Next == head)
			{
				// первый добавляемый элемент 
				newNode.Next = head;
				head.Next = newNode;
				newNode.Previous = head;
				head.Previous = newNode;
			}
			else
			{
				DepartmentNode current = head.Next;
				while (current.Next != head && string.Compare(current.Next.Department.DepartmentName, department.DepartmentName) < 0)
				{
					current = current.Next;
				}

				newNode.Next = current.Next;
				current.Next.Previous = newNode;
				newNode.Previous = current;
				current.Next = newNode;
			}
		}

		public void RemoveDepartment(string departmentName)
		{
			DepartmentNode nodeToRemove = FindDepartmentNode(departmentName);

			if (nodeToRemove != null)
			{
				nodeToRemove.Previous.Next = nodeToRemove.Next;
				nodeToRemove.Next.Previous = nodeToRemove.Previous;
			}
		}

		public Department[] GetDepartments()
		{
			List<Department> departments = new List<Department>();
			DepartmentNode current = head.Next;

			while (current != head)
			{
				departments.Add(current.Department);
				current = current.Next;
			}

			return departments.ToArray();
		}

		private DepartmentNode FindDepartmentNode(string departmentName)
		{
			DepartmentNode current = head.Next;

			while (current != head)
			{
				if (current.Department.DepartmentName == departmentName)
				{
					return current;
				}
				current = current.Next;
			}

			return null;
		}

		public bool IsDepartmentUnique(string departmentName)
		{
			return FindDepartmentNode(departmentName) == null;
		}

		public int GetTotalDepartmentCount()
		{
			int count = 0;
			DepartmentNode current = head.Next;

			while (current != head)
			{
				count++;
				current = current.Next;
			}

			return count;
		}

		public Department GetDepartmentByName(string departmentName)
		{
			DepartmentNode node = FindDepartmentNode(departmentName);

			return node != null ? node.Department : null;
		}

		public void AddTeacherToDepartment(string departmentName, string lastName, string position, int workload)
		{
			// Находим кафедру по имени
			Department department = GetDepartmentByName(departmentName);

			if (department != null)
			{
				// Создаем нового преподавателя
				Teacher teacher = new Teacher
				{
					LastName = lastName,
					Position = position,
					Workload = workload
				};

				// Проверяем уникальность фамилии в кафедре
				if (!department.IsTeacherUnique(lastName))
				{
					throw new Exception("Фамилия должна быть уникальной в рамках кафедры");
				}

				// Добавляем преподавателя в кафедру
				department.AddTeacher(teacher);
			}
			else
			{
				throw new Exception("Кафедра с указанным именем не найдена");
			}
		}

		public Teacher[] GetTeachers(string departmentName)
		{
			// Находим кафедру по имени
			Department department = GetDepartmentByName(departmentName);

			if (department != null)
			{
				// Получаем массив преподавателей из кафедры
				return department.GetTeachers();
			}
			else
			{
				Console.WriteLine("нет такой кафедры");
				return new Teacher[0]; // Возвращаем пустой массив, если кафедра не найдена
			}
		}

		public void ClearAllDepartment()
		{
			head.Next = head;
			head.Previous = head;
		}

		public void ClearAllTeacher()
		{
			DepartmentNode current = head.Next;

			while (current != head)
			{
				current.Department.ClearTeachers();
				current = current.Next;
			}
		}

	}

}
