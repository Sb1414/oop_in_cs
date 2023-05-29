using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetNewsPortal
{
    internal class NewsSection
    {
        private string sectionName;
        private News[] newsQueue;
        private int front;
        private int rear;
        private int count;

        public NewsSection(string sectionName, int capacity)
        {
            this.sectionName = sectionName;
            newsQueue = new News[capacity];
            front = 0;
            rear = -1;
            count = 0;
        }

        public string SectionName
        {
            get { return sectionName; }
        }

        public int GetNewsCount()
        {
            return count;
        }

        public int GetCapacity()
        {
            return newsQueue.Length;
        }

        public void AddNews(string newsTitle, string publicationDate)
        {
            if (count == newsQueue.Length)
            {
                // сдвиг элементов на шаг вперед
                for (int i = 0; i < count - 1; i++)
                {
                    int currentIndex = (front + i) % newsQueue.Length;
                    int nextIndex = (front + i + 1) % newsQueue.Length;
                    newsQueue[currentIndex] = newsQueue[nextIndex];
                }

                // обновление индекса
                rear = (rear - 1 + newsQueue.Length) % newsQueue.Length;
            }

            rear = (rear + 1) % newsQueue.Length;
            newsQueue[rear] = new News(newsTitle, publicationDate);

            if (count < newsQueue.Length)
            {
                count++;
            }
        }

        public void Remove()
        {
            if (count > 0)
            {
                // Shift elements to remove the first news item
                for (int i = 0; i < count - 1; i++)
                {
                    int current = (front + i) % newsQueue.Length;
                    int next = (front + i + 1) % newsQueue.Length;
                    newsQueue[current] = newsQueue[next];
                }

                rear = (rear - 1 + newsQueue.Length) % newsQueue.Length;
                count--;
            }
        }

        public void ClearNews()
        {
            front = 0;
            rear = -1;
            count = 0;

            newsQueue = new News[newsQueue.Length];
        }

        public News GetNextNews()
        {
            if (count == 0)
            {
                return null; // Очередь новостей пуста
            }

            News newsItem = newsQueue[front];
            front = (front + 1) % newsQueue.Length;
            count--;
            return newsItem;
        }

        public News[] GetNews()
        {
            News[] newsArray = new News[count];
            int index = 0;
            int current = front;

            while (index < count)
            {
                newsArray[index] = newsQueue[current];
                current = (current + 1) % newsQueue.Length;
                index++;
            }

            return newsArray;
        }
    }

}
