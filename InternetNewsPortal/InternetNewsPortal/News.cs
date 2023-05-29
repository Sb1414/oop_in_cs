using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetNewsPortal
{
    internal class News
    {
        private string title;
        private string date;

        public News(string title, string publicationDate)
        {
            this.title = title;
            this.date = publicationDate;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetDate(string date)
        {
            this.date = date;
        }

        public string GetDate()
        {
            return date;
        }
    }
}
