using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FTree.Common;

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
            catch (Exception exc)
            {
                // This is the last handled exception!!!
                // Should not omit any Exception thrown to here!
                Tracer.Log(typeof(Program), exc);
                MessageBox.Show("Sorry for this inconvenience, an unexpected error was occured. Please re-start the program.");
            }
        }
    }
}
