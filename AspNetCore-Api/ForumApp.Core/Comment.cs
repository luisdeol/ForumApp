using System;

namespace ForumApp.Core
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}