using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore
{
    internal class Toy // класс игрушки
    {
        public string Name { get; set; } // название
        public int ArticleNumber { get; set; } // артикул
        public string Manufacturer { get; set; } // производитель
        public decimal Price { get; set; } // стоимость
        public int Quantity { get; set; } // количество
    }
}
