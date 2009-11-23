using System;
using System.Collections.Generic;
using System.Text;

namespace MVPCore
{
    public interface IView
    {
        /// <summary>
        /// Used to connect a view to its controller.
        /// </summary>
        /// <remarks>
        /// This is one of the most important and widely used properties
        /// in the framework. Through it views pass control to controllers
        /// (see the example below).
        /// </remarks>
        /// <example>
        /// In this example the view handles a user gesture (button click)
        /// by passing control to the associated controller:
        /// <code>
        /// class MyView : IView
        /// {
        ///     // here the IView implementation goes
        ///     ...
        /// 
        ///     private void button_Click(object sender, EventArgs e)
        ///     {
        ///         (Controller as MyController).DoSomething();
        ///     }
        /// }
        /// </code>
        /// </example>
        //IController Controller
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Used to assign a view its name.
        /// </summary>
        string ViewName
        {
            get;
            set;
        }
    }
}
