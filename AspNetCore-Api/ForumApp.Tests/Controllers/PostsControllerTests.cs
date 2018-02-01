using System.Threading.Tasks;
using ForumApp.Core;
using ForumApp.Tests.Builders;
using ForumApp.Tests.Helpers;
using ForumApp.Web.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ForumApp.Web.Dtos;

namespace ForumApp.Tests.Controllers
{
    public class PostsControllerTests
    {
        [Fact]
        public async Task TableWithOneRow_RequestGetPostIdOne_ReturnsOkWithPost()
        {
            //Arrange
            var postBuilder = new PostBuilder();
            var postRepository = DatabaseHelper.GetPostRepository("FindController_Post_Db");
            var postsController = new PostsController(postRepository);
            var post = postBuilder.Build();
            postRepository.Add(post);
            postRepository.Save();

            //Act
            var apiResponse = await postsController.GetPost(1);

            //Assert
            var okResponse = apiResponse as OkObjectResult;
            Assert.NotNull(okResponse);

            var modelResponse = okResponse.Value as Post;
            Assert.NotNull(modelResponse);
            Assert.Equal(1, modelResponse.Id);
        }
        
        [Fact]
        public void EmptyTable_RequestPostOnePost_CreatedPostAndLocationAreReturned(){
            //Arrange
            var postBuilder = new PostBuilder();
            var postRepository = DatabaseHelper.GetPostRepository("AddPost_Db");
            var postsController = new PostsController(postRepository);
            var post = postBuilder.Build();
            
            //Act
            var apiResponse = postsController.AddPost(post);

            //Assert
            var createdAtResponse = apiResponse as CreatedAtRouteResult;
            Assert.NotNull(createdAtResponse);
            Assert.Equal("GetPost", createdAtResponse.RouteName);
            Assert.True(createdAtResponse.RouteValues.ContainsKey("id"));

            var postCreated = createdAtResponse.Value as Post;
            Assert.NotNull(postCreated);
            Assert.Equal("Test Content", postCreated.Content);
        }

        [Fact]
        public async Task TableWithThreePosts_RequestGetAll_ReturnsOkWithThreePosts(){
            //Arrange
            var postBuilder = new PostBuilder();
            var postRepository = DatabaseHelper.GetPostRepository("GetAll_Db");
            var postsController = new PostsController(postRepository);

            postRepository.Add(postBuilder.Build());
            postRepository.Add(postBuilder.Build());
            postRepository.Add(postBuilder.Build());
            postRepository.Save();

            //Act
            var apiResponse = await postsController.GetAll();

            //Assert
            var okResponse = apiResponse as OkObjectResult;
            Assert.NotNull(okResponse);

            var postList = okResponse.Value as List<PostDto>;
            Assert.NotNull(postList);
        }

        [Fact]
        public async Task ThreePostsOneWithOrangeInTitle_SearchForOrange_ShouldReturnOne() {
            //Arrange
            var postRepository = DatabaseHelper.GetPostRepository("Search_Post_Controller");
            var postBuilder = new PostBuilder();
            var postController = new PostsController(postRepository);
            postRepository.Add(postBuilder.Build("Harry Potter"));
            postRepository.Add(postBuilder.Build("Lord of the rings"));
            postRepository.Add(postBuilder.Build("A Clockwork Orange"));
            postRepository.Save();

            //Act
            var apiResponse = await postController.GetAll("Orange");
            var okResponse = apiResponse as OkObjectResult;
            var postList = okResponse.Value as List<PostDto>;
            
            //Assert
            Assert.NotNull(okResponse);
            Assert.NotNull(postList);
            Assert.Single(postList);
        }
    }
}
