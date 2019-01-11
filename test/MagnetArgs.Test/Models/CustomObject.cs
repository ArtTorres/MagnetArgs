using MagnetArgs.Test.Parsers;

namespace MagnetArgs.Test.Models
{
    class CustomObject : MagnetOption
    {
        [Arg("custom-point", Alias = "point"), Parser(typeof(CustomPointParser))]
        public CustomPoint Point { get; set; }
    }
}
