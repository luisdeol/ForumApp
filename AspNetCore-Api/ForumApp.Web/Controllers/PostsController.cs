﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumApp.Core;
using ForumApp.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading; 

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
        public async Task<IActionResult> GetAll() =>
            Ok(await _postRepository.FindAllAsync()); 

        [HttpGet("{id}", Name="GetPost")]
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