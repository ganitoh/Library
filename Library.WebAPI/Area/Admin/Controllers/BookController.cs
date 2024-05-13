using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Library.WebAPI.Area.Admin.Controllers
{
    [Route("admin/book")]
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
            return Ok();
        }
    }
}
