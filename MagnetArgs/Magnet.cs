using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MagnetArgs
{
    public static class Magnet
    {
        public static void Magnetize<T>(T obj, string[] args, char symbol = '-')
        {
            if (obj is IOption)
            {
                Magnetize((IOption)obj, GetArguments(args, symbol));
            }
            else
            {
                MapOptions(obj, args, symbol);
            }
        }

        public static void Magnetize<T>(T obj, Dictionary<string, string> args) where T : IOption
        {
            var errors = new List<Exception>();

            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                var attribute = GetAttribute<ArgAttribute>(propertyInfo);

                if (null != attribute)
                {
                    var isRequired = GetAttribute<IsRequiredAttribute>(propertyInfo);
                    var ifPresent = GetAttribute<IfPresentAttribute>(propertyInfo);
                    var @default = GetAttribute<DefaultAttribute>(propertyInfo);
                    var @parser = GetAttribute<ParserAttribute>(propertyInfo);

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
                            throw new IsRequiredException(string.Format("{0} is required and has no value.", attribute.Name));
                        }

                        // default value
                        if ((key == null || string.IsNullOrEmpty(value)) && (@default != null && !string.IsNullOrEmpty(@default.Value)))
                            value = @default.Value;

                        if (ifPresent != null && key != null)
                        {   // if present argument
                            if (propertyInfo.PropertyType == typeof(bool))
                                value = "true";
                            else if (@default == null || string.IsNullOrEmpty(@default.Value))
                                throw new IfPresentException("Non boolean attributes with IfPresent option require a default value.");
                            else
                                value = @default.Value;
                        }

                        if (value != null)
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
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex);
                    }
                }
            }

            obj.Exceptions = errors;
        }

        #region OptionSet

        private static void MapOptions(object obj, string[] args, char symbol = '-')
        {
            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                OptionSetAttribute attribute = GetAttribute<OptionSetAttribute>(propertyInfo);

                if (null != attribute)
                {
                    var o = (IOption)typeof(Magnet)
                    .GetMethod("CreateOptionSet", BindingFlags.NonPublic | BindingFlags.Static, null, new[] { typeof(string[]), typeof(char) }, null)
                    .MakeGenericMethod(propertyInfo.PropertyType)
                    .Invoke(obj, new object[] { args, symbol });

                    propertyInfo.SetValue(
                        obj,
                        o,
                        null
                    );
                }
            }
        }

        private static T CreateOptionSet<T>(string[] args, char symbol) where T : IOption, new()
        {
            return CreateOptionSet<T>(GetArguments(args, symbol));
        }

        public static T CreateOptionSet<T>(Dictionary<string, string> args) where T : IOption, new()
        {
            T obj = new T();

            Magnetize<T>(obj, args);

            return obj;
        }

        #endregion

        #region Tools

        /// <summary>
        /// Gets an instance of Dictionary with arguments and values.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="symbol"></param>
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
        /// Gets an attribute from a MemberInfo instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        private static T GetAttribute<T>(MemberInfo member) where T : Attribute
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

        #endregion
    }
}
