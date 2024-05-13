using Library.Application.CQRS.SuggestedBooks.Command.CreateSuggestedBook;
using Library.WebAPI.Contracts.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.WebAPI.Controllers
{
    [Route("controller")]
    [Authorize]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("suggest-adding")]
        public async Task<IActionResult> SuggestAddingBookByUser([FromBody] AddSuggestedBookRequest request)
        {
            var userId = User.FindFirstValue("id");

            var command = new CreateSuggestedBookComamnd()
            {
                NameBook = request.NameBook,
                AuthoData = new Domain.Models.FIO(request.AuthorFirstName, request.AuthorLastName, request.AuthorPatronymic),
                SuggestByUserid = Guid.Parse(userId!),
            };

            await _mediator.Send(command);
            return Ok();
        }
    }
}
