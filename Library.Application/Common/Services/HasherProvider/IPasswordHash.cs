namespace Library.Application.Common.Services.HasherProvider
{
    public interface IPasswordHash
    {
        string PasswordHash(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
