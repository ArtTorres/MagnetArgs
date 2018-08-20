using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOption
    {
        /// <summary>
        /// 
        /// </summary>
        int Order
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Exception> Exceptions
        {
            get;
            set;
        }
    }
}
