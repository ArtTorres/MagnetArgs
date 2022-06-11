using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents an error from MagnetArgs.
    /// </summary>
    public class MagnetException : Exception
    {
        /// <summary>
        /// Gets the argument related with the exception.
        /// </summary>
        public string Argument { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="MagnetException"/> class.
        /// </summary>
        /// <param name="argument">The argument who caused the Exception.</param>
        public MagnetException(string argument)
        {
            this.Argument = argument;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MagnetException"/> class with error message.
        /// </summary>
        /// <param name="argument">The argument who caused the exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public MagnetException(string argument, string message)
            : base(message)
        {
            this.Argument = argument;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MagnetException"/> class with error message and a reference of a inner exception.
        /// </summary>
        /// <param name="argument">The argument who caused the exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception specified.</param>
        public MagnetException(string argument, string message, Exception inner)
            : base(message, inner)
        {
            this.Argument = argument;
        }
    }
}
