using System.Linq;
using System.Threading.Tasks;
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
                throw new PostNotFound(id);

            return post;
        }

        public async Task<Post> FindAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                throw new PostNotFound(id);

            return post;
        }

        public int GetCount()
        {
            return _context.Posts.Count();
        }
    }
}
