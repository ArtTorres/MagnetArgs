using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents a if-present rule for argument evaluation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public sealed class IfPresentAttribute : Attribute
    {
        /// <summary>
        /// Initializes an instance of <see cref="IfPresentAttribute"/>.
        /// </summary>
        public IfPresentAttribute()
        {
        }
    }
}
