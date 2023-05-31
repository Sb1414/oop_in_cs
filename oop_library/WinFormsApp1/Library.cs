using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Library
    {
        private Book[] books;  // Динамический массив для хранения книг
        private int front;     // Индекс начала очереди
        private int rear;      // Индекс конца очереди
        private int size;      // Текущий размер очереди
        public string Name { get; set; }

        public Library(string name)
        {
            Name = name;
            books = new Book[5];
            front = 0;
            rear = -1;
            size = 0;
        }

        public int Count()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == books.Length;
        }

        public void Clear()
        {
            books = new Book[5];
            front = 0;
            rear = -1;
            size = 0;
        }

        public void Enqueue(Book book)
        {
            try
            {
                if (IsFull())
                {
                    // Увеличение размера массива вдвое при заполнении
                    Array.Resize(ref books, books.Length * 2);
                }

                // Проверка наличия книги с таким же названием
                if (IsBookExists(book.Title))
                {
                    throw new Exception("Книга с таким названием уже существует в библиотеке.");
                }

                rear = (rear + 1) % books.Length;
                books[rear] = book;
                size++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении книги: " + ex.Message);
            }
        }

        public bool IsBookExists(string title)
        {
            for (int i = 0; i < size; i++)
            {
                int index = (front + i) % books.Length;
                Book book = books[index];
                if (book != null && book.Title == title)
                {
                    return true;
                }
            }
            return false;
        }

        public Book Dequeue()
        {
            try
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Очередь пуста. Невозможно извлечь книгу.");
                }

                Book removedBook = books[front];
                books[front] = null;
                front = (front + 1) % books.Length;
                size--;

                // Уменьшение размера массива вдвое при использовании менее четверти его емкости
                if (size < books.Length / 4)
                {
                    Array.Resize(ref books, books.Length / 2);
                }

                return removedBook;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при извлечении книги: " + ex.Message);
                return null;
            }
        }

        public Book GetBook(int index)
        {
            if (index >= 0 && index < size)
            {
                int actualIndex = (front + index) % books.Length;
                return books[actualIndex];
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс книги выходит за пределы диапазона.");
            }
        }
    }
}
