namespace TheMuseum.Autotification.Services;

public interface IAutetificationService
{
    bool Authenticate(string username, string password);
}

public class AuthenticationService : IAutetificationService
{
    private const string CorrectUsername = "user";
    private const string CorrectPassword = "admin";

    public bool Authenticate(string username, string password)
    {
        return username == CorrectUsername && password == CorrectPassword;
    }
}
