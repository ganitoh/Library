using System.ComponentModel.DataAnnotations;

namespace Library.WebAPI.Contracts.Request
{
    public record class LoginUserRequest(
        [Required] string Login,
        [Required] string password);
}
