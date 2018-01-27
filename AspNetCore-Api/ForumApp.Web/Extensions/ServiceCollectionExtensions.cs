using ForumApp.Core.Interfaces;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ForumApp.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ForumAppDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IPostRepository, PostRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
