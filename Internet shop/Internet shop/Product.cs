using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Product
    {
        private Product Next;
        private string Name;
        private int Price;

        public Product(string aName, int aPrice)
        {
            Name = aName;
            Price = aPrice;
            this.Next = Next;
        }

        public Product GetNext() => Next;

        public void SetNext(Product Next)
        {
            this.Next = Next;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetPrice()
        {
            return Price;
        }

        public void SetName(string aName)
        {
            Name = aName;
        }

        public void SetPrice(int aPrice)
        {
            Price = aPrice;
        }

        public string GetData()
        {
            string Data = "Наименование товара: " + Name + "\nЦена: " + Price + "рублей";
            return Data;
        }
    }
}
