﻿using System;

namespace MagnetArgs
{
    /// <summary>
    /// Represents an argument in command line.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public sealed class ArgAttribute : Attribute
    {
        /// <summary>
        /// Gets the name identifier of the argument.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the alias (alternative name) of the argument.
        /// </summary>
        public string Alias
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes an instance of <see cref="ArgAttribute"/>.
        /// </summary>
        /// <param name="name">The name identifier for the argument.</param>
        public ArgAttribute(string name)
        {
            this.Name = name;
            this.Alias = name;
        }
    }
}
