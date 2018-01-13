using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApp.Core
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
