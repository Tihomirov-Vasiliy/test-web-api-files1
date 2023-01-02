namespace Application.Interfaces
{
    public interface IFileGetter
    {
        FileStream GetStream(string filePath);
    }
}
