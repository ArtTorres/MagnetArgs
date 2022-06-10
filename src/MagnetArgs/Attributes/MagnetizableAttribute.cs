using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents a magnetizable class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class MagnetizableAttribute : Attribute
    {
    }
}
