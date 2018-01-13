using System.Threading.Tasks;

namespace ForumApp.Core.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
        Post Find(int id);
        Task<Post> FindAsync(int id);
        int GetCount();
    }
}
