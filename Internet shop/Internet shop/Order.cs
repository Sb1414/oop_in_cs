using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Order
    {
        public QueueNode First;
        public QueueNode Last;
        public string Name;
        public string Date;
        public int SumOfOrder;
        public int ProductCount;

        public Order(string aName, string aDate)
        {
            Name = aName;
            Date = aDate;
            First = null;
            Last = null;
            SumOfOrder = 0;
            ProductCount = 0;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDate()
        {
            return Date;
        }

        public int GetSumOfOrder()
        {
            return SumOfOrder;
        }

        public int GetProductCount()
        {
            return ProductCount;
        }

        public string GetData()
        {
            string data = Name;
            int number = 1;
            QueueNode current = First;
            while (current != null)
            {
                data += $"\n{number})\n{current.Product.GetData()}";
                number++;
                current = current.Next;
            }
            return data;
        }

        public void SetName(string aName)
        {
            Name = aName;
        }

        public void SetDate(string aDate)
        {
            Date = aDate;
        }

        public void AddInOrder(string name, int price)
        {
            Product newProduct = new Product(name, price);
            QueueNode newNode = new QueueNode(newProduct);

            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }

            SumOfOrder += price;
            ProductCount++;
        }

        public Product[] GetProductsByName(string customerName)
        {
            List<Product> productsList = new List<Product>();

            if (GetName() == customerName)
            {
                QueueNode current = First;
                while (current != null)
                {
                    productsList.Add(current.Product);
                    current = current.Next;
                }
            }

            return productsList.ToArray();
        }

        public void RemoveAllProducts()
        {
            First = null;
            Last = null;
            SumOfOrder = 0;
            ProductCount = 0;
        }


        public void RemoveProduct(Product product)
        {
            QueueNode current = First;
            QueueNode previous = null;

            while (current != null)
            {
                if (current.Product == product)
                {
                    if (previous == null)
                    {
                        // Удаляемый элемент является первым в очереди
                        First = current.Next;
                        if (First == null)
                        {
                            // Удаляемый элемент также является последним в очереди
                            Last = null;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current == Last)
                        {
                            // Удаляемый элемент является последним в очереди
                            Last = previous;
                        }
                    }

                    // Обновляем сумму заказа и количество товаров
                    SumOfOrder -= current.Product.GetPrice();
                    ProductCount--;

                    // Прекращаем поиск после удаления первого вхождения товара
                    break;
                }

                previous = current;
                current = current.Next;
            }
        }

        public void RemoveProductByName(string productName)
        {
            QueueNode current = First;
            QueueNode previous = null;

            while (current != null)
            {
                if (current.Product.GetName() == productName)
                {
                    if (previous == null)
                    {
                        // Удаляемый элемент является первым в очереди
                        First = current.Next;
                        if (First == null)
                        {
                            // Удаляемый элемент также является последним в очереди
                            Last = null;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current == Last)
                        {
                            // Удаляемый элемент является последним в очереди
                            Last = previous;
                        }
                    }

                    // Обновляем сумму заказа и количество товаров
                    SumOfOrder -= current.Product.GetPrice();
                    ProductCount--;

                    // Прекращаем поиск после удаления первого вхождения товара
                    break;
                }

                previous = current;
                current = current.Next;
            }
        }

        public Product[] GetAllProducts()
        {
            List<Product> productsList = new List<Product>();

            QueueNode current = First;
            while (current != null)
            {
                productsList.Add(current.Product);
                current = current.Next;
            }

            return productsList.ToArray();
        }


        private QueueNode GetSecondToLastNode()
        {
            QueueNode current = First;
            while (current.Next != Last)
            {
                current = current.Next;
            }
            return current;
        }

        public class QueueNode
        {
            public Product Product;
            public QueueNode Next;

            public QueueNode(Product product)
            {
                Product = product;
                Next = null;
            }
        }
    }


}
