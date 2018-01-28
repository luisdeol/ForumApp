using System.Threading.Tasks;
using ForumApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ForumApp.Core;

namespace ForumApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/posts")]
    public class CommentsController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("{postId}/comments")]
        public async Task<IActionResult> GetComments(int postId){
            return Ok(await _commentRepository.GetCommentsAsync(postId));
        }

        [HttpPost("/api/comments")]
        public IActionResult PostComment([FromBody]Comment comment) {
            _commentRepository.Add(comment);
            _commentRepository.Save();

            return Ok(comment);
        }
    }
}