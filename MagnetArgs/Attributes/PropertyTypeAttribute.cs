using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents the type of a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class PropertyTypeAttribute : Attribute
    {
        /// <summary>
        /// Gets an array of types.
        /// </summary>
        public Type[] Types
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of <see cref="PropertyTypeAttribute"/>.
        /// </summary>
        /// <param name="types">An array of expected types.</param>
        public PropertyTypeAttribute(params Type[] types)
        {
            Types = types;
        }
    }
}
