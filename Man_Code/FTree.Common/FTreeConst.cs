using System;
using System.Collections.Generic;
using System.Text;

namespace FTree.Common
{
    /// <summary>
    /// Defines all constants and default settings for the program.
    /// </summary>
    public class FTreeConst
    {
        /// <summary>
        /// Name of the sponsor, investor, company or group that supports or develops the project.
        /// </summary>
        public const string COMPANY_NAME = "University of Information Technology";

        /// <summary>
        /// Name of this software.
        /// </summary>
        public const string PRODUCT_NAME = "FTree";

        /// <summary>
        /// Name of the log file created by the GUI module of the program (MainForm).
        /// </summary>
        public const string LOG_FILE = "FTree.log";

        /// <summary>
        /// ID field.
        /// </summary>
        public const string ID_FIELD = "ID";

        /// <summary>
        /// Name field.
        /// </summary>
        public const string NAME_FIELD = "Name";

        /// <summary>
        /// Men.
        /// </summary>
        public const int MALE = 0;

        /// <summary>
        /// Women.
        /// </summary>
        public const int FEMALE = 1;

        /// <summary>
        /// The number to identify the root person or the first generation of a family.
        /// </summary>
        public const int FIRST_GENERATION = 1;
    }
}
