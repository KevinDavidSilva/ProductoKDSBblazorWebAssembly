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

        // Método para obtener una lista de posts
        public async Task<List<PostDTO>> GetPostAsync()
        {
            // Hacemos la solicitud y obtenemos la lista
            var lista = await _httpClient.GetFromJsonAsync<List<PostDTO>>("posts");

            // Si la lista es nula, devolvemos una lista vacía
            return lista ?? new List<PostDTO>();
        }

        // Método para crear un nuevo post
        public async Task<PostDTO> CreatePostAsync(PostDTO postDTO)
        {
            // Realizamos la solicitud POST con el objeto postDTO
            var response = await _httpClient.PostAsJsonAsync("posts", postDTO);

            // Aseguramos que la solicitud fue exitosa
            response.EnsureSuccessStatusCode();

            // Leemos la respuesta y la convertimos en un PostDTO
            var postResult = await response.Content.ReadFromJsonAsync<PostDTO>();

            // Si el resultado es nulo, devolvemos un nuevo objeto PostDTO
            return postResult ?? new PostDTO();
        }
    }
}
