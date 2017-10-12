using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;


namespace Util.Log
{
    public class LogManager
    {

        //In order to avoid creating instances of this class, the constructor
        //must be private.
        private LogManager() { }

        /// <summary>
        /// Records the message. The default severity level is set to ERROR
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void RecordMessage(String message)
        {
            RecordMessage(message, MessageType.Error, "General");
        }

        public static void RecordMessage(String message, MessageType messageType)
        {
            RecordMessage(message, messageType, "General");
        }

        public static void RecordMessage(String message, MessageType messageType, string category)
        {

            Console.WriteLine("[" + DateTime.Now.ToString() + "] " +
                "(" + messageType.ToString() + ") : " + message);

            // Provided by MS Enterprise Library
            LogEntry entry = new LogEntry();

            entry.Message = message;
            entry.Severity = (TraceEventType)messageType;
            entry.Categories.Add(category);

            Logger.Write(entry);

        }

        #region Test code. Uncomment for testing


        //NOTE: Before executing the following code, the project must be 
        //changed from class library to console application at the project
        //properties window.
        //public static void Main(String[] args)
        //{
        //    LogManager.RecordMessage("Test Message 1 - ERROR Message", MessageType.Error);
        //    LogManager.RecordMessage("Test Message 2 - WARNING Message", MessageType.Warning);
        //    LogManager.RecordMessage("Test Message 3 - INFO Message", MessageType.Info);

        //    Console.ReadLine();
        //}

        #endregion
    }
}
