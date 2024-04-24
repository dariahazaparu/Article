using System.ComponentModel.DataAnnotations;
using static Article.Web.Utility.Validations;

namespace Article.Web.Models
{
    public class ArticleUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [NotFutureDate]
        public DateTime PublishedDate { get; set; }
    }
}
