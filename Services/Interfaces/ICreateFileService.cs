namespace Services.Interfaces
{
    public interface ICreateFileService
    {
        Task<string> CreateFileAsync(string content);
    }
}
