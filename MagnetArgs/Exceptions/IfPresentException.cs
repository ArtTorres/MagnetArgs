using System;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    public class IfPresentException : MagnetException
    {
        /// <summary>
        /// 
        /// </summary>
        public IfPresentException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public IfPresentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public IfPresentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
