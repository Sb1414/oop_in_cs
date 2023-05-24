using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementCompany
{
    internal class Apartment
    {
        private int Number { get; set; }
        private int Payment { get; set; }
        public Apartment(int NumberApartment, int Payment)
        {
            this.Number = NumberApartment;
            this.Payment = Payment;
        }

        public int GetNumber()
        {
            return this.Number;
        }

        public int GetPayment()
        {
            return this.Payment;
        }
    }
}
