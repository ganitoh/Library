using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("controller")]
    [Authorize]
    public class BookController : Controller
    {

        [HttpPost("suggest-adding")]
        public Task<IActionResult> SuggestAddingBookByUser()
        {

        }
    }
}
