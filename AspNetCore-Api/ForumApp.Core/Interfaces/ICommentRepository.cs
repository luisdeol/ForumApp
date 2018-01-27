using ForumApp.Core;

namespace ForumApp.Core.Interfaces
{
    public interface ICommentRepository
    {
         void Add(Comment comment);
         int GetCount(int postId);
         void Save();
    }
}