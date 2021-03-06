﻿using System.Diagnostics;

namespace Util.Log
{
    /// <summary>
    /// Available message severities for log messages
    /// </summary>
    public enum MessageType
    {
        /// <summary>Error message</summary>
        Error= TraceEventType.Error,

        /// <summary>Warning message</summary>
        Warning = TraceEventType.Warning,

        /// <summary>Informational message</summary>
        Info = TraceEventType.Information
    } 

}