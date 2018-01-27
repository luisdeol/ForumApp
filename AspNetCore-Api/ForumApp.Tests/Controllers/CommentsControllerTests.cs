using ForumApp.Web.Controllers;
using System.Threading.Tasks;
using Xunit;
using ForumApp.Tests.Helpers;
using ForumApp.Tests.Builders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ForumApp.Core;

namespace ForumApp.Tests.Controllers
{
    public class CommentsControllerTests
    {
        [Fact]
        public async Task PostWithOneComment_GetPostComments_ReturnOne(){
            //Assert
            var commentRepository = DatabaseHelper.GetCommentRepository("Get_Comment_Controller");
            var commentController = new CommentsController(commentRepository);
            var postBuilder = new PostBuilder();
            var commentBuilder = new CommentBuilder();
            var post = postBuilder.Build();
            var comment = commentBuilder.Build();
            comment.PostId = post.Id;

            //Act
            commentRepository.Add(comment);
            commentRepository.Save();

            //Assert
            var apiResponse = await commentController.GetComments(post.Id);

            var okResponse = apiResponse as OkObjectResult;
            Assert.NotNull(okResponse);

            var objectResponse = okResponse.Value as List<Comment>;
            Assert.Single(objectResponse);
        }

        [Fact]
        public void PostWithZeroComment_AddPostComment_PostCommentCountReturnOne(){
            //Assert
            var commentRepository = DatabaseHelper.GetCommentRepository("Add_Comment_Controller");
            var commentController = new CommentsController(commentRepository);
            var postBuilder = new PostBuilder();
            var commentBuilder = new CommentBuilder();
            var post = postBuilder.Build();
            var comment = commentBuilder.Build();
            comment.PostId = post.Id;

            //Act
            var apiResponse = commentController.PostComment(comment);

            //Assert

            var okResponse = apiResponse as OkObjectResult;
            Assert.NotNull(okResponse);

            Assert.Equal(1, commentRepository.GetCount(post.Id));
        }
    }
}