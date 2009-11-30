using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FTree.View.Win32.Components
{
    /// <summary>
    /// This is the base text box auto-changing background color whenever it is enterred or leaved.
    /// </summary>
    public class BaseTextBox : TextBox
    {
        public BaseTextBox()
        {
            this.Enter += new EventHandler(BaseTextBox_Enter);
            this.Leave += new EventHandler(BaseTextBox_Leave);
        }

        protected void BaseTextBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightYellow;
        }

        protected void BaseTextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
