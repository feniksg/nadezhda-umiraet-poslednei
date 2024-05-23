namespace SiteAPI.Models
{
    public class CustomUser
    {
        public int Id { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public int AccessLevel { get; set; }
    }
}
