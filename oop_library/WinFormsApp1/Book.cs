using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Book
    { // Класс для представления книги
        public string Title { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }

        public Book(string bookName, string authorName, string publishing, int year)
        {
            this.Title = bookName;
            this.Author = authorName;
            this.Publisher = publishing;
            this.Year = year;
        }
    }
}
