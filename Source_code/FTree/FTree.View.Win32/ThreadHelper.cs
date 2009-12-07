using System;
using System.Threading;
using System.Text;
using FTree.Common;

namespace FTree.View.Win32
{
    /// <summary>
    /// A helper to run a method in a different thread with the current thread and show a progress form until the method is done.
    /// </summary>
    internal class ThreadHelper
    {
        /*
         * Some suggested ideas:
         * - The progress form will show as a dialog, this means the user cannot interact with the other components of the GUI. That's why there should be a Boolean parameter (ex: isDialogProgressForm) indicating the progress form will show as a dialog or a form (use ShowDialog() or Show()).
         * - Already considered the ThreadPool class? Let learn how to use it.
         */
        #region DELEGATES

        /// <summary>
        /// This is a simple delegate used for a void and non-parameter method.
        /// </summary>
        public delegate void VoidDelegate();

        /// <summary>
        /// The delegate of a method which has no parameter and return an object.
        /// </summary>
        /// <returns>An instance of an object.</returns>
        public delegate Object ObjectReturnDelegate();

        /// <summary>
        /// The delegate of a method that has an object as its argument.
        /// </summary>
        /// <param name="objParam">An instance of an object.</param>
        public delegate void ObjectParamDelegate(Object objParam);

        /// <summary>
        /// The delegate of a method that has an object as its argument and return another object. 
        /// </summary>
        /// <param name="objParam">An instance of an object.</param>
        /// <returns>An instance of an object.</returns>
        public delegate Object O2Delegate(Object objParam);

        /// <summary>
        /// The delegate of a method that can have multiple arguments.
        /// </summary>
        /// <param name="args">An array of objects to pass as arguments to the specified method. This parameter can be null if the method takes no arguments.</param>
        public delegate void ObjectParamsDelegate(params Object[] args);

        /// <summary>
        /// The delegate of a method that can have multiple arguments and return an object.
        /// </summary>
        /// <param name="args">An array of objects to pass as arguments to the specified method. This parameter can be null if the method takes no arguments.</param>
        /// <returns>An instance of an object.</returns>
        public delegate Object O2ParamsDelegate(params Object[] args);

        #endregion

        #region DO WORK METHODS

