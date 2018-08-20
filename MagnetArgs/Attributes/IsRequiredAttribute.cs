using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class IsRequiredAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Value { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IsRequiredAttribute()
        {
            this.Value = true;
        }
    }
}
