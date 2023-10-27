using System;
using System.Reflection;

namespace MagnetArgs
{
    /// <summary>
    /// Extends the functionality of <see cref="MemberInfo"/>.
    /// </summary>
    internal static class MemberInfoExtension
    {
        /// <summary>
        /// Retrieves an attribute from a MemberInfo instance.
        /// </summary>
        /// <typeparam name="T">The type of return attribute.</typeparam>
        /// <param name="member">An instance of <see cref="MemberInfo"/>.</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this MemberInfo member) where T : Attribute
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
