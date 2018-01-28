using System;
using ForumApp.Core;

namespace ForumApp.Web.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public PostDto(Post post)
        {
            Id = post.Id;
            Title = post.Title;   
            CreationDate = post.CreationDate;
        }
    }
}