using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebApp.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is requied!")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        [Required(ErrorMessage = "Content is requied")]
        [DisplayName("Article Content")]
        public string Content { get; set; }
        [DisplayName("Display Order")]
        [Range(1,20,ErrorMessage = "Order must be between 1 and 20")]
        public int DisplayOrder { get; set; }
        public string Author { get; set; }
    }
}
