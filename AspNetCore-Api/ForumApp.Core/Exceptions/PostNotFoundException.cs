using System;
using System.Runtime.Serialization;

namespace ForumApp.Core.Exceptions
{
    public class FindPostException : Exception
    {
        public FindPostException(int postId) : base($"Post {postId} not found!")
        {
        }
        public FindPostException(string message) : base(message)
        {
        }

        public FindPostException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FindPostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
