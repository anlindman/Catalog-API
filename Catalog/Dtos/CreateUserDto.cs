using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public class CreateUserDto
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
