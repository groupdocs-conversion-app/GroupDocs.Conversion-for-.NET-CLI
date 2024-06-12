﻿using GroupDocs.Conversion.Cli.Utils;
using GroupDocs.Conversion.Logging;

namespace GroupDocs.Conversion.Cli.Logging
{
    
    /// <summary>
    /// CLI logging implementation.
    /// </summary>
    internal class CliLogger : ILogger
    {
        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="exception">Exception object.</param>
        public void Error(string message, Exception exception)
        {
            Reporter.Error.WriteLine($"[ERROR] Exception {exception.Message} - {message} ");
        }

        /// <summary>
        /// Log trace (info) message.
        /// </summary>
        /// <param name="message"></param>
        public void Trace(string message)
        {
            string infoPrefix = "[TRACE] ";
            Reporter.Verbose.WriteLine(infoPrefix + message);
        }

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message"></param>
        public void Warning(string message)
        {
            Reporter.Verbose.WriteLine("[WARNING] " + message);
        }
    }
}
