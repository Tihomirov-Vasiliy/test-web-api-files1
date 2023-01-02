namespace Application.Interfaces
{
    public interface IFileGetter
    {
        Stream GetStream(string filePath);
    }
}
