using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents the definition of a default value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public sealed class DefaultAttribute : Attribute
    {
        /// <summary>
        /// Gets the value by default.
        /// </summary>
        public string Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(string value)
        {
            this.Value = value;
        }
    }
}
