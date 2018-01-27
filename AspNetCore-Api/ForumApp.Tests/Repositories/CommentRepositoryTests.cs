using Xunit;
using ForumApp.Tests.Builders;
using ForumApp.Core;
using ForumApp.Tests.Helpers;

namespace ForumApp.Tests.Repositories
{
    public class CommentRepositoryTests
    {
        [Fact]
        public void PostWithNoComments_AddComment_CountIsOne(){
            //Arrange
            var commentRepository = DatabaseHelper.GetCommentRepository("Add_Post_Db");
            var commentBuilder = new CommentBuilder();
            var postBuilder = new PostBuilder();
            var post = postBuilder.Build();
            var comment = commentBuilder.Build();
            comment.PostId = post.Id;

            //Act
            commentRepository.Add(comment);
            commentRepository.Save();

            //Assert
            Assert.Equal(1, commentRepository.GetCount(post.Id));
        }
    }
}