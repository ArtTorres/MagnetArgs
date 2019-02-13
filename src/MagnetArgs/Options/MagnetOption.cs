using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    /// <summary>
    /// Represents an implementation of <see cref="IOption"/> as an argument option.
    /// </summary>
    public class MagnetOption : IOption
    {
        /// <summary>
        /// Gets the exceptions generated during the evaluation.
        /// </summary>
        public IEnumerable<Exception> Exceptions
        {
            get;
            set;
        } = new List<Exception>();
    }
}
