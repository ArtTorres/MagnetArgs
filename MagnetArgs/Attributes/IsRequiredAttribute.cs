using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class IsRequiredAttribute : Attribute
    {
        public bool Value { get; private set; }

        public IsRequiredAttribute()
        {
            this.Value = true;
        }
    }
}
