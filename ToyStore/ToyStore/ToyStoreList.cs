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
        public string Name { get; set; } // название
        public string WorkingHours { get; set; } // режим работы
        public Node Head { get; set; } // начало списка
        public int Count { get; set; } // количество

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

        // Метод для вывода всех игрушек в магазине
        public void DisplayToys()
        {
            Node currentNode = Head;

            if (currentNode == null)
            {
                Console.WriteLine("В магазине нет игрушек.");
                return;
            }

            Console.WriteLine("Игрушки в магазине:");

            do
            {
                Console.WriteLine($"Название: {currentNode.Data.Name}");
                Console.WriteLine($"Артикул: {currentNode.Data.ArticleNumber}");
                Console.WriteLine($"Производитель: {currentNode.Data.Manufacturer}");
                Console.WriteLine($"Стоимость: {currentNode.Data.Price}");
                Console.WriteLine($"Количество: {currentNode.Data.Quantity}");
                Console.WriteLine();

                currentNode = currentNode.Next;
            } while (currentNode != Head);
        }
    }
    internal class Node // Класс, представляющий узел списка
    {
        public Toy Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}

