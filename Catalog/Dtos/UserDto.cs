namespace Catalog.Dtos
{
    public record UserDto
    {
        // User data
        public Guid Id { get; init; }
        public string? UserId { get; init; }
        public string? UserName { get; init; }
        public string? Language { get; init; }
        public string? Email { get; init; }

        // Role and Authorization
        public string? UserRole { get; init; }
        public string? ManagerRole { get; init; }
        public int AuthorizationAmount { get; init; }
    }
}
