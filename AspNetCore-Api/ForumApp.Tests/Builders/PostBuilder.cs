using System;
using System.Collections.Generic;
using System.Text;
using ForumApp.Core;

namespace ForumApp.Tests.Builders
{
    public class PostBuilder
    {
        private Post _post;
        private readonly string _testContent = "Test Content";
        private readonly DateTime _testCreationDate = DateTime.Now;
        private int _id = 1;

        public Post Build()
        {
            return WithDefaultValues();
        }

        private Post WithDefaultValues()
        {
            _post = new Post
            {
                Id = _id++,
                Content = _testContent,
                CreationDate = _testCreationDate
            };

            return _post;
        }
    }
}
