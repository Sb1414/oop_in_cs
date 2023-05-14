using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPub
{
    internal class PublicationList
    {
        private Publication[] _publications;
        private int _count;

        public PublicationList(int capacity)
        {
            _publications = new Publication[capacity];
            _count = 0;
        }

        public void AddPublication(Publication publication)
        {
            if (_count < _publications.Length)
            {
                _publications[_count] = publication;
                _count++;
            }
            else
            {
                Console.WriteLine("Массив полон.");
            }
        }

        public void PrintAllPublications()
        {
            for (int i = 0; i < _count; i++)
            {
                _publications[i].PrintInfo();
            }
        }

        public void PrintPublicationsByType<T>() where T : Publication
        {
            for (int i = 0; i < _count; i++)
            {
                if (_publications[i] is T)
                {
                    _publications[i].PrintInfo();
                }
            }
        }

        public void RemoveArticle(string title)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_publications[i] is Article article && article.Title == title)
                {
                    RemovePublication(i);
                    return;
                }
            }

            Console.WriteLine("Статья с таким заголовком не найдена.");
        }

        public void RemoveNews(string title)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_publications[i] is News news && news.Title == title)
                {
                    RemovePublication(i);
                    return;
                }
            }

            Console.WriteLine("Новость с таким заголовком не найдена.");
        }

        private void RemovePublication(int index)
        {
            if (index < 0 || index >= _count)
            {
                Console.WriteLine("Некорректный индекс.");
                return;
            }

            for (int i = index; i < _count - 1; i++)
            {
                _publications[i] = _publications[i + 1];
            }

            _publications[_count - 1] = null;
            _count--;
        }

        public void ResizePublicationsArray(int newSize)
        {
            Array.Resize(ref _publications, _publications.Length + newSize);
        }

    }
}
