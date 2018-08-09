using System;

namespace MagnetArgs
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    [PropertyType(typeof(IParser))]
    public class ParserAttribute : Attribute
    {
        public Type Type { get; set; }

        public ParserAttribute(Type type)
        {
            this.Type = type;
        }
    }
}
