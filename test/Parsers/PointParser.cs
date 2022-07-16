using MagnetArgs.Parsers;
using System;

namespace MagnetArgs.Test
{
    class PointParser : IParser
    {
        public object Parse(string value)
        {
            var values = value.Replace("[", "").Replace("]", "").Trim().Split(',');
            if (values.Length == 2)
            {
                var obj = new Point();
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
