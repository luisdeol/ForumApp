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

        public Post Build(string title) {
            return WithCustomTitle(title);
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

         private Post WithCustomTitle(string title)
        {
            _post = new Post
            {
                Id = _id++,
                Content = _testContent,
                CreationDate = _testCreationDate,
                Title = title
            };

            return _post;
        }
    }
}
