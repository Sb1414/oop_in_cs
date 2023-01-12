using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    sealed class Student : IComparable<Student>
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string group { get; set; }
        public Student(string name, string surname, string group)
        {
            this.name = name;
            this.surname = surname;
            this.group = group;
        }

        public void ChangeName(Student student, string name)
        {
            if (student != null && student.name != name)
            {
                student.name = name;
            }
        }

        public void ChangeSurname(Student student, string surname)
        {
            if (student != null && student.name != surname)
            {
                student.surname = surname;
            }
        }

        public void ChangeGroup(Student student, string group)
        {
            if (student != null && student.name != group)
            {
                student.group = group;
            }
        }

        public int CompareTo(Student that)
        {
            return String.Compare(name, that.name, System.StringComparison.Ordinal);
        }
    }
}
