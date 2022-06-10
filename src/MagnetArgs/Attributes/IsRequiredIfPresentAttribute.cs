using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents a is-required-if-present rule for argument evaluation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public sealed class IsRequiredIfPresentAttribute : Attribute
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
        /// Initializes an instance of <see cref="IsRequiredIfPresentAttribute"/>.
        /// </summary>
        /// <param name="argumentName">The name identifier of the argument.</param>
        public IsRequiredIfPresentAttribute(string argumentName)
        {
            this.ArgumentName = argumentName;
        }
    }
}
