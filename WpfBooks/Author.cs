using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBooks
{
    public class Author
    {
        public Author(String name)
        {
           
            Name = name;
            Books = new ObservableCollection<Book>();
        }

        public String Name
        { get; set; }

        public ObservableCollection<Book> Books
        { get; set; }
    }
}
