using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class StudentGroup
    {
        List<Student> students = new List<Student>();

        public void AddStudent(string name, string surname, string group)
        {
            Student student = new Student(name, surname, group);
            students.Add(student);
        }

        public void RemoveStudent(int id)
        {
            students.RemoveAt(id);
        }

        public void AddAtStudent(int id, string name, string surname, string group)
        {
            Student student = new Student(name, surname, group);
            students.Insert(id, student);
        }

        public string GetStudentNameAndSurname(int id)
        {
            return students[id].name + " " + students[id].surname;
        }

        public int GetCountStudents()
        {
            return students.Count;
        }

        public string GetStudent(int id)
        {
            return students[id].name + " " + students[id].surname + " " + students[id].group;
        }

        public void ShowAllStudent()
        {
            Console.WriteLine("Информация о студентах: ");
            Console.WriteLine("Имя\tФамилия\tГруппа");
            foreach (var student in students)
            {
                Console.WriteLine(student.name + "\t" + student.surname + "\t" + student.group);
            }
        }

        public int GetAmount()
        {
            return students.Count;
        }
    }
}
