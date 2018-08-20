using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    /// <summary>
    /// 
    /// </summary>
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
