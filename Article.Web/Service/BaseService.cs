using Article.Web.Models;
using Article.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using static Article.Web.Utility.Types;


namespace Article.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;

        }
        public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO)
        {
            try {
            HttpClient client = httpClientFactory.CreateClient("ArticleAPI");
            HttpRequestMessage message = new();
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // TODO: token

            message.RequestUri = new Uri(requestDTO.Url);
            if (requestDTO.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
            }


            HttpResponseMessage? apiResponse = null;

            switch (requestDTO.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = await client.SendAsync(message);
            
            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "Not found" };
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Access denied" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "Unauthorized" };
                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, Message = "Internal Server Error" };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                    return apiResponseDto;
                }
            }catch(Exception ex)
            {
                var dto = new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
                return dto;
            }
        }
    }
}
