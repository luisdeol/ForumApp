using ForumApp.Core.Interfaces;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Tests.Helpers
{
    public class DatabaseHelper
    {
        public static IPostRepository GetPostRepository(string contextName)
        {
            var context = GetDbContext(contextName);
            return new PostRepository(context);
        }
        public static ICommentRepository GetCommentRepository(string contextName)
        {
            var context = GetDbContext(contextName);
            return new CommentRepository(context);
        }
        public static ForumAppDbContext GetDbContext(string contextName)
        {
            var options = new DbContextOptionsBuilder<ForumAppDbContext>()
                .UseInMemoryDatabase(contextName)
                .Options;

            return new ForumAppDbContext(options);
        }
    }
}
