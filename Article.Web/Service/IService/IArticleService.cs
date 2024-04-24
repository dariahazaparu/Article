using Article.Web.Models;

namespace Article.Web.Service.IService
{
    public interface IArticleService
    {
        Task<ResponseDTO?> GetArticleAsync(int id);
        Task<ResponseDTO?> GetAllArticlesAsync();
        Task<ResponseDTO?> CreateArticleAsync(ArticleCreateDTO article);
        Task<ResponseDTO?> UpdateArticleAsync(int id, ArticleUpdateDTO article);
        Task<ResponseDTO?> DeleteArticleAsync(int id);
    }
}
