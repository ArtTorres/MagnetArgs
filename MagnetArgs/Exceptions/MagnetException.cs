using System;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    public class MagnetException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public MagnetException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public MagnetException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public MagnetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
