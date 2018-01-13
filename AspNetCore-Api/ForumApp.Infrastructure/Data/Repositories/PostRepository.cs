using System.Linq;
using ForumApp.Core;
using ForumApp.Core.Exceptions;
using ForumApp.Core.Interfaces;

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
                throw new AddPostException();

            _context.Posts.Add(post);
        }

        public Post Find(int id)
        {
            var post = _context.Posts.FirstOrDefault(p=> p.Id == id);

            if (post == null)
                throw new FindPostException(id);

            return post;
        }
    }
}
