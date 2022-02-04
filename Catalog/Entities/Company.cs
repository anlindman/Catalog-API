namespace Catalog.Entities
{
    public record Company
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

        // Default account and tax data
        public int DefaultPaymentTerms { get; init; }
        public int DefaultTradeCreditorsAccount { get; init; }
        public string? DefaultTradeCreditorsAccountName{ get; init; }
        public int DefaultExpenditureAccount { get; init; }
        public string? DefaultExpenditureAccountName { get; init; }
        public int DefaultTaxAccount { get; init; }
        public string? DefaultTaxAccountName { get; init; }
        public int DefaultTaxCode { get; init; }
        public int DefaultTaxCodePercentage { get; init; }

        // Company Alias
        public string? CompanyAlias1 { get; init; }
        public string? CompanyAlias2 { get; init; }
        public string? CompanyAlias3 { get; init; }

    }
}
