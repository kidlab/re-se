using System.Windows.Controls;
using FTree.Presenter;
using FTree.Presenter.ViewModel;

namespace FTree.View.Win32.Components.Wpf
{
    public partial class VisualFamilyTreeView : UserControl
    {
        private FamilyViewModel _family;

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
    }
}