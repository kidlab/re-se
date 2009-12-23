using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FTree.View.Win32
{
    public partial class ListResultForm : BaseDialogForm
    {
        /// <summary>
        /// Occurs whenever the selected item in the list box was changed.
        /// </summary>
        public event System.Windows.Controls.SelectionChangedEventHandler ListBoxSelectionChanged;

        private object _selectedItem;

        /// <summary>
        /// Gets the current selected item on the ListBox.
        /// </summary>
        public object SelectedItem
        {
            get { return _selectedItem; }
        }
        
        public ListResultForm()
        {
            InitializeComponent();
            this.listBoxAnimation.InternalListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(InternalListBox_SelectionChanged);
        }

        protected virtual void OnListBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxSelectionChanged != null)
                ListBoxSelectionChanged(sender, e);
        }

        private void InternalListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedItem = listBoxAnimation.InternalListBox.SelectedItem;
            OnListBoxSelectionChanged(sender, e);
        }

        public void AddItem(object item)
        {
            this.listBoxAnimation.AddItem(item);
        }

        public void ClearListBox()
        {
            this.listBoxAnimation.InternalListBox.Items.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
