using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FTree.View.Win32
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FTreeMainForm());
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry for this inconvenience, an unexpected error was occured. Please re-start the program.");
            }
        }
    }
}
