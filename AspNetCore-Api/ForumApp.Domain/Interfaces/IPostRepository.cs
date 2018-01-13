using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApp.Core.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
        Post Find(int id);
    }
}
