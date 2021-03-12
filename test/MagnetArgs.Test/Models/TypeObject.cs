
namespace MagnetArgs.Test.Models
{
    class TypeObject : IronOre
    {
        [Chunk("string-value", Alias = "string")]
        public string StringValue { get; set; }

        [Chunk("char-value", Alias = "char")]
        public char CharValue { get; set; }

        [Chunk("integer-value", Alias = "int")]
        public int IntegerValue { get; set; }

        [Chunk("long-value", Alias = "long")]
        public long LongValue { get; set; }

        [Chunk("boolean-value", Alias = "bool")]
        public bool BooleanValue { get; set; }

        [Chunk("float-value", Alias = "float")]
        public float FloatValue { get; set; }

        [Chunk("double-value", Alias = "double")]
        public double DoubleValue { get; set; }

        [Chunk("decimal-value", Alias = "decimal")]
        public decimal DecimalValue { get; set; }
    }
}
