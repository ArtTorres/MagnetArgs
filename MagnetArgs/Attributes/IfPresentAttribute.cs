using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class IfPresentAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Value { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IfPresentAttribute()
        {
            this.Value = true;
        }
    }
}
