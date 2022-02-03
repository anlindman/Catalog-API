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
        [Required]
        public string? UserRole { get; init; }
        public string? ManagerRole { get; init; }
        public int AuthorizationAmount { get; init; }
    }
}
