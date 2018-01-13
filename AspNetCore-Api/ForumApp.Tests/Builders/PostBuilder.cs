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

        public PostBuilder()
        {
            _post = WithDefaultValues();
        }

        public Post Build()
        {
            return _post;
        }

        private Post WithDefaultValues()
        {
            _post = new Post
            {
                Id = 1,
                Content = _testContent,
                CreationDate = _testCreationDate
            };
            return _post;
        }
    }
}
