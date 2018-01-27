using ForumApp.Core.Interfaces;
using ForumApp.Core;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Infrastructure.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumAppDbContext _context;
        public CommentRepository(ForumAppDbContext context)
        {
            _context = context;
        }

        public void Add(Comment comment) {
            _context.Comments.Add(comment);
        }

        public int GetCount(int postId) {
            return _context.Comments.Count(c=> c.PostId == postId);
        }
        
        public async Task<List<Comment>> GetCommentsAsync(int postId) {
            return await _context.Comments.Where(c=> c.PostId == postId).ToListAsync();
        }
        public void Save() {
            _context.SaveChanges();
        }
    }
}