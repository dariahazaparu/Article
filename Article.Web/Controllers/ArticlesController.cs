using Article.Web.Models;
using Article.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Article.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;
        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;            
        }

        public async Task<IActionResult> Index()
        {
            List<ArticleDTO> articles = new();

            ResponseDTO? response = await articleService.GetAllArticlesAsync();

            if(response != null && response.IsSuccess) { 
                articles = JsonConvert.DeserializeObject<List<ArticleDTO>>(Convert.ToString(response.Result));
            }

            return View(articles);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleCreateDTO article)
        {
            if(ModelState.IsValid)
            {

                ResponseDTO? response = await articleService.CreateArticleAsync(article);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(article);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDTO? response = await articleService.GetArticleAsync(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<ArticleDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ArticleDTO article)
        {
            ResponseDTO? response = await articleService.DeleteArticleAsync(article.Id);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }
        public async Task<IActionResult> Update(int id)
        {
            ResponseDTO? response = await articleService.GetArticleAsync(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<ArticleUpdateDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDTO article)
        {
            if(ModelState.IsValid) 
            {
                ResponseDTO? response = await articleService.UpdateArticleAsync(article.Id, article);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(article);
        }
    }
}
