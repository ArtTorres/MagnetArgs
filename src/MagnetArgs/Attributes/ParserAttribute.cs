using System;

namespace MagnetArgs
{
    /// <summary>
    /// Repesent a parser class for complex arguments.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    [PropertyType(typeof(IParser))]
    public sealed class ParserAttribute : Attribute
    {
        /// <summary>
        /// Gets the type of the parsing class.
        /// </summary>
        public Type Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of <see cref="ParserAttribute"/>.
        /// </summary>
        /// <param name="type">The parsing class.</param>
        public ParserAttribute(Type type)
        {
            this.Type = type;
        }
    }
}
