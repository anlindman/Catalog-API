using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateUserDto
    {
        [Required]
        public string? UserId { get; init; }
        [Required]
        public string? UserName { get; init; }
        [Required]
        public string? Language { get; init; }
        [Required]
        public string? Email { get; init; }
    }
}
