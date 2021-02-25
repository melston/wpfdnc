using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Author> Authors
        { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Authors = Utils.makeAuthors();
            authorsTree.ItemsSource = Authors;
        }

        private void MoveChapter(Chapter ch, Book from, Book to, int index)
        {
            if (from != to)
            {
                from.Chapters.Remove(ch);
                to.Chapters.Insert(index, ch);
            }
            else
            {
                int oldIndex = from.Chapters.IndexOf(ch);
                from.Chapters.Move(oldIndex, index);
            }
        }
    }
}
