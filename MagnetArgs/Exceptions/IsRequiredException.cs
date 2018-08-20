using System;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    public class IsRequiredException : MagnetException
    {
        /// <summary>
        /// 
        /// </summary>
        public IsRequiredException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public IsRequiredException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public IsRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
