namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token {  get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
