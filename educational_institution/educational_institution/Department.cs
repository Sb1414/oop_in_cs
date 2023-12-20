using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educational_institution
{
	internal class Department
	{
		public string DepartmentName { get; set; }
		private Teacher[] teachersArray;
		private int size;
		private int front;
		private int rear;

		public Department()
		{
			size = 5; // начальный размер массива
			teachersArray = new Teacher[size];
			front = rear = -1;
		}
		public Department(string departmentName)
		{
			DepartmentName = departmentName;
			size = 5; // начальный размер массива
			teachersArray = new Teacher[size];
			front = rear = -1;
		}

		public int TotalCountTeachers()
		{
			return (rear >= front) ? (rear - front + 1) : (size - front + rear + 1);
		}

		public int TotalCount()
		{
			int totalCount = 0;

			if (front != -1)
			{
				int count = (rear >= front) ? (rear - front + 1) : (size - front + rear + 1);

				int j = front;

				while (count > 0)
				{
					totalCount += teachersArray[j].Workload;
					j = (j + 1) % size;
					count--;
				}
			}

			return totalCount;
		}


		public void AddTeacher(Teacher teacher)
		{
			if ((rear + 1) % size == front)
			{
				// Увеличиваем размер массива при необходимости
				ResizeArray();
			}

			if (front == -1)
			{
				front = 0;
				rear = 0;
			}
			else
			{
				rear = (rear + 1) % size;
			}

			teachersArray[rear] = teacher;
		}

		public Teacher RemoveTeacher()
		{
			if (front == -1)
			{
				Console.WriteLine("No teachers in the queue.");
				return null;
			}

			Teacher removedTeacher = teachersArray[front];

			if (front == rear)
			{
				front = rear = -1;
			}
			else
			{
				front = (front + 1) % size;
			}

			return removedTeacher;
		}

		private void ResizeArray()
		{
			int newSize = size * 2;
			Teacher[] newArray = new Teacher[newSize];

			int i = 0;
			int j = front;

			while (j != rear)
			{
				newArray[i++] = teachersArray[j];
				j = (j + 1) % size;
			}

			newArray[i] = teachersArray[rear];
			front = 0;
			rear = i;
			size = newSize;
			teachersArray = newArray;
		}

		public Teacher[] GetTeachers()
		{
			if (front == -1)
			{
				return new Teacher[0];
			}

			int count = (rear >= front) ? (rear - front + 1) : (size - front + rear + 1);
			Teacher[] result = new Teacher[count];

			int i = 0;
			int j = front;

			while (i < count)
			{
				result[i++] = teachersArray[j];
				j = (j + 1) % size;
			}

			return result;
		}

		public bool IsTeacherUnique(string lastName)
		{
			foreach (Teacher teacher in teachersArray)
			{
				if (teacher != null && teacher.LastName == lastName)
				{
					return false; // Преподаватель с такой фамилией уже существует в отделе
				}
			}
			return true; // Преподавателя с такой фамилией нет в отделе
		}

		public void ClearTeachers()
		{
			teachersArray = new Teacher[size];
			front = rear = -1;
		}
	}
}
