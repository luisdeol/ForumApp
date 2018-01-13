﻿using System;
using System.Runtime.Serialization;

namespace ForumApp.Core.Exceptions
{
    public class AddPostException : Exception
    {
        public AddPostException() : base("Post is null!")
        {
        }
        public AddPostException(string message) : base(message)
        {
        }

        public AddPostException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AddPostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}