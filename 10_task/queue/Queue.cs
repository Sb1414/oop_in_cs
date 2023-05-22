using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue
{
    class MyQueue<T>
    {
        private T[] data;
        private int head; // индекс первого элемента
        private int tail; // индекс последнего элемента
        private int size; // размер очереди
        private int count; // текущее количество элементов

        public MyQueue(int size)
        {
            data = new T[size];
            head = 0;
            tail = -1;
            this.size = size;
            count = 0;
        }

        public void Enqueue(T item)
        {
            if (count == size)
            {
                // throw new Exception("Queue is full");
                Console.WriteLine("Очередь переполнена");
                return;
            }

            tail = (tail + 1) % size;
            data[tail] = item;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                // throw new Exception("Queue is full");
                Console.WriteLine("Очередь пуста");
                return default(T);
            }

            T item = data[head];
            head = (head + 1) % size;
            count--;
            Console.Write("Удален элемент: ");
            return item;
        }

        public void Print()
        {
            if (count == 0)
            {
                // throw new Exception("Queue is full");
                Console.WriteLine("Очередь пуста");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write(data[(head + i) % size] + " ");
            }
            Console.WriteLine();
        }
    }
}
