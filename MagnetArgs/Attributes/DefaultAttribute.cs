using System;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class DefaultAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public DefaultAttribute(string value)
        {
            this.Value = value;
        }
    }
}
