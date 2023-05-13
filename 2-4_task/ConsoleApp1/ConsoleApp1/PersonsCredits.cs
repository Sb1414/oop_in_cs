using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class PersonsCredits
    {
        List<Person> persons = new List<Person>();

        public void AddPerson(string surname, double loanAmount, double[] payments, double remainsToPay)
        {
            Person student = new Person(surname, loanAmount, payments, remainsToPay);
            persons.Add(student);
        }

        public void RemovePerson(int id)
        {
            persons.RemoveAt(id);
        }

        public void AddAtPerson(int id, string surname, double loanAmount, double[] payments, double remainsToPay)
        {
            Person student = new Person(surname, loanAmount, payments, remainsToPay);
            persons.Insert(id, student);
        }

        public string GetPersonSurname(int id)
        {
            return persons[id].surname;
        }

        public double GetCountPerson()
        {
            return persons.Count;
        }

        public string GetPerson(int id)
        {
            return persons[id].surname + " " + persons[id].loanAmount;
        }

        public void ShowAllPerson()
        {
            Console.WriteLine("Информация о кредитоплательщике: ");
            Console.WriteLine("№\tФамилия\t   Сумма кредита\tСумма выплат\tВыплаты");
            int cnt = 0;
            foreach (var student in persons)
            {
                cnt++;
                string m = "";
                for (int i = 0; i < student.payments.Length; i++)
                {
                    m += student.payments[i].ToString() + " ";
                }
                Console.WriteLine(cnt + "\t" + student.surname + "   \t" + student.loanAmount + "   \t" + student.remainsToPay + "   \t" + m);
            }
        }

        public void ShowOnePerson(int ii)
        {
            Console.WriteLine("Информация о кредитоплательщике: ");
            Console.WriteLine("Фамилия\t    Сумма кредита\tВыплаты");

            string m = "";
            double sum = 0;
            for (int i = 0; i < persons[ii].payments.Length; i++)
            {
                sum += persons[ii].payments[i];
                m += persons[ii].payments[i].ToString() + " ";
            }
            Console.WriteLine(persons[ii].surname + "   \t" + persons[ii].loanAmount + "   \t" + m);
            if (sum >= persons[ii].loanAmount)
            {
                Console.WriteLine("Кредит погашен");
                double raznitca = sum - persons[ii].loanAmount;
                Console.WriteLine("Переплата составляет " + raznitca + " рублей\n");
            } else
            {
                double raznitca = persons[ii].loanAmount - sum;
                Console.WriteLine("Для погашения кредита осталось внести " + raznitca + " рублей\n");
            }
        }

        public void ShowFullInfo()
        {
            Console.WriteLine("Информация о кредитоплательщике: ");
            double sumPay = 0, sumLoanAmount = 0;

            foreach (var student in persons)
            {
                sumLoanAmount += student.loanAmount;
                for (int i = 0; i < student.payments.Length; i++)
                {
                    sumPay += student.payments[i];
                }
            }
            Console.WriteLine("Общая сумма всех активных кредитов: " + sumLoanAmount);
            Console.WriteLine("Общая сумма всех активных выплат кредитов: " + sumPay);
        }

        public double GetAmount()
        {
            return persons.Count;
        }
    }
}
