using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FTree.Presenter;
using FTree.Presenter.ViewModel;

namespace FTree.View.Win32.Components.Wpf
{
    public partial class VisualFamilyTreeView : UserControl
    {
        private FamilyViewModel _family;
        
        /// <summary>
        /// Occurs when the right mouse button is released
        /// while the mouse pointer is over each element on the tree view.
        /// </summary>
        public event MouseButtonEventHandler ItemMouseRightButtonUp;

        /// <summary>
        /// Occurs when the right mouse button is pressed 
        /// while the mouse pointer is over each element on the tree view.
        /// </summary>
        public event MouseButtonEventHandler ItemMouseRightButtonDown;

        /// <summary>
        /// Gets the internal TreeView that actually renders the tree structure.
        /// </summary>
        public TreeView InternalVisualTreeView
        {
            get { return visualTree; }
        }

        public VisualFamilyTreeView()
        {
            InitializeComponent();
        }

        public void SetDataBinding(FamilyViewModel root)
        {
            // Create UI-friendly wrappers around the 
            // raw data objects (i.e. the view-model).
            _family = root;
            _family.IsExpanded = true;
            if (_family.Children.Count > 0)
                _family.Children[0].IsExpanded = true;
            // Let the UI bind to the view-model.
            base.DataContext = _family;
        }

        protected virtual void OnItemMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ItemMouseRightButtonDown != null)
            {
                ItemMouseRightButtonDown(sender, e);
            }
        }

        protected virtual void OnItemMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ItemMouseRightButtonUp != null)
            {
                ItemMouseRightButtonUp(sender, e);
            }
        }
        private void TreeViewItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Very IMPORTANT: if we don't set the e.Handled = true, the event will transmit again and again throughout TreeViewItems!
            e.Handled = true;

            OnItemMouseRightButtonDown(sender, e);
        }

        private void TreeViewItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Very IMPORTANT: if we don't set the e.Handled = true, the event will transmit again and again throughout TreeViewItems!
            e.Handled = true;

            OnItemMouseRightButtonUp(sender, e);
        }
    }
}