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
        /// Retrieves a collecion of <see cref="IOption"/> in a specified object.
        /// </summary>
        /// <param name="option">Extension type object.</param>
        /// <returns></returns>
        static IEnumerable<IOption> GetArguments(this IOption option)
        {
            PropertyInfo[] properties = option.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];

                if (typeof(IOption).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    yield return (MagnetOption)propertyInfo.GetValue(option, null);
                }
            }
        }

        /// <summary>
        /// Retrieves a specified attribute from a <see cref="MemberInfo"/> object.
        /// </summary>
        /// <typeparam name="T">The type of return attribute.</typeparam>
        /// <param name="option">Extension type object.</param>
        /// <param name="member">An instance of <see cref="MemberInfo"/>.</param>
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
