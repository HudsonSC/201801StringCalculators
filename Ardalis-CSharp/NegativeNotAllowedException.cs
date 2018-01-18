using System;

namespace StringCalcKata
{
    internal class NegativeNotAllowedException : Exception
    {
        public NegativeNotAllowedException() : base()
        {
        }

        public NegativeNotAllowedException(string message) : base(message)
        {
        }

        public NegativeNotAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeNotAllowedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}