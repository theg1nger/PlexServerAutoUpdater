using System;
using System.Runtime.Serialization;

namespace TE.PlexUpdater.System
{
    /// <summary>
    /// The SID for the Windows user could not be found.
    /// </summary>
    public class WindowsUserSidNotFoundException : Exception
    {
        /// <summary>
        /// Initializes the <see cref="WindowsUserSidNotFoundException"/>
        /// class.
        /// </summary>
        public WindowsUserSidNotFoundException() { }

        /// <summary>
        /// Initializes the <see cref="WindowsUserSidNotFoundException"/>
        /// class when provided with the exception messsage.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public WindowsUserSidNotFoundException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes the <see cref="WindowsUserSidNotFoundException"/>
        /// class when provided with the exception messsage and the inner
        /// exception.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public WindowsUserSidNotFoundException(
            string message,
            Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Initializes the <see cref="WindowsUserSidNotFoundException"/>
        /// class when provided with the serialization information and
        /// streaming context.
        /// </summary>
        /// <param name="info">
        /// The serialization information.
        /// </param>      
        /// <param name="context">
        /// The streaming context.
        /// </param>
        protected WindowsUserSidNotFoundException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }
}
}
