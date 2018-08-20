using System;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class PropertyTypeAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type[] Types { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="types"></param>
        public PropertyTypeAttribute(params Type[] types)
        {
            Types = types;
        }
    }
}
