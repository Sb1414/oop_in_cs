using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToyStore
{
    internal class ToyStoreList // Класс, представляющий магазин игрушек
    {
        internal class Node // Класс, представляющий узел списка
        {
            public Toy Data { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private string Name; // название
        private string WorkingHours; // режим работы
        public Node Head { get; set; } // начало списка
        private int Count; // количество

        public ToyStoreList(string name, string workingHours)
        {
            Name = name;
            WorkingHours = workingHours;
            Head = null;
            Count = 0;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetWorkingHours()
        {
            return WorkingHours;
        }

        public int GetCount()
        {
            return Count;
        }

        // Метод для добавления игрушки в магазин
        public void AddToy(Toy toy)
        {
            Node newNode = new Node { Data = toy };

            if (Head == null)
            {
                // Если список пустой, устанавливаем новый узел в качестве головы списка
                newNode.Next = newNode;
                newNode.Previous = newNode;
                Head = newNode;
            }
            else
            {
                // Вставляем новый узел в конец списка
                Node lastNode = Head.Previous;
                lastNode.Next = newNode;
                newNode.Previous = lastNode;
                newNode.Next = Head;
                Head.Previous = newNode;
            }

            Count++;
        }

        // Метод для удаления игрушки из магазина по артикулу
        public void RemoveToy(int articleNumber)
        {
            Node currentNode = Head;

            do
            {
                if (currentNode.Data.ArticleNumber == articleNumber)
                {
                    if (Count == 1)
                    {
                        // Если в списке только один элемент, очищаем список
                        Head = null;
                    }
                    else
                    {
                        // Удаляем текущий узел из списка
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;

                        if (currentNode == Head)
                        {
                            // Если удаляемый узел - голова списка, обновляем ссылку на голову
                            Head = currentNode.Next;
                        }
                    }

                    Count--;
                    return;
                }

                currentNode = currentNode.Next;
            } while (currentNode != Head);
        }

        // Метод для подсчета общей суммы всех игрушек в списке
        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            Node currentNode = Head;

            if (currentNode == null)
            {
                return totalPrice;
            }

            do
            {
                totalPrice += currentNode.Data.Price * currentNode.Data.Quantity;
                currentNode = currentNode.Next;
            } while (currentNode != Head);

            return totalPrice;
        }

        // Метод для подсчета общего количества всех игрушек
        public int CalculateTotalQuantity()
        {
            int totalQuantity = 0;
            Node currentNode = Head;

            if (currentNode == null)
            {
                return totalQuantity;
            }

            do
            {
                totalQuantity += currentNode.Data.Quantity;
                currentNode = currentNode.Next;
            } while (currentNode != Head);

            return totalQuantity;
        }
    }

}

