namespace Application.Interfaces.Services
{
    public interface IFileGetService
    {
        Stream GetStreamOfFile(string fileName);
    }
}
