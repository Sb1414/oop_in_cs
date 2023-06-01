using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Building
    {
        public string Address { get; set; }
        public decimal ConstructionCost { get; set; }
        public int ConstructionPeriod { get; set; }

        public Building(string address, decimal constructionCost, int constructionPeriod)
        {
            Address = address;
            ConstructionCost = constructionCost;
            ConstructionPeriod = constructionPeriod;
        }
    }
}
