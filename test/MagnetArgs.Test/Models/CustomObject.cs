using MagnetArgs.Test.Parsers;

namespace MagnetArgs.Test.Models
{
    class CustomObject : MagnetSet
    {
        [Arg("custom-point", Alias = "point"), Parser(typeof(CustomPointParser))]
        public CustomPoint Point { get; set; }
    }
}
