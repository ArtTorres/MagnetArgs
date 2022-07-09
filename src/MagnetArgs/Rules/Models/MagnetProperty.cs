using System.Collections.Generic;
using System.Reflection;

namespace MagnetArgs.Rules
{
    internal class MagnetProperty : IRulesPremise
    {
        public PropertyInfo Property { get; private set; }

        public KeyValue Input { get; private set; }

        public ArgumentAttribute Attribute { get; private set; }

        public IsRequiredAttribute IsRequiredAttribute { get; private set; }

        public IfPresentAttribute IfPresentAttribute { get; private set; }

        public DefaultAttribute DefaultAttribute { get; private set; }

        public ParserAttribute ParserAttribute { get; private set; }

        public bool HasKey { get; private set; }

        public bool HasValue { get; private set; }

        public bool IsNative { get; private set; }

        public bool IsTyped { get; private set; }

        public bool IsBoolean { get; private set; }

        public bool IsRequired { get; private set; }

        public bool IsPresent { get; private set; }

        public bool ExistNamed { get; private set; }

        public bool NamedHasValue { get; private set; }

        public bool HasDefault { get; private set; }

        public bool HasParser { get; private set; }

        private Dictionary<string, string> _args;


        public MagnetProperty(PropertyInfo property, Dictionary<string, string> args)
        {
            Property=property;
            _args=args;

            Attribute= property.GetAttribute<ArgumentAttribute>();
            IsRequiredAttribute= property.GetAttribute<IsRequiredAttribute>();
            IfPresentAttribute= property.GetAttribute<IfPresentAttribute>();
            DefaultAttribute= property.GetAttribute<DefaultAttribute>();
            ParserAttribute= property.GetAttribute<ParserAttribute>();

            Input= GetSample(args, Attribute);

            SetPremises();
        }

        private void SetPremises()
        {
            HasKey = null != Input.Key;
            HasValue = !string.IsNullOrEmpty(Input.Value);

            IsNative = (Property.PropertyType.IsPrimitive || Property.PropertyType == typeof(string));
            IsBoolean = Property.PropertyType == typeof(bool);
            IsTyped = !IsNative;

            IsRequired = null != IsRequiredAttribute;
            IsPresent= null != IfPresentAttribute;

            ExistNamed = (
                IsPresent 
                && null != IfPresentAttribute.ArgumentName 
            );
            NamedHasValue = (
                ExistNamed 
                && _args.ContainsKey(IfPresentAttribute.ArgumentName) 
                && null != _args[IfPresentAttribute.ArgumentName]
            );

            HasDefault = null != DefaultAttribute;
            HasParser = null != ParserAttribute;
        }

        private KeyValue GetSample(Dictionary<string, string> args, ArgumentAttribute attribute)
        {
            string key = null;
            if (args.ContainsKey(attribute.Name.ToLowerInvariant()))
                key = attribute.Name;
            else if (args.ContainsKey(attribute.Alias.ToLowerInvariant()))
                key = attribute.Alias;

            string value = null;
            if (key != null)
                value = args[key];

            return new KeyValue(key, value);
        }
    }
}
