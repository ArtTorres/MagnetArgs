
namespace MagnetArgs.Test.Models
{
    class CustomObject : MagnetOption
    {
        [Arg("custom-point", Alias = "point"), Parser(typeof(CustomPoint))]
        public CustomPoint Point { get; set; }
    }
}
