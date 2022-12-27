using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class FileContentDto
    {
        [Required]
        public string Text { get; set; } = string.Empty;
    }
}
