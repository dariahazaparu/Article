using Article.Services.API.Models;
using Article.Services.API.Models.DTO;
using AutoMapper;

namespace Article.Services.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapping = new MapperConfiguration(config =>
            {
                config.CreateMap<ArticleCreateDTO, ArticleEntity>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                    .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => DateTime.Now)); 
                config.CreateMap<ArticleDTO, ArticleEntity>();
                config.CreateMap<ArticleEntity, ArticleDTO>();
                //config.CreateMap<ArticleUpdateDTO, ArticleEntity>();
                config.CreateMap<ArticleUpdateDTO, ArticleEntity>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            });
            return mapping;
        }
    }
}
