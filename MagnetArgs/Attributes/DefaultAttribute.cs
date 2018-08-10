using System;

namespace MagnetArgs
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class DefaultAttribute : Attribute
    {
        public string Value { get; private set; }

        public DefaultAttribute(string value)
        {
            this.Value = value;
        }
    }
}
