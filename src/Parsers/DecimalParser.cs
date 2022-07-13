using System;

namespace MagnetArgs.Parsers
{
    /// <summary>
    /// Represent a parsing class for <see cref="Decimal"/> arguments.
    /// </summary>
    public class DecimalParser : IParser
    {
        /// <summary>
        /// Transforms an text input in an instance of <see cref="Decimal"/>.
        /// </summary>
        /// <param name="value">A text input who represents a complex object.</param>
        /// <returns>An instance of the parsing object.</returns>
        public object Parse(string value)
        {
            return decimal.Parse(value);
        }
    }
}
