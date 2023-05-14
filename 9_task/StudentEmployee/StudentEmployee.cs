using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEmployee
{
    public class Person
    {
        public Person(string lastName)
        {
            LastName = lastName;
        }

        public string LastName { get; set; }
    }

    public class Student : Person
    {
        private double tuition;

        public double Tuition
        {
            get { return tuition; }
            set { tuition = value; }
        }

        public Student(string lastName) : base(lastName) {}
    }

    public class Employee : Person
    {

        private double salary;

        public double Salary
    {
            get { return salary; }
            set { salary = value; }
        }

        public Employee(string lastName) : base(lastName) {}
    }

    public interface IStudent
    {
        double Tuition { get; set; }
    }

    public interface IEmployee
    {
        double Salary { get; set; }
    }

    public class Student_Employee : Person, IStudent, IEmployee
    {
        public double Tuition { get; set; }
        public double Salary { get; set; }

        public double TotalPayment { get { return Tuition + Salary; } }

        public Student_Employee(string lastName) : base(lastName) {}
    }

    // интерфейсный класс для контейнера объектов
    interface IPersonContainer
    {
        void Add(Person person);
        Person Get(int index);
        List<Person> GetAll();
    }

    // реализация контейнера объектов на основе массива полиморфных ссылок
    class PersonArrayContainer : IPersonContainer
    {
        private Person[] persons = new Person[0];

        public void Add(Person person)
        {
            Array.Resize(ref persons, persons.Length + 1);
            persons[persons.Length - 1] = person;
        }

        public Person Get(int index)
        {
            if (index >= 0 && index < persons.Length)
                return persons[index];
            else
                return null;
        }

        public List<Person> GetAll()
        {
            return new List<Person>(persons);
        }
    }
}
