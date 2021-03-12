using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    /// <summary>
    /// Represents an implementation of <see cref="IMagnetizable"/> as an argument option.
    /// </summary>
    public class IronOre : IMagnetizable
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
