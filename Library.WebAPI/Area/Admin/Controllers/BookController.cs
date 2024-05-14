using Library.Application.CQRS.SuggestedBooks.Queries.GetAllSuggestedBook;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Library.WebAPI.Area.Admin.Controllers
{
    [Route("admin/book")]
    [Authorize(Roles = "admin")]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-suggest")]
        public async Task<IActionResult> GetAllSuggestedBook()
        {
            var suggestedBooks = await _mediator.Send(new GetAllSuggestedBookRequest());
            if (suggestedBooks.Count() ==0 )
                return NotFound();

            return Ok(suggestedBooks);
        }
    }
}
