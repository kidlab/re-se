using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.Common
{
    public class Util
    {
        /// <summary>
        /// Gets the string stored in the resource by a specific name.
        /// </summary>
        /// <param name="name">Name of the string in resource.</param>
        /// <returns>Content of the string.</returns>
        public static string GetStringResource(string name)
        {
            return StringRes.ResourceManager.GetString(name);
        }

        /// <summary>
        /// Gets the string stored in the resource by a specific name.
        /// </summary>
        /// <param name="name">Name of the string in resource defined in StringResName enum.</param>
        /// <returns>Content of the string.</returns>
        public static string GetStringResource(StringResName name)
        {
            return StringRes.ResourceManager.GetString(name.ToString());
        }
    }
}
