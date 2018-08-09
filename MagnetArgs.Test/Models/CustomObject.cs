
namespace MagnetArgs.Test.Models
{
    class CustomObject : MagnetArgument
    {
        [Arg("custom-point", Alias = "point"), Parser(typeof(CustomPoint))]
        public CustomPoint Point { get; set; }
    }
}