        /// <summary>
        /// Run the method represented by the VoidMethodDelegate.
        /// </summary>
        /// <param name="methodDelegate">A delegate of a void and non-parameter method.</param>
        public static void DoWork(VoidDelegate methodDelegate)
        {
            try
            {                
                ProgressForm waitForm = new ProgressForm();
                DoWork(methodDelegate, waitForm);                
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ThreadHelper).ToString(), exc);
                throw;
            }
        }

        /// <summary>
        /// Run the method represented by the VoidMethodDelegate.
        /// </summary>
        /// <param name="methodDelegate">A delegate of a void and non-parameter method.</param>
        /// <param name="waitForm">The progres form will show while the method is processing in the background.</param>
        public static void DoWork(VoidDelegate methodDelegate, ProgressForm waitForm)
        {
            try
            {
                //Store the exception occured while running the thread.
                Exception threadException = null;

                Thread thread = new Thread(delegate()
                {
                    try
                    {
                        methodDelegate();                        
                    }
                    catch (Exception exc)
                    {
                        threadException = exc;
                    }
                    finally
                    {
                        //Close the progress form whatever occured!
                        waitForm.CloseDialog();
                    }
                });

                //Run the method
                thread.Start();

                //Show the progress form.
                waitForm.ShowDialog();

                //Throw the exception that occured while executing the thread.
                if (threadException != null)
                    throw threadException;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ThreadHelper).ToString(), exc);
                throw;
            }
        }

        /// <summary>
        /// Run the method represented by the ObjectReturnMethodDelegate.
        /// </summary>
        /// <param name="methodDelegate">A delegate of a method which has no parameter and return an object.</param>
        /// <param name="waitForm">The progres form will show while the method is processing in the background.</param>
        /// <returns>An instance of an object.</returns>
        public static Object DoWork(ObjectReturnDelegate methodDelegate, ProgressForm waitForm)
        {
            try
            {
                //Store the exception occured while running the thread.
                Exception threadException = null;

                //The returned value.
                Object objResult = null;

                Thread thread = new Thread(delegate()
                {
                    try
                    {
                        objResult = methodDelegate();
                    }
                    catch (Exception exc)
                    {
                        threadException = exc;
                    }
                    finally
                    {
                        //Close the progress form whatever occured!
                        waitForm.CloseDialog();
                    }
                });

                //Run the method
                thread.Start();

                //Show the progress form.
                waitForm.ShowDialog();

                //Throw the exception that occured while executing the thread.
                if (threadException != null)
                    throw threadException;

                return objResult;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ThreadHelper).ToString(), exc);
                throw;
            }
        }

        /// <summary>
        /// Run the method represented by the ObjectParamMethodDelegate.
        /// </summary>
        /// <param name="methodDelegate">The delegate of a method that has an object as its argument.</param>
        /// <param name="waitForm">The progres form will show while the method is processing in the background.</param>
        /// <param name="arg"></param>
        public static void DoWork(ObjectParamDelegate methodDelegate, ProgressForm waitForm, Object arg)
        {
            try
            {
                //Store the exception occured while running the thread.
                Exception threadException = null;

                Thread thread = new Thread(delegate()
                {
                    try
                    {
                        methodDelegate(arg);
                    }
                    catch (Exception exc)
                    {
                        threadException = exc;
                    }
                    finally
                    {
                        //Close the progress form whatever occured!
                        waitForm.CloseDialog();
                    }
                });

                //Run the method
                thread.Start();

                //Show the progress form.
                waitForm.ShowDialog();

                //Throw the exception that occured while executing the thread.
                if (threadException != null)
                    throw threadException;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ThreadHelper).ToString(), exc);
                throw;
            }
        }

        /// <summary>
        /// Run the method represented by the O2MethodDelegate.
        /// </summary>
        /// <param name="methodDelegate">The delegate of a method that has an object as its argument and return another object.</param>
        /// <param name="waitForm">The progres form will show while the method is processing in the background.</param>
        /// <param name="arg">An instance of an object.</param>
        /// <returns>An instance of an object.</returns>
        public static Object DoWork(O2Delegate methodDelegate, ProgressForm waitForm, Object arg)
        {
            try
            {
                Exception threadException = null;

                Object objResult = null;
                Thread thread = new Thread(delegate()
                {
                    try
                    {
                        objResult = methodDelegate(arg);
                    }
                    catch (Exception exc)
                    {
                        threadException = exc;
                    }
                    finally
                    {
                        //Close the progress form whatever occured!
                        waitForm.CloseDialog();
                    }
                });

                //Run the method
                thread.Start();

                //Show the progress form.
                waitForm.ShowDialog();
                
                //Throw the exception that occured while executing the thread.
                if (threadException != null)
                    throw threadException;

                return objResult;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ThreadHelper).ToString(), exc);
                throw;
            }
        }

        /// <summary>
        /// Run the method represented by the ObjectParamsMethodDelegate.
        /// </summary>
        /// <param name="methodDelegate">The delegate of a method that can have multiple arguments.</param>
        /// <param name="waitForm">The progres form will show while the method is processing in the background.</param>
        /// <param name="args">An array of objects to pass as arguments to the specified method. This parameter can be null if the method takes no arguments.</param>
        public static void DoWork(ObjectParamsDelegate methodDelegate, ProgressForm waitForm, params Object[] args)
        {
            try
            {
                Exception threadException = null;

                Thread thread = new Thread(delegate()
                {
                    try
                    {
                        methodDelegate(args);
                    }
                    catch (Exception exc)
                    {
                        threadException = exc;
                    }
                    finally
                    {
                        //Close the progress form whatever occured!
                        waitForm.CloseDialog();
                    }
                });

                //Run the method
                thread.Start();

                //Show the progress form.
                waitForm.ShowDialog();

                //Throw the exception that occured while executing the thread.
                if (threadException != null)
                    throw threadException;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ThreadHelper).ToString(), exc);
                throw;
            }
        }

        /// <summary>
        /// Run the method represented by the O2ParamsMethodDelegate.
        /// </summary>
        /// <param name="methodDelegate"></param>
        /// <param name="waitForm">The progres form will show while the method is processing in the background.</param>
        /// <param name="args">An array of objects to pass as arguments to the specified method. This parameter can be null if the method takes no arguments.</param>
        /// <returns>An instance of an object.</returns>
        public static Object DoWork(O2ParamsDelegate methodDelegate, ProgressForm waitForm, params Object[] args)
        {
            try
            {
                Exception threadException = null;

                Object objResult = null;

                Thread thread = new Thread(delegate()
                {
                    try
                    {
                        objResult = methodDelegate(args);
                    }
                    catch (Exception exc)
                    {
                        threadException = exc;
                    }
                    finally
                    {
                        //Close the progress form whatever occured!
                        waitForm.CloseDialog();
                    }
                });

                //Run the method
                thread.Start();

                //Show the progress form.
                waitForm.ShowDialog();

                //Throw the exception that occured while executing the thread.
                if (threadException != null)
                    throw threadException;

                return objResult;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(ThreadHelper).ToString(), exc);
                throw;
            }
        }

        #endregion
    }
}
