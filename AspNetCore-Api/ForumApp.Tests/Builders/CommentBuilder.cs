using ForumApp.Core;

namespace ForumApp.Tests.Builders
{
    public class CommentBuilder
    {
        public Comment Build() {
            return new Comment {
                Content = "A default comment"
            };
        }
    }
}