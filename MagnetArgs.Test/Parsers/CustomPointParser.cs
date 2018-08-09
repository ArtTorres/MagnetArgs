using MagnetArgs.Test.Models;
using System;

namespace MagnetArgs.Test.Parsers
{
    class CustomPointParser : IParser
    {
        public object Parse(string value)
        {
            var values = value.Replace("[", "").Replace("]", "").Trim().Split(',');
            if (values.Length == 2)
            {
                var obj = new CustomPoint();
                obj.X = int.Parse(values[0]);
                obj.Y = int.Parse(values[1]);

                return obj;
            }
            else
            {
                throw new Exception("Error parsing CustomPoint");
            }
        }
    }
}
