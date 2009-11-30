using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FTree.View.Win32
{
    public class BaseDialogForm : Form
    {
        /// <summary>
        /// Show this dialog and specify that it will shows in task bar or not.
        /// </summary>
        /// <param name="showInTaskBar">Specify that the dialog will palce an icon in the task bar or not.</param>
        /// <returns>DialogResult.</returns>
        public DialogResult ShowDialog(bool showInTaskBar)
        {
            this.ShowInTaskbar = ShowInTaskbar = showInTaskBar;
            return this.ShowDialog();
        }
    }
}
