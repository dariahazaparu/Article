using System.ComponentModel.DataAnnotations;

namespace Article.Web.Models
{
    public class ArticleCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Content { get; set; }
    }
}
