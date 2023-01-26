using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    sealed class Person
    {
        public string surname { get; set; }
        public double loanAmount { get; set; }
        public double[] payments { get; set; }
        public double remainsToPay { get; set; }

        public Person(string surname, double loanAmount, double[] payments, double remainsToPay)
        {
            this.surname = surname;
            this.loanAmount = loanAmount;
            this.payments = payments;
            this.remainsToPay = remainsToPay;
        }

        public void ChangeSurname(Person student, string surname)
        {
            if (student != null)
            {
                student.surname = surname;
            }
        }

        public void ChangeGroup(Person student, double loanAmount)
        {
            if (student != null)
            {
                student.loanAmount = loanAmount;
            }
        }

        /*
        public double CompareTo(Student that)
        {
            return String.Compare(surname, that.surname, System.StringComparison.Ordinal);
        } 
        */
    }
}
