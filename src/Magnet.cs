using MagnetArgs.Parsers;
using MagnetArgs.Rules;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MagnetArgs
{
    /// <summary>
    /// Represents a magnet that attracts argument values.
    /// </summary>
    public static class Magnet
    {
        /// <summary>
        /// Magnetizes an object.
        /// </summary>
        /// <typeparam name="T">The type of the class object to magnetize.</typeparam>
        /// <param name="args">A list of arguments.</param>
        /// <param name="symbol">The symbol identifier for an option argument.</param>
        /// <exception cref="AggregateException">Throw a collection of errors if argument errors found.</exception>
        /// <exception cref="NotMagnetizableException">Throw if the object doesn't implement <see cref="MagnetizableAttribute"/>.</exception>
        public static T Attract<T>(string[] args, char symbol = '-') where T : class, new()
        {
            T obj = new T();

            Attract(GetArguments(args, symbol), obj);

            return obj;
        }

        /// <summary>
        /// Magnetizes an object.
        /// </summary>
        /// <typeparam name="T">The type of the class object to magnetize.</typeparam>
        /// <param name="args">A list of arguments.</param>
        /// <param name="obj">The object to magnetize.</param>
        /// <param name="symbol">The symbol identifier for an option argument.</param>
        /// <exception cref="AggregateException">Throw a collection of errors if argument errors found.</exception>
        /// <exception cref="NotMagnetizableException">Throw if the object doesn't implement <see cref="MagnetizableAttribute"/>.</exception>
        public static void Attract<T>(string[] args, T obj, char symbol = '-') where T : class
        {
            Attract(GetArguments(args, symbol), obj);
        }

        /// <summary>
        /// Magnetizes an object.
        /// </summary>
        /// <typeparam name="T">The type of the class object to magnetize.</typeparam>
        /// <param name="args">A list of arguments.</param>
        /// <exception cref="AggregateException">Throw a collection of errors if argument errors found.</exception>
        /// <exception cref="NotMagnetizableException">Throw if the object doesn't implement <see cref="MagnetizableAttribute"/>.</exception>
        public static T Attract<T>(Dictionary<string, string> args) where T : class
        {
            T obj = default;

            Attract<T>(args, obj);

            return obj;
        }

        /// <summary>
        /// Magnetizes an object.
        /// </summary>
        /// <typeparam name="T">The type of the class object to magnetize.</typeparam>
        /// <param name="args">A list of arguments.</param>
        /// <param name="obj">The object to magnetize.</param>
        /// <exception cref="AggregateException">Throw a collection of errors if argument errors found.</exception>
        /// <exception cref="NotMagnetizableException">Throw if the object doesn't implement <see cref="MagnetizableAttribute"/>.</exception>
        public static void Attract<T>(Dictionary<string, string> args, T obj) where T : class
        {
            if (obj.ContainsAttribute<MagnetizableAttribute>())
            {
                var errors = new List<Exception>();

                var rules = new MagnetRules();
                var properties = obj.GetType().GetProperties();

                foreach (var property in properties)
                {
                    MagnetProperty mProperty = new MagnetProperty(property, args); ;

                    if (null != mProperty.Attribute)
                    {
                        try
                        {
                            if (mProperty.ExistNamed && !ExistArgument(mProperty.IfPresentAttribute.ArgumentName, properties))
                                throw new ArgumentNotFoundException(mProperty.IfPresentAttribute.ArgumentName);

                            var result = rules.Eval(mProperty.Attribute.Name, mProperty);

                            var action = result.Item1;
                            var source = result.Item2;

                            switch (action)
                            {
                                case MagnetAction.SetNative:
                                case MagnetAction.SetTyped:
                                    SetValue(obj, GetValueFromSource(source, mProperty), mProperty);
                                    break;
                                case MagnetAction.SetTrue:
                                    SetValue(obj, bool.TrueString, mProperty);
                                    break;
                                case MagnetAction.Ignore:
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            errors.Add(new ArgumentFormatException(mProperty.Attribute.Name));
                        }
                        catch (Exception ex)
                        {
                            errors.Add(ex);
                        }
                    }
                }

                if (errors.Count > 0)
                {
                    throw new AggregateException(errors);
                }
            }
            else
            {
                throw new NotMagnetizableException(obj.GetType().ToString());
            }
        }

        /// <summary>
        /// Retrieves an instance of Dictionary with arguments and values.
        /// </summary>
        /// <param name="args">A list of arguments.</param>
        /// <param name="symbol">The symbol identifier for an option argument.</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetArguments(string[] args, char symbol)
        {
            var output = new Dictionary<string, string>();
            string arg = null;

            foreach (var value in args)
            {
                if (value.StartsWith(symbol.ToString()))
                {   // sets key
                    arg = Regex.Match(value, @"\w+[\w\W]*").Value.ToLowerInvariant();
                    output.Add(arg, null);
                }
                else if (!string.IsNullOrEmpty(arg))
                {   // sets value
                    output[arg] = value;
                }
            }

            return output;
        }

        /// <summary>
        /// Sets a value to an object property.
        /// </summary>
        /// <typeparam name="T">The type of the class object to magnetize.</typeparam>
        /// <param name="obj">The object to set value.</param>
        /// <param name="value">The value to be set.</param>
        /// <param name="property">An instance of <see cref="MagnetProperty"/>.</param>
        /// <exception cref="MissingParserException"></exception>
        private static void SetValue<T>(T obj, string value, MagnetProperty property) where T : class
        {
            if (value != null)
            {
                if (property.ParserAttribute == null)
                {   // primitive types
                    property.Property.SetValue(
                        obj,
                        Convert.ChangeType(value, property.Property.PropertyType),
                        null
                    );
                }
                else
                {   // custom types
                    if (typeof(IParser).IsAssignableFrom(property.ParserAttribute.Type))
                    {
                        var instance = (IParser)Activator.CreateInstance(property.ParserAttribute.Type);
                        property.Property.SetValue(
                            obj,
                            instance.Parse(value),
                            null
                        );
                    }
                    else
                    {
                        throw new MissingParserException(property.Attribute.Name, $"Class {property.ParserAttribute.Type} is not a valid parser.");
                    }
                }
            }
        }

        /// <summary>
        /// Gets a value from the attribues depending of an specific source.
        /// </summary>
        /// <param name="source">The source of the value.</param>
        /// <param name="property">The property where get the value.</param>
        /// <returns>The value.</returns>
        private static string GetValueFromSource(Source source, MagnetProperty property)
        {
            switch (source)
            {
                case Source.Input:
                    return property.Input.Value;
                case Source.Default:
                    return property.DefaultAttribute.Value;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Validates if an argument has been implemented as a <see cref="ArgumentAttribute"/>.
        /// </summary>
        /// <param name="argumentName">The argument to validate.</param>
        /// <param name="properties">The list of properties to look for.</param>
        /// <returns></returns>
        private static bool ExistArgument(string argumentName, IEnumerable<PropertyInfo> properties)
        {
            foreach (PropertyInfo property in properties)
            {
                if (argumentName.Equals(property.GetAttribute<ArgumentAttribute>().Name))
                    return true;
            }

            return false;
        }
    }
}
