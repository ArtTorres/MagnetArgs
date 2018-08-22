using System;
using System.Collections.Generic;
using System.Reflection;

namespace MagnetArgs
{
    /// <summary>
    /// Extends the functionality of the IOption interface.
    /// </summary>
    static class IOptionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        static IEnumerable<IOption> GetArguments(this IOption option)
        {
            PropertyInfo[] properties = option.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                OptionSetAttribute attribute = option.GetAttribute<OptionSetAttribute>(propertyInfo);

                if (null != attribute)
                {
                    yield return (MagnetOption)propertyInfo.GetValue(option, null);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="option"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        static T GetAttribute<T>(this IOption option, MemberInfo member) where T : Attribute
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
