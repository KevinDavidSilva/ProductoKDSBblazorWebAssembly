using ProductoKDSBblazorWebAssembly.Data.DTOs;
using System.Net.Http.Json;

namespace ProductoKDSBblazorWebAssembly.Data.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("JsonPlaceholder_API");
        }

        public async Task<List<PostDTO>> GetPostAsync()
        {
            var lista = await _httpClient.GetFromJsonAsync<List<PostDTO>>("posts");

            if (lista == null)
                return lista;
            else
                return new List<PostDTO>();
        }

        public async Task<PostDTO> CreatePostAsync(PostDTO postDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("posts", postDTO);
            response.EnsureSuccessStatusCode();
            var postResult = await response.Content.ReadFromJsonAsync<PostDTO>();

            if (postResult == null)
                return postResult;
            else
                return new PostDTO();
        }
    }
}
