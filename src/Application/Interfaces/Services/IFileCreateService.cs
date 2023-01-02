namespace Application.Interfaces.Services
{
    public interface IFileCreateService
    {
        Task<string> CreateFileAsync(string content);
    }
}
