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
        private Point _lastMouseDown;
        private Chapter _draggedItem, _target;

        private void authorsTree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _lastMouseDown = e.GetPosition(authorsTree);
            }
        }

        private void authorsTree_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point currentPosition = e.GetPosition(authorsTree);

                    if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 10.0) ||
                        (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 10.0))
                    {
                        _draggedItem = authorsTree.SelectedItem as Chapter;
                        if (_draggedItem != null)
                        {
                            //Console.WriteLine("  _draggedItem != null");
                            DragDropEffects finalDropEffect =
                                DragDrop.DoDragDrop(authorsTree, authorsTree.SelectedValue,
                                                    DragDropEffects.Move);

                            //Checking target is not null and item is dragging(moving)
                            if ((finalDropEffect == DragDropEffects.Move) && (_target != null))
                            {
                                // A Move drop was accepted
                                //if (!_draggedItem.Header.ToString().Equals(_target.Header.ToString()))
                                //{
                                //    CopyItem(_draggedItem, _target);
                                //    _target = null;
                                //    _draggedItem = null;
                                //}
                            }
                        }
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

                if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 10.0) ||
                   (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 10.0))
                {
                    // Verify that this is a valid drop and then store the drop target
                    Chapter item = GetNearestChapter(e.OriginalSource as UIElement);
                    if (item != null && CheckDropTarget(_draggedItem, item))
                    {
                        e.Effects = DragDropEffects.Move;
                    }
                    else
                    {
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
                Chapter TargetItem = GetNearestChapter(e.OriginalSource as UIElement);
                if (TargetItem != null && _draggedItem != null)
                {
                    _target = TargetItem;
                    e.Effects = DragDropEffects.Move;
                }
            }
            catch (Exception)
            {
            }
        }

        private bool CheckDropTarget(Chapter _sourceItem, Chapter _targetItem)
        {
            //Check whether the target item is meeting your condition
            bool _isEqual = false;
            if (!_sourceItem.ChapterName.Equals(_targetItem.ChapterName))
            {
                _isEqual = true;
            }
            return _isEqual;

        }

        private T GetNearest<T>(UIElement element)
        {
            // Walk up the element tree to the nearest tree view item.
            TreeViewItem container = element as TreeViewItem;
            T chap = default(T);
            while ((container == null) && (element != null))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as TreeViewItem;
            }

            try
            {
                chap = (T)container.Header;
            }
            catch (Exception) { }
            return chap;
        }

        private Chapter GetNearestChapter(UIElement element)
        {
            // Walk up the element tree to the nearest tree view item.
            TreeViewItem container = element as TreeViewItem;
            Chapter chap = null;
            while ((container == null) && (element != null))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as TreeViewItem;
            }

            try
            {
                chap = container.Header as Chapter;
            }
            catch (Exception) { }
            return chap;
        }

        //private void CopyItem(TreeViewItem _sourceItem, TreeViewItem _targetItem)
        //{
        //    //Asking user wether he want to drop the dragged TreeViewItem here or not
        //    if (MessageBox.Show("Would you like to drop " + _sourceItem.Header.ToString() + " into " + _targetItem.Header.ToString() + "", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //    {
        //        try
        //        {
        //            //adding dragged TreeViewItem in target TreeViewItem
        //            AddChild(_sourceItem, _targetItem);

        //            //finding Parent TreeViewItem of dragged TreeViewItem 
        //            TreeViewItem ParentItem = FindVisualParent<TreeViewItem>(_sourceItem);
        //            // if parent is null then remove from TreeView else remove from Parent TreeViewItem
        //            if (ParentItem == null)
        //            {
        //                authorsTree.Items.Remove(_sourceItem);
        //            }
        //            else
        //            {
        //                ParentItem.Items.Remove(_sourceItem);
        //            }
        //        }
        //        catch
        //        {

        //        }
        //    }

        //}

        //public void AddChild(TreeViewItem _sourceItem, TreeViewItem _targetItem)
        //{
        //    // add item in target TreeViewItem 
        //    TreeViewItem item1 = new TreeViewItem();
        //    item1.Header = _sourceItem.Header;
        //    _targetItem.Items.Add(item1);
        //    foreach (TreeViewItem item in _sourceItem.Items)
        //    {
        //        AddChild(item, item1);
        //    }
        //}

        //static TObject FindVisualParent<TObject>(UIElement child) where TObject : UIElement
        //{
        //    if (child == null)
        //    {
        //        return null;
        //    }

        //    UIElement parent = VisualTreeHelper.GetParent(child) as UIElement;

        //    while (parent != null)
        //    {
        //        TObject found = parent as TObject;
        //        if (found != null)
        //        {
        //            return found;
        //        }
        //        else
        //        {
        //            parent = VisualTreeHelper.GetParent(parent) as UIElement;
        //        }
        //    }

        //    return null;
        //}
    }
}