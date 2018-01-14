using System;
using System.Runtime.Serialization;

namespace ForumApp.Core.Exceptions
{
    public class PostNullException : Exception
    {
        public PostNullException() : base("Post is null!")
        {
        }
        public PostNullException(string message) : base(message)
        {
        }

        public PostNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PostNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
