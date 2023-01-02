namespace Application.Interfaces.Services
{
    public interface IFileGetService
    {
        FileStream GetStreamOfFile(string fileName);
    }
}
