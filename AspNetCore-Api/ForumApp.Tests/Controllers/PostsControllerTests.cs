using System;
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
        public async Task EmptyTable_AddPostUsingPostEndpoint_ReturnsCreated()
        {
            using (var context = InMemoryDatabaseHelper.GetDbContext("FindController_Post_Db"))
            {
                //Arrange
                var postBuilder = new PostBuilder();
                var postRepository = InMemoryDatabaseHelper.GetPostRepository(context);
                var postsController = new PostsController(postRepository);
                var post = postBuilder.Build();

                //Act
                postRepository.Add(post);
                context.SaveChanges();

                var apiResponse = await postsController.GetPost(1);

                //Assert
                var okResponse = apiResponse as OkObjectResult;
                Assert.NotNull(okResponse);

                var modelResponse = okResponse.Value as Post;
                Assert.NotNull(modelResponse);
            };
        } 
    }
}
