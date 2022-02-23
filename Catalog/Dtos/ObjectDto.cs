namespace Catalog.Dtos
{
    public record ObjectDto
    {
        // Object data
        public Guid Id { get; init; }
        public int ObjectTypeNo { get; init; }
        public string? ObjectId { get; init; }
        public string? Name { get; init; }
    }
}
