using System;

namespace MagnetArgs
{
    public class IfPresentException : MagnetException
    {
        public IfPresentException()
        {
        }

        public IfPresentException(string message)
            : base(message)
        {
        }

        public IfPresentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
