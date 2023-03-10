using BlogClient.Models;
using DevBlog.Infrastructure.Interfaces;
using DevBlog.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DevBlog.Infrastructure.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BlogPostService> _logger;

        private readonly string imagePrefix = "https://oystein-bruin.herokuapp.com";

        bool showError = false;
        string errorMsg = string.Empty;
        string httpJsonStr = string.Empty;



        public BlogPostService(HttpClient httpClient, ILogger<BlogPostService> logger) 
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<AllPostsPagedModel> GetAllPostsPaged()
        {

                var url = "https://oystein-bruin.herokuapp.com/api/posts?populate=image";
                var response = await _httpClient.GetAsync(url);

                var responseAsString = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<AllPostsPagedModel>(responseAsString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReferenceHandler = ReferenceHandler.Preserve
                });


                if (responseObject != null && responseObject.data.Any())
                {
                    foreach (var post in responseObject.data)
                    {
                        post.attributes.imageUrl = imagePrefix + post.attributes.image.data.attributes.formats.medium.url;
                    }
                }

                return responseObject;
        }

        public async Task<PostDetailsModel> GetSinglePost()
        {
            var url = "https://oystein-bruin.herokuapp.com/api/posts?populate=image";
            var response = await _httpClient.GetAsync(url);

            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<PostDetailsModel>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            });

            //string? details = responseObject.data.attributes.content;

            responseObject.data.attributes.imageUrl = imagePrefix + (responseObject.data.attributes.image.data.attributes.formats.medium?.url ?? string.Empty);
            return responseObject;
        }
    }
}
