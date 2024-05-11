namespace Library.WebAPI.Contracts.Response
{
    public class UserDataResponse
    {
        public string Login { get; set; } = string.Empty;
        public UserDataResponse() { }

        public UserDataResponse(string login)
        {
            Login = login;
        }
    }
}
