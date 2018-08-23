using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents a marker for automatic identification of arguments in command line.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public sealed class OptionSetAttribute : Attribute
    {
        /// <summary>
        /// Initializes an instance of <see cref="OptionSetAttribute"/>.
        /// </summary>
        public OptionSetAttribute()
        {

        }
    }
}
