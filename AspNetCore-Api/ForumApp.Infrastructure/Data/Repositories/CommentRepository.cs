using ForumApp.Core.Interfaces;
using ForumApp.Core;
using System.Linq;

namespace ForumApp.Infrastructure.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumAppDbContext _context;
        public CommentRepository(ForumAppDbContext context)
        {
            _context = context;
        }

        public void Add(Comment comment, int postId) {
            comment.PostId = postId;
            _context.Comments.Add(comment);
        }

        public int GetCount(int postId) {
            return _context.Comments.Count(c=> c.PostId == postId);
        }
    }
}