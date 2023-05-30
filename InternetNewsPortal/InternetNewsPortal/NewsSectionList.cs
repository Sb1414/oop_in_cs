using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetNewsPortal
{
    internal class NewsSectionList
    {
        private NewsSectionNode header;

        private class NewsSectionNode
        {
            public NewsSection Value { get; }
            public NewsSectionNode Previous { get; set; }
            public NewsSectionNode Next { get; set; }

            public NewsSectionNode(NewsSection newsSection)
            {
                Value = newsSection;
                Previous = null;
                Next = null;
            }
        }
        public NewsSectionList()
        {
            // Создание заголовочного узла
            header = new NewsSectionNode(null);
            header.Previous = header;
            header.Next = header;
        }

        public void AddNewsSection(NewsSection newsSection)
        {
            NewsSectionNode newNode = new NewsSectionNode(newsSection);

            // Вставка нового узла перед заголовком
            newNode.Previous = header;
            newNode.Next = header.Next;
            header.Next.Previous = newNode;
            header.Next = newNode;
        }

        public void RemoveNewsSection(NewsSection newsSection)
        {
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                if (currentNode.Value == newsSection)
                {
                    // Удаление текущего узла
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return;
                }

                currentNode = currentNode.Next;
            }
        }

        public void RemoveAllNewsInSection(string sectionName)
        {
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                if (currentNode.Value.SectionName == sectionName)
                {
                    currentNode.Value.ClearNews();
                    return;
                }

                currentNode = currentNode.Next;
            }

            throw new ArgumentException($"Раздел {sectionName} не найден.");
        }

        public bool SectionExists(string sectionName)
        {
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                if (currentNode.Value.SectionName == sectionName)
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void AddNewsToSection(string sectionName, string newsTitle, string publicationDate)
        {
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                if (currentNode.Value.SectionName == sectionName)
                {
                    currentNode.Value.AddNews(newsTitle, publicationDate);
                    return;
                }

                currentNode = currentNode.Next;
            }

            // Если раздел с указанным названием не найден, можно выбросить исключение или выполнить другое действие в зависимости от требований вашей программы.
            throw new ArgumentException($"Раздел {sectionName} не найден.");
        }

        public News[] GetNewsBySectionName(string sectionName)
        {
            List<News> newsList = new List<News>();
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                if (currentNode.Value.SectionName == sectionName)
                {
                    newsList.AddRange(currentNode.Value.GetNews());
                }

                currentNode = currentNode.Next;
            }

            return newsList.ToArray();
        }


        public int GetNewsCountBySectionName(string sectionName)
        {
            int count = 0;
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                if (currentNode.Value.SectionName == sectionName)
                {
                    count += currentNode.Value.GetNewsCount();
                }

                currentNode = currentNode.Next;
            }

            return count;
        }

        public void InsertNewsSection(int index, NewsSection newsSection)
        {
            if (index < 0 || index > GetNewsSectionsCount())
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Выход за границы списка");
            }

            if (index == GetNewsSectionsCount())
            {
                AddNewsSection(newsSection);
                return;
            }

            NewsSectionNode currentNode = header.Next;
            int currentIndex = 0;

            while (currentNode != header)
            {
                if (currentIndex == index)
                {
                    NewsSectionNode newNode = new NewsSectionNode(newsSection);
                    newNode.Previous = currentNode.Previous;
                    newNode.Next = currentNode;
                    currentNode.Previous.Next = newNode;
                    currentNode.Previous = newNode;
                    return;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }
        }

        public int GetNewsSectionsCount()
        {
            int count = 0;
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                count++;
                currentNode = currentNode.Next;
            }

            return count;
        }

        public void RemoveSection(string sectionName)
        {
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                if (currentNode.Value.SectionName == sectionName)
                {
                    currentNode.Value.ClearNews();

                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return;
                }

                currentNode = currentNode.Next;
            }

            throw new ArgumentException($"Раздел {sectionName} не найден.");
        }


        public void Clear()
        {
            header.Previous = header;
            header.Next = header;
        }

        public int GetNewsSectionCapacity(string sectionName)
        {
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                if (currentNode.Value.SectionName == sectionName)
                {
                    return currentNode.Value.GetCapacity();
                }

                currentNode = currentNode.Next;
            }

            throw new ArgumentException($"Раздел {sectionName} не найден.");
        }

        public int GetTotalNewsCount()
        {
            int totalCount = 0;
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                totalCount += currentNode.Value.GetNewsCount();
                currentNode = currentNode.Next;
            }

            return totalCount;
        }

        public IEnumerable<NewsSection> GetNewsSections()
        {
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        public IEnumerable<string> GetAllSections()
        {
            NewsSectionNode currentNode = header.Next;

            while (currentNode != header)
            {
                yield return currentNode.Value.SectionName;
                currentNode = currentNode.Next;
            }
        }
    }

}
