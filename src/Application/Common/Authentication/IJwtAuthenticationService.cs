namespace Application.Common.Authentication
{
    public interface IJwtAuthorizationService
    {
        /// <summary>
        /// Method to authorize users
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>Valid authorization token</returns>
        string Authorize(string login, string password);
    }
}
