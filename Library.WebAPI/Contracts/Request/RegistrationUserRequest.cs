using System.ComponentModel.DataAnnotations;

namespace Library.WebAPI.Contracts.Request
{
    public record class RegistrationUserRequest(
        [Required]string Login,
        [Required]string password);
}
