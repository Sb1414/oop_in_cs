using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPub
{
    abstract class Publication
    {
        public string Title { get; }

        protected Publication(string title)
        {
            Title = title;
        }

        public abstract void PrintInfo();
    }

    class News : Publication
    {
        public string Source { get; }

        public News(string title, string source) : base(title)
        {
            Source = source;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Новость: {Title}, источник: {Source}");
        }
    }

    class Article : Publication
    {
        public string Author { get; }

        public Article(string title, string author) : base(title)
        {
            Author = author;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Статья: {Title}, автор: {Author}");
        }
    }

    
}
