using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents a MagnetArgs attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class MagnetizableAttribute : Attribute
    {
    }
}
