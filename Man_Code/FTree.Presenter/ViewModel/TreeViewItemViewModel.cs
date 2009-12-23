using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FTree.Presenter.ViewModel
{
    /// <summary>
    /// Base class for all ViewModel classes displayed by TreeViewItems.  
    /// This acts as an adapter between a raw data object and a TreeViewItem.
    /// </summary>
    public class TreeViewItemViewModel : INotifyPropertyChanged
    {
        #region VARIABLES

        private readonly ObservableCollection<TreeViewItemViewModel> _children;
        private readonly TreeViewItemViewModel _parent;

        private bool _isExpanded;
        private bool _isSelected;
        private bool _isLoadChildren = false;
        protected static bool _isLazyLoad = true;

        #endregion

        #region CONSTRUCTOR

        protected TreeViewItemViewModel(TreeViewItemViewModel parent, bool lazyLoadChildren)
        {
            _parent = parent;

            _children = new ObservableCollection<TreeViewItemViewModel>();

            _isLazyLoad = lazyLoadChildren;
        }

        // This is used to create the DummyChild instance.
        private TreeViewItemViewModel()
        {
        }

        #endregion // Constructors

        #region PROPERTIES

        /// <summary>
        /// Returns the logical child items of this object.
        /// </summary>
        public ObservableCollection<TreeViewItemViewModel> Children
        {
            get { return _children; }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;

                // Lazy load the child items, if necessary.
                if (_isLazyLoad && !_isLoadChildren)
                {
                    this.LoadChildren();
                    _isLoadChildren = true;
                }
            }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        /// Get the parent TreeViewItemViewModel containing this item.
        /// </summary>
        public TreeViewItemViewModel Parent
        {
            get { return _parent; }
        }

        /// <summary>
        /// Gets the value determining to load children of this object lazily or not.
        /// </summary>
        public bool IsLazyLoading
        {
            get { return _isLazyLoad; }
        }

        /// <summary>
        /// Gets or sets the object that contains data about this item.
        /// </summary>
        public object Tag;

        #endregion

        #region CORE METHODS

        /// <summary>
        /// Invoked when the child items need to be loaded on demand.
        /// Subclasses can override this to populate the Children collection.
        /// </summary>
        protected virtual void LoadChildren()
        {            
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}