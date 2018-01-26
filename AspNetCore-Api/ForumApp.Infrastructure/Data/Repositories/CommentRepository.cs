using ForumApp.Core.Interfaces;
using ForumApp.Core;

namespace ForumApp.Infrastructure.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumAppDbContext context;
        public CommentRepository(ForumAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Comment comment) {

        }

        public int GetCount() {
            return 1;
        }
    }
}