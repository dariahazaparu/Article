using System.ComponentModel.DataAnnotations;

namespace Article.Services.API.Models
{
    public class ArticleEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }

}
