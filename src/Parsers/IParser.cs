using System;

namespace MagnetArgs.Parsers
{
    /// <summary>
    /// Represent a parsing class for command arguments.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Transforms an text input in an instance of <see cref="Object"/>.
        /// </summary>
        /// <param name="value">A text input who represents a complex object.</param>
        /// <returns>An instance of the parsing object.</returns>
        object Parse(string value);
    }
}
