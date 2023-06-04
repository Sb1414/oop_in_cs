using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditOrganization
{
    abstract class Credit
    {
        protected string fullName;
        protected decimal loanAmount;

        public Credit(string fullName, decimal loanAmount)
        {
            this.fullName = fullName;
            this.loanAmount = loanAmount;
        }

        public string FullName { get { return fullName; } }
        public decimal LoanAmount { get { return loanAmount; } }

        public abstract void DisplayData();
    }

    class MortgageCredit : Credit
    {
        private string address;

        public MortgageCredit(string fullName, decimal loanAmount, string address)
            : base(fullName, loanAmount)
        {
            this.address = address;
        }

        public string Address { get { return address; } }

        public override void DisplayData()
        {
            Console.WriteLine("Тип: ипотечный кредит");
            Console.WriteLine("ФИО: " + FullName);
            Console.WriteLine("сумма кредита: " + LoanAmount);
            Console.WriteLine("адрес проживания: " + address);
        }
    }

    class AutoCredit : Credit
    {
        private string carBrand;

        public AutoCredit(string fullName, decimal loanAmount, string carBrand)
            : base(fullName, loanAmount)
        {
            this.carBrand = carBrand;
        }

        public string CarBrand { get { return carBrand; } }

        public override void DisplayData()
        {
            Console.WriteLine("Тип: Автокредит");
            Console.WriteLine("ФИО: " + FullName);
            Console.WriteLine("сумма кредита: " + LoanAmount);
            Console.WriteLine("марка автомобиля: " + carBrand);
        }
    }

}
