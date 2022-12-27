namespace Application.Common.Interfaces
{
    public interface IFileContentGetter
    {
        Task<byte[]> GetBytesOfFileAsync(string filePath);
    }
}
