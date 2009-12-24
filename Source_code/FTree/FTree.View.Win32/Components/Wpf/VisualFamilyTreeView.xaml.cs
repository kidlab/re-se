using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FTree.Presenter;
using FTree.Presenter.ViewModel;
using FTree.DTO;
using FTree.Common;

namespace FTree.View.Win32.Components.Wpf
{
    public partial class VisualFamilyTreeView : UserControl
    {
        private FamilyViewModel _family;
        
        /// <summary>
        /// Occurs when the left mouse button is pressed 
        /// while the mouse pointer is over each element on the tree view.
        /// </summary>
        public event MouseButtonEventHandler ItemMouseLeftButtonDown;

        /// <summary>
        /// Occurs when the left mouse button is released
        /// while the mouse pointer is over each element on the tree view.
        /// </summary>
        public event MouseButtonEventHandler ItemMouseLeftButtonUp;

        /// <summary>
        /// Occurs when the right mouse button is pressed 
        /// while the mouse pointer is over each element on the tree view.
        /// </summary>
        public event MouseButtonEventHandler ItemMouseRightButtonDown;

        /// <summary>
        /// Occurs when the right mouse button is released
        /// while the mouse pointer is over each element on the tree view.
        /// </summary>
        public event MouseButtonEventHandler ItemMouseRightButtonUp;

        /// <summary>
        /// Gets the internal TreeView that actually renders the tree structure.
        /// </summary>
        public TreeView InternalVisualTreeView
        {
            get { return visualTree; }
        }

        public FamilyViewModel Family
        {
            get { return _family; }
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

        public void SelectPerson(PersonViewModel person)
        {
            try
            {
                if (this.visualTree.Items.Count <= 0 || person == null)
                    return;

                Stack<PersonViewModel> stack = new Stack<PersonViewModel>();
                PersonViewModel item = this.visualTree.Items[0] as PersonViewModel;

                while (true)
                {
                    if (item == null)
                        return;


                    if (item.FullName == person.FullName)
                    {
                        item.IsSelected = true;
                        return;
                    }

                    foreach (PersonViewModel subItem in item.Children)
                    {
                        stack.Push(subItem);
                    }

                    if (stack.Count > 0)
                        item = stack.Pop();
                    else
                        break;
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(VisualFamilyTreeView), exc);
            }
        }

        #region MOUSE LEFT EVENTS

        protected virtual void OnItemMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ItemMouseLeftButtonDown != null)
            {
                ItemMouseLeftButtonDown(sender, e);
            }
        }

        protected virtual void OnItemMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ItemMouseLeftButtonUp != null)
            {
                ItemMouseLeftButtonUp(sender, e);
            }
        }
        private void TreeViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Very IMPORTANT: if we don't set the e.Handled = true, the event will transmit again and again throughout TreeViewItems!
            e.Handled = true;

            OnItemMouseLeftButtonDown(sender, e);
        }

        private void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Very IMPORTANT: if we don't set the e.Handled = true, the event will transmit again and again throughout TreeViewItems!
            e.Handled = true;

            OnItemMouseLeftButtonUp(sender, e);
        }

        #endregion

        #region MOUSE RIGHT EVENTS

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

        #endregion
    }
}