using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumApp.Core;
using ForumApp.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using ForumApp.Web.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace ForumApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/posts")]
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        [Authorize(Policy = "AdminUser")]
        public async Task<IActionResult> GetAll(string title = "") {
            if (title == null)
                title = "";
                
            var posts = await _postRepository.SearchByTitleAsync(title); 
            var postDtos = posts.Select(post=> new PostDto(post)).ToList();

            return Ok(postDtos);
        }

        [HttpGet("{id}", Name="GetPost")]
        [Authorize(Policy = "ForumUser")]
        public async Task<IActionResult> GetPost(int id) =>
            Ok(await _postRepository.FindAsync(id));

        [HttpPost]
        public IActionResult AddPost ([FromBody] Post post){
            _postRepository.Add(post);

            return CreatedAtRoute("GetPost", 
                                    new { id = post.Id }, 
                                    post);
        }
    }
}