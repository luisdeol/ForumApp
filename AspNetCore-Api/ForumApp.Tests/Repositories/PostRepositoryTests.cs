using System;
using ForumApp.Core;
using ForumApp.Core.Exceptions;
using ForumApp.Tests.Builders;
using ForumApp.Tests.Helpers;
using Xunit;
using System.Threading.Tasks;

namespace ForumApp.Tests.Repositories
{
    public class PostRepositoryTests
    {
        [Fact]
        public void EmptyTable_AddPost_CountIsOne()
        {
            //Arrange
            var postRepository = DatabaseHelper.GetPostRepository("Add_Post_Db");
            var postBuilder = new PostBuilder();
            var post = postBuilder.Build();

            //Act
            postRepository.Add(post);
            postRepository.Save();

            //Assert
            Assert.Equal(1, postRepository.GetCount());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TableWithThreePosts_FindForId_ReturnThePostWithId(int postId)
        {  
            //Arrange
            var postRepository = DatabaseHelper.GetPostRepository("Find_Post_Db");

            //Act
            postRepository.Add(new Post
            {
                Id = postId,
                Content = $"Hi, Post nº {postId}",
                CreationDate = DateTime.Now.AddDays(postId)
            });

            postRepository.Save();

            //Assert
            var post = postRepository.Find(postId);
            Assert.NotNull(post);
            Assert.Equal(postId, post.Id);
        }

        [Fact]
        public void EmptyTable_AddNullPost_ThrowPostNullException()
        {
            //Arrange
            var postRepository = DatabaseHelper.GetPostRepository("Add_NullPost_Db");

            //Act + Assert
            Assert.Throws<PostNullException>(() => postRepository.Add(null));
        }

        [Fact]
        public async Task TableWithThreePosts_FindAll_ReturnsThreePosts()
        {
            //Arrange
            var postBuilder = new PostBuilder();
            var postRepository = DatabaseHelper.GetPostRepository("FindAll_Db");

            postRepository.Add(postBuilder.Build());
            postRepository.Add(postBuilder.Build());
            postRepository.Add(postBuilder.Build());

            postRepository.Save();

            //Act
            var posts = await postRepository.FindAllAsync();

            //Assert
            Assert.NotNull(posts);
            Assert.Equal(3, posts.Count);
        }

        [Fact]
        public async Task ThreePostsOneWithOrangeInTitle_SearchForOrange_ShouldReturnOne() {
            //Arrange
            var postBuilder = new PostBuilder();
            var postRepository = DatabaseHelper.GetPostRepository("Search_Keyword_Db");

            postRepository.Add(postBuilder.Build("Harry Potter"));
            postRepository.Add(postBuilder.Build("Lord of the rings"));
            postRepository.Add(postBuilder.Build("A Clockwork Orange"));
            postRepository.Save();

            //Act
            var searchResults  = await postRepository.SearchByTitleAsync("Orange");


            //Assert
            Assert.NotNull(searchResults);
            Assert.Single(searchResults);
        }
    }
}
