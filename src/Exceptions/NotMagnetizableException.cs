using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents an error when an object is not magnetizable.
    /// </summary>
    public class NotMagnetizableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NotMagnetizableException"/> class.
        /// </summary>
        public NotMagnetizableException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NotMagnetizableException"/> class with error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public NotMagnetizableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NotMagnetizableException"/> class with error message and a reference of a inner exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception specified.</param>
        public NotMagnetizableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
