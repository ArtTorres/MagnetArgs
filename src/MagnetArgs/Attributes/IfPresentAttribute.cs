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
        /// Gets the name identifier of the argument.
        /// </summary>
        public string ArgumentName
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of <see cref="IfPresentAttribute"/>.
        /// </summary>
        public IfPresentAttribute()
        {
        }

        /// <summary>
        /// Initializes an instance of <see cref="IfPresentAttribute"/>.
        /// </summary>
        /// <param name="argumentName">The name identifier of the argument.</param>
        public IfPresentAttribute(string argumentName)
        {
            this.ArgumentName = argumentName;
        }
    }
}
