using AutoMapper;
using Library.Application.CQRS.Authors.Commands.CreateAuthor;
using Library.Application.CQRS.Books.Commands.CreateBook;
using Library.Application.CQRS.Users.Commands.CreateUser;
using Library.Domain.Models;

namespace Library.Application.CQRS
{
    public class CQRSMapperProfile : Profile
    {
        public CQRSMapperProfile()
        {
            //Create command
            CreateMap<CreateBookCommand, Book>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateAuthorCommand, Author>();
        }
    }
}
