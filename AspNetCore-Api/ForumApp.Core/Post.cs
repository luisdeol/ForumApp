using System;
using System.Collections;
using System.Collections.Generic;

namespace ForumApp.Core
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public ICollection<Comment> Comments { get; set; }
    }
}
