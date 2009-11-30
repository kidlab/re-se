using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FTree.Common;

namespace FTree.View.Win32
{
    class UIUtils
    {
        /// <summary>
        /// Shows an error message.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Error(string msg)
        {
            return MessageBox.Show(msg, FTreeConst.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show an information message.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Info(string msg)
        {
            return MessageBox.Show(msg, FTreeConst.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a caution message.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Warning(string msg)
        {
            return MessageBox.Show(msg, FTreeConst.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows a confirm dialog with two options: Yes, No.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, FTreeConst.PRODUCT_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Shows a confirm dialog with three options: Yes, No and Cancel.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult ConfirmWithCancel(string msg)
        {
            return MessageBox.Show(msg, FTreeConst.PRODUCT_NAME, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }
    }
}
