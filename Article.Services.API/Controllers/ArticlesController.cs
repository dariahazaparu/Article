using Article.Services.API.Data;
using Article.Services.API.Models;
using Article.Services.API.Models.DTO;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Article.Services.API.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;

        public ArticlesController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDTO = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDTO Get([FromQuery] GetArticlesQuery query) 
        { 
            try
            {
                var articles = _db.Articles.AsQueryable();
                articles = articles.Skip((query.PageNumber - 1) * query.PageSize)
                                   .Take(query.PageSize);
                _responseDTO.Result = _mapper.Map<List<ArticleDTO>>(articles);
            }
            catch (Exception ex)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id) { 
            try
            {
                ArticleEntity? a = FindArticleById(id);
                if (a != null)
                    _responseDTO.Result = _mapper.Map<ArticleDTO>(a);
                else 
                    _responseDTO.IsSuccess = false;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;

            }
            return _responseDTO;
        
        }

        [HttpGet]
        [Route("GetByTitle/{title}")]
        public ResponseDTO GetByTitle(string title)
        {
            try
            {
                IEnumerable<ArticleEntity> articles = _db.Articles.Where(a => a.Title.Contains(title)).ToList();
                if (articles.Any())
                {
                    _responseDTO.IsSuccess = false;
                }
                _responseDTO.Result = _mapper.Map<List<ArticleDTO>>(articles);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;

            }
            return _responseDTO;

        }

        [HttpPost]
        public ResponseDTO Create([FromBody] ArticleCreateDTO article )
        {
            try
            {
                ArticleEntity a = _mapper.Map<ArticleEntity>(article);
                _db.Articles.Add(a);
                _db.SaveChanges();
                _responseDTO.Result = _mapper.Map<ArticleDTO>(a);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;

            }
            return _responseDTO;

        }

        [HttpPut]
        [Route("{id:int}")]
        public ResponseDTO Update(int id, [FromBody] ArticleUpdateDTO article )
        {
            try
            {
                ArticleEntity? a = FindArticleById(id);
                if (a != null)
                {
                    _mapper.Map(article, a);
                    _db.Articles.Update(a);
                    _db.SaveChanges();
                    _responseDTO.Result = _mapper.Map<ArticleDTO>(a);
                }
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;

            }
            return _responseDTO;

        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDTO Delete(int id)
        {
            try
            {
                ArticleEntity? a = FindArticleById(id);
                if (a != null)
                    _db.Articles.Remove(a);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;

            }
            return _responseDTO;

        }

        private ArticleEntity? FindArticleById(int id)
        {

            ArticleEntity? article = _db.Articles.FirstOrDefault(a => a.Id == id);
            return article;
        }
    }
}
