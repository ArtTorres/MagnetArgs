using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    public class MagnetOption : IOption
    {
        public int Order
        {
            get;
            set;
        } = 0;

        public IEnumerable<Exception> Exceptions
        {
            get;
            set;
        } = new List<Exception>();
    }
}
