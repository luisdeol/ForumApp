using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApp.Core.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
        Post Find(int id);
        Task<Post> FindAsync(int id);
        int GetCount();
        Task<List<Post>> FindAllAsync();
        void Save();
    }
}
