using System;
using ForumApp.Core;
using ForumApp.Core.Interfaces;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ForumApp.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ForumAppDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddIdentity(this IServiceCollection services, string connectionString)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ForumAppDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
        }
    }
}
