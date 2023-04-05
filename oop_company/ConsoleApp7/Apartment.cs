using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Apartment
    {
        public int Number { get; private set; }
        public int Payment { get; private set; }
        public Apartment(int NumberApartment, int Payment)
        {
            this.Number = NumberApartment;
            this.Payment = Payment;
        }
    }
}
