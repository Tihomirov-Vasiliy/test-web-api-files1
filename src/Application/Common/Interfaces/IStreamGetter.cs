namespace Application.Common.Interfaces
{
    public interface IFileStreamGetter
    {
        FileStream Get(string filePath);
    }
}
