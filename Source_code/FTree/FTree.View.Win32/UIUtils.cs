﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using FTree.Common;

namespace FTree.View.Win32
{
    public class UIUtils
    {
        /// <summary>
        /// To count entries already existing..
        /// </summary>
        /// <param name="data">Data to count.</param>
        /// <returns>Number of existing entities with the specific name</returns>
        public delegate int CountExistentEntryDelegate(string data);

        /// <summary>
        /// The light pink color.
        /// </summary>
        public static readonly Color SAD_PINK_COLOR = 
            System.Drawing.Color.FromArgb(
                ((int)(((byte)(255)))), 
                ((int)(((byte)(221)))), 
                ((int)(((byte)(221)))));

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
        public static DialogResult ConfirmYesNoCancel(string msg)
        {
            return MessageBox.Show(msg, FTreeConst.PRODUCT_NAME, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows a confirm dialog with three options: OK and Cancel.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult ConfirmOKCancel(string msg)
        {
            return MessageBox.Show(msg, FTreeConst.PRODUCT_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}
