using System;
using System.Collections.Generic;

namespace MagnetArgs
{
    public interface IOption
    {
        int Order
        {
            get;
            set;
        }

        //IEnumerable<HelpAttribute> Help
        //{
        //    get;
        //    set;
        //}

        IEnumerable<Exception> Exceptions
        {
            get;
            set;
        }
    }
}
