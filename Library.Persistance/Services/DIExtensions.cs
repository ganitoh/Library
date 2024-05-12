using Library.Persistance.Services.Repositories.Abstraction;
using Library.Persistance.Services.Repositories.Emplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistance.Services
{
    public static class DIExtensions
    {

        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ISuggestedBookRepository, SuggestedBookRepository>();
        }

        public static void AddPostgreSql(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseNpgsql(connectionString));
        }
    }
}
