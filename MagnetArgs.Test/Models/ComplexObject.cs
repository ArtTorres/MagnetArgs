using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetArgs.Test.Models
{
    class ComplexObject : MagnetArgument
    {
        [Arg("required-value"), IsRequired]
        public string RequiredValue { get; set; }

        [Arg("present-value"), IfPresent]
        public bool PresentValue { get; set; }

        [Arg("default-value"), Default("25")]
        public int DefaultValue { get; set; }
    }
}
