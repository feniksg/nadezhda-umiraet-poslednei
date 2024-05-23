namespace TheMuseum.Autotification.Services;

public interface IAutetificationService
{
    bool Authenticate(string username, string password);
}

public class AuthenticationService : IAutetificationService
{
    private const string CorrectUsernameForUser = "user";
    private const string CorrectPasswordForUser = "user";
    private const string CorrectUsernameForAdmin = "admin";
    private const string CorrectPasswordForAdmin = "admin";

    public bool Authenticate(string username, string password)
    {
        return (username == CorrectUsernameForUser && password == CorrectPasswordForUser) || (username == CorrectUsernameForAdmin && password == CorrectPasswordForAdmin);
    }
}
