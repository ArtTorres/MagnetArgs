using System;
using System.Collections.Generic;
using System.Linq;
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
        public static T Attract<T>(string[] args, char symbol = '-') where T : class
        {
            T obj = default;

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
        /// <param name="args">A collection of arguments.</param>
        /// <param name="obj">The object to magnetize.</param>
        /// <exception cref="AggregateException">Throw a collection of errors if an argument error found.</exception>
        public static void Attract<T>(Dictionary<string, string> args, T obj) where T : class
        {
            if (obj.ContainsAttribute<MagnetizableAttribute>())
            {
                var errors = new List<Exception>();
                var properties = new Dictionary<PropertyInfo, PropertyInfo>();

                foreach (var propertyInfo in obj.GetType().GetProperties())
                {
                    var attribute = propertyInfo.GetAttribute<ArgumentAttribute>();

                    if (null != attribute)
                    {
                        var isRequiredIfPresent = propertyInfo.GetAttribute<IsRequiredIfPresentAttribute>();
                        var isRequired = propertyInfo.GetAttribute<IsRequiredAttribute>();
                        var ifPresent = propertyInfo.GetAttribute<IfPresentAttribute>();
                        var @default = propertyInfo.GetAttribute<DefaultAttribute>();
                        var @parser = propertyInfo.GetAttribute<ParserAttribute>();

                        try
                        {
                            // find key
                            string key = null;
                            if (args.ContainsKey(attribute.Name.ToLowerInvariant()))
                                key = attribute.Name;
                            else if (args.ContainsKey(attribute.Alias.ToLowerInvariant()))
                                key = attribute.Alias;

                            // set value
                            string value = null;
                            if (key != null)
                                value = args[key];


                            if (isRequired != null && (key == null || string.IsNullOrEmpty(value)))
                            {   // if required with no key in arguments or no value specified by user
                                throw new ArgumentNotFoundException(string.Format("{0} is required and has no value.", attribute.Name));
                            }


                            if (isRequiredIfPresent != null && (key == null || string.IsNullOrEmpty(value)))
                            {
                                var target = obj.GetType().GetProperties()
                                    .SingleOrDefault(s => s.GetAttribute<ArgumentAttribute>().Name == isRequiredIfPresent.ArgumentName);

                                if (target != null)
                                    properties.Add(propertyInfo, target);
                                else
                                    throw new ArgumentNotFoundException(attribute.Name, $"Required argument \"{isRequiredIfPresent.ArgumentName}\" not found.");
                            }


                            // default value
                            if ((key == null || string.IsNullOrEmpty(value)) && (@default != null && !string.IsNullOrEmpty(@default.Value)))
                                value = @default.Value;


                            if (ifPresent != null && key != null)
                            {   // if present argument
                                if (propertyInfo.PropertyType == typeof(bool))
                                    value = "true";
                                else if (@default == null || string.IsNullOrEmpty(@default.Value))
                                    throw new ArgumentFormatException("Non boolean attributes with IfPresent rule require a default value.");
                                else
                                    value = @default.Value;
                            }


                            if (value != null)
                            {
                                try
                                {
                                    if (@parser == null)
                                    {   // value types
                                        propertyInfo.SetValue(
                                            obj,
                                            Convert.ChangeType(value, propertyInfo.PropertyType),
                                            null
                                        );
                                    }
                                    else
                                    {   // custom types
                                        var instance = (IParser)Activator.CreateInstance(@parser.Type);
                                        propertyInfo.SetValue(
                                            obj,
                                            instance.Parse(value),
                                            null
                                        );
                                    }
                                }
                                catch (FormatException)
                                {
                                    errors.Add(new ArgumentFormatException(attribute.Name));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            errors.Add(ex);
                        }
                    }
                }

                foreach (var property in properties)
                {
                    if (property.Key.GetValue(obj) != null && property.Value.GetValue(obj) != null)
                    {
                        errors.Add(new ArgumentNotFoundException(string.Format("{0} is required and has no value.", property.Key.Name)));
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
    }
}
