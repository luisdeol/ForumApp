using System.Threading.Tasks;
using ForumApp.Core;
using ForumApp.Tests.Builders;
using ForumApp.Tests.Helpers;
using ForumApp.Web.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Tests.Controllers
{
    public class PostsControllerTests
    {
        [Fact]
        public async Task TableWithOneRow_RequestGetPostIdOne_ReturnsPost()
        {
            using (var context = InMemoryDatabaseHelper.GetDbContext("FindController_Post_Db"))
            {
                //Arrange
                var postBuilder = new PostBuilder();
                var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);
                var postsController = new PostsController(postRepository);
                var post = postBuilder.Build();
                postRepository.Add(post);
                context.SaveChanges();

                //Act
                var apiResponse = await postsController.GetPost(1);

                //Assert
                var okResponse = apiResponse as OkObjectResult;
                Assert.NotNull(okResponse);

                var modelResponse = okResponse.Value as Post;
                Assert.NotNull(modelResponse);
                Assert.Equal(1, modelResponse.Id);
            };
        }
        
        [Fact]
        public void EmptyTable_RequestPostOnePost_CountIsOne(){
            using (var context = InMemoryDatabaseHelper.GetDbContext("AddPost_Db")){
                //Arrange
                var postBuilder = new PostBuilder();
                var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);
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
        } 
    }
}
