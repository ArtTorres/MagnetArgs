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

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(char value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(bool value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(byte value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(sbyte value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(short value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(ushort value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(int value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(uint value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(long value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(ulong value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(float value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="DefaultAttribute"/>.
        /// </summary>
        /// <param name="value">The default value of an argument.</param>
        public DefaultAttribute(double value)
        {
            this.Value = value.ToString();
        }
    }
}
