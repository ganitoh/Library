using FluentValidation;
using Library.Application.Common.Services.HasherProvider;
using Library.Application.CQRS;
using Library.Application.CQRS.Authors.Commands.CreateAuthor;
using Library.Application.CQRS.Books.Commands.CreateBook;
using Library.Application.CQRS.Users.Commands.CreateUser;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Application
{
    public static class DIExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddAutoMapper(typeof(CQRSMapperProfile));

            services.AddScoped<IValidator<CreateUserCommand>,CreateUserCommandValidation>();
            services.AddScoped<IValidator<CreateBookCommand>,CreateBookCommandValidation>();
            services.AddScoped<IValidator<CreateAuthorCommand>,CreateAuthorCommandValidation>();

            services.AddScoped<IPasswordHash,PasswordHash>();
        }
    }
}
