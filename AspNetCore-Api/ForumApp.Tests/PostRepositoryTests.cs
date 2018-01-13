using System;
using ForumApp.Core;
using ForumApp.Core.Exceptions;
using ForumApp.Tests.Helpers;
using Xunit;

namespace ForumApp.Tests
{
    public class PostRepositoryTests
    {
        [Fact]
        public void EmptyTable_AddPost_CountIsOne()
        {
            var context = InMemoryDatabaseHelper.GetDbContext("Add_Post_Db");
            var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);

            var post = new Post
            {
                Content = "Hi, Post nº 1",
                CreationDate = DateTime.Now
            };

            postRepository.Add(post);

            context.SaveChanges();

            Assert.Equal(1, post.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TableWithThreeItems_FindForId_ReturnThePostWithId(int postId)
        {
            var context = InMemoryDatabaseHelper.GetDbContext("Find_Post_Db");
            var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);
            postRepository.Add(new Post
            {
                Id = postId,
                Content = $"Hi, Post nº {postId}",
                CreationDate = DateTime.Now.AddDays(postId)
            });
            context.SaveChanges();

            var post = postRepository.Find(postId);

            Assert.NotNull(post);
            Assert.Equal(postId, post.Id);
        }

        [Fact]
        public void EmptyTable_AddNullPost_ThrowPostNullException()
        {
            var context = InMemoryDatabaseHelper.GetDbContext("Add_NullPost_Db");
            var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);

            Assert.Throws<AddPostException>(() => postRepository.Add(null));
        }
    }
}
