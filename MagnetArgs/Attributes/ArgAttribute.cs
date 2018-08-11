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
        //public bool IfPresent
        //{
        //    get;
        //    set;
        //}
        //public bool IsRequired
        //{
        //    get;
        //    set;
        //}

        //public object Parser
        //{
        //    get;
        //    set;
        //}
        //public string DefaultValue
        //{
        //    get;
        //    set;
        //}

        public ArgAttribute(string name)
        {
            this.Name = name;
            this.Alias = name;
        }
    }
}
