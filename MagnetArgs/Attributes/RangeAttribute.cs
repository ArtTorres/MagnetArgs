using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class RangeAttribute : Attribute
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public bool Value { get; private set; }

        public RangeAttribute(int min, int max)
        {
            this.Value = false;
        }
    }
}
