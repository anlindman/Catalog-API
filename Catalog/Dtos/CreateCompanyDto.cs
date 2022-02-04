using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateCompanyDto
    {
        [Required]
        public int CompanyId { get; init; }
        [Required]
        public string? CompanyName { get; init; }
        [Required]
        public string? CompanyBaseCurrency { get; init; }
        [Required]
        public string? TaxRegistrationNumber { get; init; }
        [Required]
        public string? ContactPerson { get; init; }
        [Required]
        public string? ContactPersonEmail { get; init; }
        [Required]
        public string? ErrorHandlingRole { get; init; }
        public int PreliminaryRecordingInERP { get; init; }
    }
}
