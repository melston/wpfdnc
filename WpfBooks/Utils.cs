using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBooks
{
    static class Utils
    {
        public static ObservableCollection<Author> makeAuthors()
        {
            Book frontier = new Book("Frontier");
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 1", new DateTime(2020, 9, 10, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 2", new DateTime(2020, 9, 11, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 3", new DateTime(2020, 9, 12, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 4", new DateTime(2020, 9, 13, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 5", new DateTime(2020, 9, 14, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 6", new DateTime(2020, 9, 15, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 7", new DateTime(2020, 9, 16, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 8", new DateTime(2020, 9, 17, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 9", new DateTime(2020, 9, 19, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 10", new DateTime(2020, 9, 19, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 11", new DateTime(2020, 9, 20, 0, 0, 0)));
            frontier.Chapters.Add(new Chapter("Frontier - Chapter 12", new DateTime(2020, 9, 21, 0, 0, 0)));

            Book riesOfSolRep = new Book("Rise of the Sol Republic");
            riesOfSolRep.Chapters.Add(new Chapter("Rise of the Sol Republic", new DateTime(2021, 1, 17, 0, 0, 0)));

            Author rook = new Author("Rook-385");
            rook.Books.Add(frontier);
            rook.Books.Add(riesOfSolRep);

            Book riseOfReylo = new Book("The Rise of Reylo");
            riseOfReylo.Chapters.Add(new Chapter("The Rise of Reylo - Chapter 1", new DateTime(2020, 12, 20, 0, 0, 0)));
            riseOfReylo.Chapters.Add(new Chapter("The Rise of Reylo - Chapter 2", new DateTime(2020, 12, 21, 0, 0, 0)));
            riseOfReylo.Chapters.Add(new Chapter("The Rise of Reylo - Chapter 3", new DateTime(2020, 12, 22, 0, 0, 0)));
            riseOfReylo.Chapters.Add(new Chapter("The Rise of Reylo - Chapter 4", new DateTime(2020, 12, 23, 0, 0, 0)));

            Book pushPull = new Book("The Push and the Pull");
            pushPull.Chapters.Add(new Chapter("The Push and the Pull", new DateTime(2020, 4, 26, 0, 0, 0)));

            Author sassy = new Author("Sassy Artichoke");
            sassy.Books.Add(riseOfReylo);
            sassy.Books.Add(pushPull);

            ObservableCollection<Author> authors = new ObservableCollection<Author>();

            authors.Add(rook);
            authors.Add(sassy);

            return authors;
        }
    }
}
