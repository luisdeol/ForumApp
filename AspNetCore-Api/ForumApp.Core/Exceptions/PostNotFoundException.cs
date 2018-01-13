using System;
using System.Runtime.Serialization;

namespace ForumApp.Core.Exceptions
{
    public class PostNotFound : Exception
    {
        public PostNotFound(int postId) : base($"Post {postId} not found!")
        {
        }
        public PostNotFound(string message) : base(message)
        {
        }

        public PostNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PostNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
