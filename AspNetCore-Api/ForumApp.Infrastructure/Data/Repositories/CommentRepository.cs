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
            _context.Comments.Add(comment);
        }

        public int GetCount() {
            return _context.Comments.Count();
        }
    }
}