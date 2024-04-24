using System.ComponentModel.DataAnnotations;

namespace Article.Services.API.Models
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; } = 1;

        [Range(1, 50)]
        public int PageSize { get; set; } = 10;
    }
}
