namespace Library.Application.Common.Exceptions
{
    public class PasswordUncorrectException : Exception
    {
        public string UserLogin { get; private set; } = string.Empty;

        public PasswordUncorrectException(string message, string userLogin) 
            : base (message)
        {
            UserLogin = userLogin;
        }

        public PasswordUncorrectException(string message) 
            : base(message) { }
    }
}
