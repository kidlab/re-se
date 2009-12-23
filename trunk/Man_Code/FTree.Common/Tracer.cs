using System;
using System.IO;
using System.Threading;

namespace FTree.Common
{
    /// <summary>
    /// Traces and saves all errors to the log file.
    /// </summary>
    public class Tracer : BaseObject
    {
        private static string logFile = FTreeConst.LOG_FILE;
        private static string logThreadName = String.Empty;
        private static string newLine = Environment.NewLine;
        private const string LOG_MSG_FORMAT = "****************************************************{0}{0}[{1}][version: {4}][{2}]:{0}{3}";

        /// <summary>
        /// Set the path of the log file.
        /// </summary>
        /// <param name="filePath">Path to the log file. If the param is null or empty, this mehod will set the default file path for the log file.</param>
        public static void SetupLogFile(string filePath)
        {
            if (String.IsNullOrEmpty(filePath.Trim()))
                logFile = FTreeConst.LOG_FILE;
            else
                logFile = filePath;
        }

        /// <summary>
        /// Save a exception to log file with a specific Type and a thread's name.
        /// </summary>
        /// <param name="type">A kind of CLR Type.</param>
        /// <param name="exc">The Exception needs saving.</param>
        public static void Log(Type type, Exception exc)
        {
            Log(type.ToString(), exc);
        }

        /// <summary>
        /// Save a message to log file with a specific Type and a thread's name.
        /// </summary>
        /// <param name="type">A kind of CLR Type.</param>
        /// <param name="message">The message needs saving.</param>
        public static void Log(Type type, string message)
        {
            Log(type.ToString(), message);
        }

        /// <summary>
        /// Save the specified exception message to log file with a thread's name.
        /// </summary>
        /// <param name="threadName">The thread's name.</param>
        /// <param name="exc">The Exception needs saving.</param>
        public static void Log(string threadName, Exception exc)
        {
            logThreadName = threadName;
            Log(exc);
        }

        /// <summary>
        /// Save the specified exception message to log file.
        /// </summary>
        /// <param name="exc">The Exception needs saving.</param>
        public static void Log(Exception exc)
        {
            Log(exc.Message + newLine + exc.ToString());
        }

        /// <summary>
        /// Save the specified message to log file with the thread's name.
        /// </summary>
        /// <param name="threadName">The thread's name.</param>
        /// <param name="message">Message needs saving.</param>
        public static void Log(string threadName, string message)
        {
            logThreadName = threadName;
            Log(message);
        }

        /// <summary>
        /// Save the specified message to log file.
        /// </summary>
        /// <param name="message">Message needs saving.</param>
        public static void Log(string message)
        {
            Log(logThreadName, message, logFile);
        }

        /// <summary>
        /// Log to a specific file.
        /// </summary>
        /// <param name="threadName">The thread's name.</param>
        /// <param name="message">Message needs saving.</param>
        /// <param name="logFilePath">The path to log file.</param>
        public static void Log(string threadName, string message, string logFilePath)
        {
            bool ownsMutex = false;
            Mutex mutex = new Mutex(true, typeof(Tracer).ToString(), out ownsMutex);

            //To prevent a dirty write to this file.
            if (!ownsMutex)
                mutex.WaitOne();

            if (String.IsNullOrEmpty(logFilePath))
                return;

            StreamWriter writer = new StreamWriter(logFilePath, true, System.Text.Encoding.UTF8);

            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

            writer.WriteLine(
                String.Format(LOG_MSG_FORMAT,
                                newLine,
                                threadName,
                                DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay,
                                message,
                                asm.GetName().Version)
                            );
            writer.Flush();
            writer.Close();

            //Release the mutex to allow other thread to access this file.
            mutex.ReleaseMutex();
        }
    }
}
