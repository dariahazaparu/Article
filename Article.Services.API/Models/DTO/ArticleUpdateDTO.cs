namespace Article.Services.API.Models.DTO
{
    public class ArticleUpdateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
