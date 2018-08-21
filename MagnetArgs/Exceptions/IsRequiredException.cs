﻿using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents argument required errors ocurr during magnetize execution.
    /// </summary>
    public class IsRequiredException : MagnetException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsRequiredException"/> class.
        /// </summary>
        public IsRequiredException()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IsRequiredException"/> class with error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public IsRequiredException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IsRequiredException"/> class with error message and a reference of a inner exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception specified.</param>
        public IsRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
