namespace Services.Interfaces
{
    public interface IGetFileService
    {
        FileStream GetStreamOfFile(string fileName);
    }
}
