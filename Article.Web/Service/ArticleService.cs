using Article.Web.Models;
using Article.Web.Service.IService;
using Article.Web.Utility;

namespace Article.Web.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IBaseService baseService;
        public ArticleService(IBaseService baseService)
        {
            this.baseService = baseService;            
        }
        public async Task<ResponseDTO?> CreateArticleAsync(ArticleCreateDTO article)
        {
            return await baseService.SendAsync(new RequestDTO()
            {
                ApiType = Utility.Types.ApiType.POST,
                Data = article,
                Url = Types.ArticleAPIBase + "/api/articles"
            });
        }

        public async Task<ResponseDTO?> DeleteArticleAsync(int id)
        {
            return await baseService.SendAsync(new RequestDTO()
            {
                ApiType = Utility.Types.ApiType.DELETE,
                Url = Types.ArticleAPIBase + "/api/articles/" + id
            });
        }

        public async Task<ResponseDTO?> GetAllArticlesAsync()
        {
            return await baseService.SendAsync(new RequestDTO()
            {
                ApiType = Utility.Types.ApiType.GET,
                Url = Types.ArticleAPIBase + "/api/articles"
            });
        }

        public async Task<ResponseDTO?> GetArticleAsync(int id)
        {
            return await baseService.SendAsync(new RequestDTO()
            {
                ApiType = Utility.Types.ApiType.GET,
                Url = Types.ArticleAPIBase + "/api/articles/" + id
            });
        }

        public async Task<ResponseDTO?> UpdateArticleAsync(int id, ArticleUpdateDTO article)
        {
            return await baseService.SendAsync(new RequestDTO()
            {
                ApiType = Utility.Types.ApiType.PUT,
                Data = article,
                Url = Types.ArticleAPIBase + "/api/articles/" + id
            });
        }
    }
}
