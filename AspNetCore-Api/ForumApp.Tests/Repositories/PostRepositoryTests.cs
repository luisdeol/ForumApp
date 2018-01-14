using System;
using ForumApp.Core;
using ForumApp.Core.Exceptions;
using ForumApp.Tests.Builders;
using ForumApp.Tests.Helpers;
using Xunit;

namespace ForumApp.Tests.Repositories
{
    public class PostRepositoryTests
    {
        [Fact]
        public void EmptyTable_AddPost_CountIsOne()
        {
            using (var context = InMemoryDatabaseHelper.GetDbContext("Add_Post_Db"))
            {
                //Arrange
                var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);
                var postBuilder = new PostBuilder();
                var post = postBuilder.Build();

                //Act
                postRepository.Add(post);

                context.SaveChanges();

                //Assert
                Assert.Equal(1, postRepository.GetCount());
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TableWithThreeItems_FindForId_ReturnThePostWithId(int postId)
        {  
            using (var context = InMemoryDatabaseHelper.GetDbContext("Find_Post_Db"))
            {
                //Arrange
                var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);

                //Act
                postRepository.Add(new Post
                {
                    Id = postId,
                    Content = $"Hi, Post nº {postId}",
                    CreationDate = DateTime.Now.AddDays(postId)
                });

                context.SaveChanges();

                //Assert
                var post = postRepository.Find(postId);
                Assert.NotNull(post);
                Assert.Equal(postId, post.Id);
            }  
        }

        [Fact]
        public void EmptyTable_AddNullPost_ThrowPostNullException()
        {
            using (var context = InMemoryDatabaseHelper.GetDbContext("Add_NullPost_Db"))
            {
                //Arrange
                var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);

                //Act + Assert
                Assert.Throws<PostNullException>(() => postRepository.Add(null));
            }
        }
    }
}
