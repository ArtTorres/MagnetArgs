using System;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    [PropertyType(typeof(IParser))]
    public class ParserAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public ParserAttribute(Type type)
        {
            this.Type = type;
        }
    }
}
