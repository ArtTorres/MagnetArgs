using System;
using System.Collections.Generic;
using System.Reflection;

namespace MagnetArgs
{
    static class MagnetExtension
    {
        static IEnumerable<IOption> GetArguments(this IOption opt)
        {
            PropertyInfo[] properties = opt.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                OptionSetAttribute attribute = opt.GetAttribute<OptionSetAttribute>(propertyInfo);

                if (null != attribute)
                {
                    yield return (MagnetOption)propertyInfo.GetValue(opt, null);
                }
            }
        }

        static T GetAttribute<T>(this IOption opt, MemberInfo member) where T : Attribute
        {
            object[] attributes = member.GetCustomAttributes(true);

            T result;
            for (int i = 0; i < attributes.Length; i++)
            {
                object obj = attributes[i];

                if (obj is T)
                {
                    result = (T)((object)obj);
                    return result;
                }
            }

            return default(T);
        }
    }
}
