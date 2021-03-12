using MagnetArgs.Test.Parsers;

namespace MagnetArgs.Test.Models
{
    class CustomObject : IronOre
    {
        [Chunk("custom-point", Alias = "point"), Parser(typeof(CustomPointParser))]
        public CustomPoint Point { get; set; }
    }
}
