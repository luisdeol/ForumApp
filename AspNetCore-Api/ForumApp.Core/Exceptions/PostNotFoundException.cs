using System;
using System.Runtime.Serialization;

namespace ForumApp.Core.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(int postId) : base($"Post {postId} not found!")
        {
        }
        public PostNotFoundException(string message) : base(message)
        {
        }

        public PostNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PostNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
