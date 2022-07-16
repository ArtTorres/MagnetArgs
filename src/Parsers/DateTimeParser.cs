using System;

namespace MagnetArgs.Parsers
{
    /// <summary>
    /// Represent a parsing class for <see cref="DateTime"/> arguments.
    /// </summary>
    public class DateTimeParser : IParser
    {
        /// <summary>
        /// Transforms an text input in an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">A text input who represents a complex object.</param>
        /// <returns>An instance of the parsing object.</returns>
        public object Parse(string value)
        {
            return DateTime.Parse(value);
        }
    }
}
