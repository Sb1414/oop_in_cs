using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ConstructionFirm
    {
        private string name;
        private string director;
        private int capacity;
        private Building[] buildings;
        private int front;
        private int rear;

        public string GetNameFirm()
        {
            return name;
        }

        public string GetDirectorFirm()
        {
            return director;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public ConstructionFirm(string name, string director, int capacity)
        {
            this.name = name;
            this.director = director;
            this.capacity = capacity;
            buildings = new Building[capacity];
            front = rear = -1;
        }

        public int GetBuildingCount()
        {
            if (front == -1)
            {
                return 0;
            }
            else if (front <= rear)
            {
                return rear - front + 1;
            }
            else
            {
                return buildings.Length - front + rear + 1;
            }
        }

        public void Clear() // Сброс всех данных о строящихся объектах
        {
            buildings = new Building[capacity];
            front = rear = -1;
        }

        public bool IsEmpty()
        {
            return front == -1;
        }

        public void AddBuilding(string address, decimal constructionCost, int constructionPeriod) // Добавление объекта в очередь
        { 
            if (IsBuildingExists(address)) // Проверка, существует ли уже объект с указанным адресом
            {
                throw new Exception("Объект с указанным адресом уже существует.");
            }

            Building building = new Building(address, constructionCost, constructionPeriod);

            if (front == -1)
            {
                front = rear = 0;
                buildings[rear] = building;
            }
            else
            {
                // Проверка, переполнен ли массив
                if (GetBuildingCount() == capacity)
                {
                    // Удаление первого элемента и сдвиг остальных элементов
                    front = (front + 1) % buildings.Length;
                }

                rear = (rear + 1) % buildings.Length;
                buildings[rear] = building;
            }
        }

        public void Remove() // Удаление из очереди
        {
            if (front == -1)
            {
                throw new InvalidOperationException("Невозможно удалить объект из пустой очереди.");
            }

            if (front == rear)
            {
                front = rear = -1;
            }
            else
            { // сдвиг на шаг вперед
                front = (front + 1) % buildings.Length;
            }
        }


        public Building GetBuilding(int index)
        {
            if (index >= 0 && index < GetBuildingCount())
            {
                int actualIndex = (front + index) % buildings.Length;
                return buildings[actualIndex];
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс объекта выходит за пределы");
            }
        }

        public bool IsBuildingExists(string address)
        {
            int current = front;

            if (current != -1)
            {
                do
                {
                    if (buildings[current].Address == address)
                    {
                        return true; // Объект с указанным адресом уже существует
                    }

                    current = (current + 1) % buildings.Length;
                } while (current != (rear + 1) % buildings.Length);
            }

            return false; // Объект с указанным адресом не существует
        }


        public decimal CalculateTotalConstructionCost()
        {
            decimal totalCost = 0;
            int current = front;

            if (current != -1)
            {
                do
                {
                    totalCost += buildings[current].ConstructionCost;
                    current = (current + 1) % buildings.Length;
                } while (current != (rear + 1) % buildings.Length);
            }

            return totalCost;
        }
    }
}
