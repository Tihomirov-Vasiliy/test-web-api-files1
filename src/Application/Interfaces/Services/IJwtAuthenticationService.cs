namespace Application.Interfaces.Services
{
    public interface IJwtAuthorizationService
    {
        string Authorize(string login, string password);
    }
}
