namespace Catalog.Dtos
{
    public record CompanyDto
    {
        // Company data
        public Guid Id { get; init; }
        public int CompanyId { get; init; }
        public string? CompanyName { get; init; }
        public string? CompanyBaseCurrency { get; init; }
        public string? TaxRegistrationNumber { get; init; }
        public string? ContactPerson { get; init; }
        public string? ContactPersonEmail { get; init; }
        public string? ErrorHandlingRole { get; init; }
        public int PreliminaryRecordingInERP { get; init; }
    }
}
