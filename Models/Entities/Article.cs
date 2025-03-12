using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebApp.Models.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is requied!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is requied!")]
        [DisplayName("Article Content")]
        public string Content { get; set; }
        [DisplayName("Is this a High Priority Article?")]
        public bool IsPriority { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [DisplayName("Image URL (leave empty if there is no image)")]
        public string? ImageLink { get; set; }
        [DisplayName("Image Description")]
        public string? ImageDescription { get; set; }
    }
}
