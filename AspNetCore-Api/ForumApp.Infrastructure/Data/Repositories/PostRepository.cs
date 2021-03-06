﻿using System.Linq;
using System.Threading.Tasks;
using ForumApp.Core;
using ForumApp.Core.Exceptions;
using ForumApp.Core.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System;

namespace ForumApp.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumAppDbContext _context;

        public PostRepository(ForumAppDbContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            if (post == null)
                throw new PostNullException();

            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public Post Find(int id)
        {
            var post = _context.Posts.FirstOrDefault(p=> p.Id == id);

            if (post == null)
                throw new PostNotFoundException(id);

            return post;
        }

        public async Task<Post> FindAsync(int id)
        {
            var post = await _context.Posts.Include(p=> p.Comments).SingleAsync(p=> p.Id == id);

            if (post == null)
                throw new PostNotFoundException(id);

            return post;
        }

        public int GetCount()
        {
            return _context.Posts.Count();
        }

        public async Task<List<Post>> SearchByTitleAsync(string searchKeyword = "") {
            return await _context.Posts.Where(p=> p.Title.Contains(searchKeyword))
                        .ToListAsync();
        }

        public void Save(){
            _context.SaveChanges();
        }
    }
}
