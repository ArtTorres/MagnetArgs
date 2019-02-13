using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    /// <summary>
    /// Represents an implementation of <see cref="IMagnetSet"/> as an argument option.
    /// </summary>
    public class MagnetSet : IMagnetSet
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
