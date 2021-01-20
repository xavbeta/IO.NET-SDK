using System;
using System.Runtime.Serialization;

namespace IO_API_SDK.Messages
{
    [Serializable]
    public class IOMessageFormatException : Exception
    {
        public IOMessageFormatException()
        {
        }

        public IOMessageFormatException(string message) : base(message)
        {
        }

        public IOMessageFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IOMessageFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}