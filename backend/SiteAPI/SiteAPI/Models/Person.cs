namespace SiteAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public required string Gender { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public string? Information { get; set; }
    }
}
