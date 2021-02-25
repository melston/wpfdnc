using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBooks
{
    public class Chapter
    {

        public Chapter(string name)
        {
            ChapterName = name;
            Date = new DateTime();
        }

        public Chapter(string name, DateTime date)
        {
            ChapterName = name;
            Date = date;
        }

        public String ChapterName { get; set; }
        public DateTime Date { get; set; }
    }
}
