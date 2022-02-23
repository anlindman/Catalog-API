using System.Text.Json.Serialization;

namespace Catalog.Entities
{
    public record Object
    {
        // Object data
        [JsonPropertyName("id")]
        public Guid Id { get; init; }
        [JsonPropertyName("objectTypeNo")]
        public int ObjectTypeNo { get; init; }
        [JsonPropertyName("object")]
        public string? ObjectId { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; init; }
        
    }
}
