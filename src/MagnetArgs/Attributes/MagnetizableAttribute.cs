using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents a magnetizable attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class MagnetizableAttribute : Attribute
    {
    }
}
