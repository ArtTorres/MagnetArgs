using System;

namespace MagnetArgs
{
    public class MagnetException : Exception
    {
        public MagnetException()
        {
        }

        public MagnetException(string message)
            : base(message)
        {
        }

        public MagnetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
