using System;

namespace MagnetArgs
{
    [AttributeUsage(AttributeTargets.Class)]
    class PropertyTypeAttribute : Attribute
    {
        public Type[] Types { get; private set; }

        public PropertyTypeAttribute(params Type[] types)
        {
            Types = types;
        }
    }
}
