namespace Library.Application.Common.Services.HasherProvider
{
    internal class PasswordHash : IPasswordHash
    {
        public bool VerifyPassword(string password, string passwordHash)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);

        string IPasswordHash.PasswordHash(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }
}
