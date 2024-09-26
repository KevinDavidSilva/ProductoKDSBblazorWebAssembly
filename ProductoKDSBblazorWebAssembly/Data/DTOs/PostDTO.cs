using System.Text.Json.Serialization;

namespace ProductoKDSBblazorWebAssembly.Data.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }

        [JsonPropertyName("nombreKDSB")]
        public string NombreKDSB { get; set; }

        [JsonPropertyName("descripcionKDSB")]
        public string DescripcionKDSB { get; set; }

        [JsonPropertyName("precio")]
        public decimal Precio { get; set; }
    }
}
