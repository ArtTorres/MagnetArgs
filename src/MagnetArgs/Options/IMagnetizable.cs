﻿using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    /// <summary>
    /// Represents an argument option.
    /// </summary>
    public interface IMagnetizable
    {
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
