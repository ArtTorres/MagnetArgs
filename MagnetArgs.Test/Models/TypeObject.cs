
namespace MagnetArgs.Test.Models
{
    class TypeObject : MagnetArgument
    {
        [Arg("string-value", Alias = "string")]
        public string StringValue { get; set; }

        [Arg("char-value", Alias = "char")]
        public char CharValue { get; set; }

        [Arg("integer-value", Alias = "int")]
        public int IntegerValue { get; set; }

        [Arg("long-value", Alias = "long")]
        public long LongValue { get; set; }

        [Arg("boolean-value", Alias = "bool")]
        public bool BooleanValue { get; set; }

        [Arg("float-value", Alias = "float")]
        public float FloatValue { get; set; }

        [Arg("double-value", Alias = "double")]
        public double DoubleValue { get; set; }

        [Arg("decimal-value", Alias = "decimal")]
        public decimal DecimalValue { get; set; }
    }
}
