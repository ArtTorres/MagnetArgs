using System;
using System.Collections.Generic;
using System.Reflection;

namespace MagnetArgs
{
    public class MagnetOption : IOption
    {
        public int Order
        {
            get;
            set;
        } = 0;

        //public IEnumerable<HelpAttribute> Help
        //{
        //    get;
        //    set;
        //}

        public IEnumerable<Exception> Exceptions
        {
            get;
            set;
        } = new List<Exception>();


        //public IEnumerable<IOption> GetArguments()
        //{
        //    PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        //    for (int i = 0; i < properties.Length; i++)
        //    {
        //        PropertyInfo propertyInfo = properties[i];
        //        OptionSetAttribute attribute = GetAttribute<OptionSetAttribute>(propertyInfo);

        //        if (null != attribute)
        //        {
        //            yield return (MagnetOption)propertyInfo.GetValue(this, null);
        //        }
        //    }
        //}

        //private T GetAttribute<T>(MemberInfo member) where T : Attribute
        //{
        //    object[] attributes = member.GetCustomAttributes(true);

        //    T result;
        //    for (int i = 0; i < attributes.Length; i++)
        //    {
        //        object obj = attributes[i];

        //        if (obj is T)
        //        {
        //            result = (T)((object)obj);
        //            return result;
        //        }
        //    }

        //    return default(T);
        //}
    }
}
