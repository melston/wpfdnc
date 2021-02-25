using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBooks
{
    public class Book
    {
        public Book(String title)
        {
            Title = title;
            Chapters = new ObservableCollection<Chapter>();
        }

        public String Title
        { get; set; }

        public ObservableCollection<Chapter> Chapters
        { get; set; }
    }
}
