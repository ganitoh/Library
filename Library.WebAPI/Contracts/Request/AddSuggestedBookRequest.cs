using Microsoft.AspNetCore.SignalR.Protocol;
using System.ComponentModel.DataAnnotations;

namespace Library.WebAPI.Contracts.Request
{
    public record class AddSuggestedBookRequest(
        [Required]string NameBook,
        [Required]string AuthorLastName,
        string AuthorFirstName,
        string AuthorPatronymic);
}
