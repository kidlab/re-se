using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using FTree.Presenter;
using FTree.Presenter.ViewModel;
using FTree.DTO;
using FTree.Common;

namespace FTree.View.Win32
{
    public partial class FamilyTreeView : UserControl
    {
        private FamilyTreeViewModel _familyTree;

        public FamilyTreeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set datasource to bind to this tree view. 
        /// If the datasource has properties changed the TreeView will not automatically update.
        /// </summary>
        /// <param name="familes">List of FamilyDTO.</param>
        public void SetDataBinding(List<FamilyDTO> familes)
        {
            // Create UI-friendly wrappers around the 
            // raw data objects (i.e. the view-model).
            _familyTree = new FamilyTreeViewModel(familes);

            // Let the UI bind to the view-model.
            base.DataContext = _familyTree;
        }

        /// <summary>
        /// Set datasource to bind to this tree view. 
        /// If the datasource has any properties changed the TreeView will automatically update.
        /// </summary>
        /// <param name="familes">An ObservableCollection of FamilyViewModel.</param>
        public void SetDataBinding(ObservableCollection<FamilyViewModel> familes)
        {
            // Create UI-friendly wrappers around the 
            // raw data objects (i.e. the view-model).
            _familyTree = new FamilyTreeViewModel(familes);

            // Let the UI bind to the view-model.
            base.DataContext = _familyTree;
        }

        public void SetSearchTextBoxWidth(double size)
        {
            this.txtSearch.Width = size;
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _startSearch();
            }
        }

        private void btnFind_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _startSearch();
        }

        private void _startSearch()
        {
            try
            {
                _familyTree.ExecuteSearch();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyTreeView), exc);
            }
        }
    }
}