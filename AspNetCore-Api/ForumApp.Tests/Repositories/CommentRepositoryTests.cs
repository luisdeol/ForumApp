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
            using (var context = InMemoryDatabaseHelper.GetDbContext("Add_Post_Db"))
            {
                var commentRepository = InMemoryDatabaseHelper.GetCommentRepository(context);
                var commentBuilder = new CommentBuilder();
                var comment = commentBuilder.Build();

                commentRepository.Add(comment);
                context.SaveChanges();

                Assert.Equal(1, commentRepository.GetCount());
            } 
        }
    }
}