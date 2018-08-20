using System;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    public class OutOfRangeException : MagnetException
    {
        /// <summary>
        /// 
        /// </summary>
        public OutOfRangeException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public OutOfRangeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public OutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
