namespace Services.Interfaces
{
    public interface IGetFileService
    {
        Task<byte[]> GetFileAsync(string fileName);
    }
}
