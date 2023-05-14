using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPub
{
    class PublicationBase
    {
        private readonly List<Publication> _publications = new List<Publication>();

        public void AddPublication(Publication publication)
        {
            _publications.Add(publication);
        }

        public void PrintAllPublications()
        {
            foreach (var publication in _publications)
            {
                publication.PrintInfo();
            }
        }

        public void PrintPublicationsByType<T>() where T : Publication
        {
            foreach (var publication in _publications)
            {
                if (publication is T)
                {
                    publication.PrintInfo();
                }
            }
        }

        public void RemoveArticle(string title)
        {
            var articles = _publications.OfType<Article>().Where(a => a.Title == title).ToList();

            if (articles.Any())
            {
                foreach (var article in articles)
                {
                    _publications.Remove(article);
                }
            }
            else
            {
                Console.WriteLine("Статья с таким заголовком не найдена.");
            }
        }


        public void RemoveNews(string title)
        {
            foreach (var publication in _publications)
            {
                if (publication.GetType() == typeof(News))
                {
                    var news = (News)publication;
                    if (news.Title == title)
                    {
                        _publications.Remove(publication);
                        break;
                    }
                }
            }
        }

    }

}
