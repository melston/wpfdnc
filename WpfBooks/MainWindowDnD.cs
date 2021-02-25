using System;
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
        private Point _selectedMouseDown;
        private Chapter _selectedChapter;
        private Book _sourceBook;

        private void authorsTree_ItemSelected(object sender, RoutedEventArgs e)
        {
            _selectedChapter = authorsTree.SelectedItem as Chapter;
            if (_selectedChapter != null)
            {
                SourceChapterName.Text = _selectedChapter.ChapterName;
                _sourceBook = GetNearestBook(e.OriginalSource as TreeViewItem);
                if (_sourceBook != null) SourceBookName.Text = _sourceBook.Title;
            }
        }

        private void authorsTree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _selectedMouseDown = e.GetPosition(authorsTree);
            }
        }

        private void authorsTree_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point currentPosition = e.GetPosition(authorsTree);

                    if (MovedEnough(currentPosition, _selectedMouseDown) && _selectedChapter != null)
                    {
                        DropEffectText.Text = "MouseMove Effects=Move";
                        DragDropEffects finalDropEffect =
                            DragDrop.DoDragDrop(authorsTree, authorsTree.SelectedValue,
                                                DragDropEffects.Move);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void authorsTree_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                Point currentPosition = e.GetPosition(authorsTree);

                if (MovedEnough(currentPosition, _selectedMouseDown))
                {
                    UIElement targetElement = e.OriginalSource as UIElement;
                    // Verify that this is a valid drop and then store the drop target
                    Chapter chapTarget = GetNearestChapter(targetElement);
                    Book bookTarget = GetNearestBook(targetElement);
                    if (chapTarget != null && CheckDropChapterTarget(_selectedChapter, chapTarget))
                    {
                        e.Effects = DragDropEffects.Move;
                        DropEffectText.Text = "DragOver Effects=Move, Target=" + chapTarget.ChapterName;
                    }
                    else if (bookTarget != null)
                    {
                        e.Effects = DragDropEffects.Move;
                        DropEffectText.Text = "DragOver Effects=Move, Target=" + bookTarget.Title;
                    }
                    else 
                    {
                        DropEffectText.Text = "DragOver Effects=None";
                        e.Effects = DragDropEffects.None;
                    }
                }
                e.Handled = true;
            }
            catch (Exception)
            {
            }
        }

        private void authorsTree_Drop(object sender, DragEventArgs e)
        {
            try
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;

                // Verify that this is a valid drop and then store the drop target
                Chapter TargetChapter = GetNearestChapter(e.OriginalSource as UIElement);
                Book TargetBook = GetNearestBook(e.OriginalSource as UIElement);
                if (TargetChapter != null && TargetBook != null && _selectedChapter != null)
                {
                    // Insert the Chapter into the target Book's Chapters list before the
                    // Chapter we are hovering over.
                    int moveIdx = TargetBook.Chapters.IndexOf(TargetChapter);
                    DropEffectText.Text = "Drop Effects=Move, TargetBook=" + TargetBook.Title +
                        ", TargetChapter=" + TargetChapter.ChapterName;
                    FromText.Text = _sourceBook.Title + "/" + _sourceBook.Chapters.IndexOf(_selectedChapter);
                    ToText.Text = TargetBook.Title + "/" + moveIdx;
                    MoveChapter(_selectedChapter, _sourceBook, TargetBook, moveIdx);
                }
                else if (TargetBook != null && _selectedChapter != null)
                {
                    // Append Chapter to the Book's Chapters list
                    DropEffectText.Text = "Drop Effects=Move, TargetBook=" + TargetBook.Title;
                    int moveIdx = TargetBook.Chapters.Count;
                    FromText.Text = _sourceBook.Title + "/" + _sourceBook.Chapters.IndexOf(_selectedChapter);
                    ToText.Text = TargetBook.Title + "/" + moveIdx;
                    MoveChapter(_selectedChapter, _sourceBook, TargetBook, moveIdx);
                }
            }
            catch (Exception)
            {
            }
        }

        private bool MovedEnough(Point currPoint, Point origPoint)
        {
            if ((Math.Abs(currPoint.X - origPoint.X) > 10.0) ||
                   (Math.Abs(currPoint.Y - origPoint.Y) > 10.0))
            {
                return true;
            }
            return false;
        }

        private bool CheckDropChapterTarget(Chapter _sourceItem, Chapter _targetItem)
        {
            //Check whether the target item is meeting your condition
            bool dropOK = false;
            if (!_sourceItem.ChapterName.Equals(_targetItem.ChapterName))
            {
                dropOK = true;
            }
            return dropOK;

        }

        private Chapter GetNearestChapter(UIElement element)
        {
            // Walk up the element tree to the nearest tree view item.
            TreeViewItem container = element as TreeViewItem;
            while ((container == null) && (element != null))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as TreeViewItem;
            }

            return container.Header as Chapter;
        }

        private Book GetNearestBook(UIElement element)
        {
            // Walk up the element tree to the nearest tree view item that contains a book
            TreeViewItem container = element as TreeViewItem;
            Book bk = null;
            while ((bk == null) && (element != null))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as TreeViewItem;
                if (container != null) bk = container.Header as Book;
            }

            return bk;
        }
    }
}