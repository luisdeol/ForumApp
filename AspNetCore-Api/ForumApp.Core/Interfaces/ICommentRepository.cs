using System.Collections.Generic;
using ForumApp.Core;
using System.Threading.Tasks;

namespace ForumApp.Core.Interfaces
{
    public interface ICommentRepository
    {
         void Add(Comment comment);
         int GetCount(int postId);
         void Save();
         Task<List<Comment>> GetCommentsAsync(int postId);
    }
}