namespace Infrastructure.Options
{
    public class DirectoryOptions
    {
        public const string Directory = "WorkingDirectory";
        public string Location { get; set; } = string.Empty;
        public DirectoryOptions()
        {

        }
    }
}