using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumApp.Core;
using ForumApp.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.FindAsync(id);

            return Ok(post);
        }
    }
}