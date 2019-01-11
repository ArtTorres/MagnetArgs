using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    /// <summary>
    /// Represents an argument option.
    /// </summary>
    public interface IOption
    {
        /// <summary>
        /// Gets or sets the order of evalutation of this option.
        /// </summary>
        int Order
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the exceptions generated during the evaluation.
        /// </summary>
        IEnumerable<Exception> Exceptions
        {
            get;
            set;
        }
    }
}
