using System;

namespace MagnetArgs
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class OptionSetAttribute : Attribute
    {
        public OptionSetAttribute()
        {

        }
    }
}
