using System;

namespace MagnetArgs
{
    /// <summary>
    /// Extends the functinality of <see cref="Object"/>.
    /// </summary>
    internal static class ObjectExtension
    {
        /// <summary>
        /// TODO: Write Desc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ContainsAttribute<T>(this Object obj) where T : Attribute
        {
            var attributes = obj.GetType().GetCustomAttributes(typeof(T), false);

            foreach (var attribute in attributes)
            {
                if (attribute is T)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
