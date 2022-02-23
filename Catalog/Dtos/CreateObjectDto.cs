using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateObjectDto
    {   
        [Required]
        public int ObjectTypeNo { get; init; }
        [Required]
        public string? ObjectId { get; init; }
        [Required]
        public string? Name { get; init; }
    }
}
