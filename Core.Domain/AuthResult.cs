namespace Core.Domain
{
    public class AuthResult
    {
        public string Token { get; set; }

        public bool Successful { get; set; }

        public string ErrorMessage { get; set; }
    }
}