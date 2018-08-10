using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class IfPresentAttribute : Attribute
    {
        public bool Value { get; private set; }

        public IfPresentAttribute()
        {
            this.Value = true;
        }
    }
}
