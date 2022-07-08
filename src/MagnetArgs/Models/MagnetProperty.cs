using MagnetArgs.Rules;
using System.Collections.Generic;
using System.Reflection;

namespace MagnetArgs
{
    internal class MagnetProperty : IPremise
    {
        public PropertyInfo Property { get; private set; }

        public KeyValue Input { get; private set; }

        public ArgumentAttribute Attribute { get; private set; }

        public IsRequiredAttribute IsRequiredAttribute { get; private set; }

        public IfPresentAttribute IfPresentAttribute { get; private set; }

        public DefaultAttribute DefaultAttribute { get; private set; }

        public ParserAttribute ParserAttribute { get; private set; }

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


        public MagnetProperty(
            PropertyInfo property,
            Dictionary<string, string> args
        )
        {
            Property=property;

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
            HasValue = null != Input.Value;
            IsNative = false;
            IsBoolean = Property.PropertyType == typeof(bool);
            IsTyped = false;

            IsRequired = null != IsRequiredAttribute;
            IsPresent= null != IfPresentAttribute;

            ExistNamed = false;
            NamedHasValue = false;

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
