using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents a is-required rule for argument evaluation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public sealed class IsRequiredAttribute : Attribute
    {
        /// <summary>
        /// Initializes an instance of <see cref="IsRequiredAttribute"/>.
        /// </summary>
        public IsRequiredAttribute()
        {
        }
    }
}
