using System;

namespace MagnetArgs
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class ArgAttribute : Attribute
    {
        public string Name
        {
            get;
            private set;
        }

        public string Alias
        {
            get;
            set;
        }

        public ArgAttribute(string name)
        {
            this.Name = name;
            this.Alias = name;
        }
    }
}
