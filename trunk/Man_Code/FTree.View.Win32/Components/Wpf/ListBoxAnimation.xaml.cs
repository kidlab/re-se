using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FTree.View.Win32.Components.Wpf
{
    public partial class ListBoxAnimation : UserControl
    {
        public ListBoxAnimation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the internal System.Windows.Controls.ListBox in this user control.
        /// </summary>
        public ListBox InternalListBox
        {
            get { return this.listBox; }
        }

        public int AddItem(object item)
        {
            if (item == null)
                return -1;
            return this.listBox.Items.Add(item);
        }
    }
}
