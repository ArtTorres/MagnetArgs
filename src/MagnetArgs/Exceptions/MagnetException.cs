using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents errors ocurr during magnetize execution.
    /// </summary>
    public class MagnetException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MagnetException"/> class.
        /// </summary>
        public MagnetException()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MagnetException"/> class with error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public MagnetException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MagnetException"/> class with error message and a reference of a inner exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception specified.</param>
        public MagnetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
