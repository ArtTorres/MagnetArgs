using System;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class ArgAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Alias
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ArgAttribute(string name)
        {
            this.Name = name;
            this.Alias = name;
        }
    }
}
