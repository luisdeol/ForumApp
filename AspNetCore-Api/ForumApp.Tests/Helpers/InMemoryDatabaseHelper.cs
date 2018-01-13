using ForumApp.Core.Interfaces;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Tests.Helpers
{
    public class InMemoryDatabaseHelper
    {
        public static IPostRepository GetPostRepository(ForumAppDbContext context)
        {
            return new PostRepository(context);
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
