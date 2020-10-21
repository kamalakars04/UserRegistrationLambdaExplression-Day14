using System;
using System.Runtime.Serialization;

namespace UserRegistration
{
    [Serializable]
    public class UserEntryException : Exception
    {
        public UserEntryException()
        {
        }

        public UserEntryException(string message) : base(message)
        {

        }

        public UserEntryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserEntryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}