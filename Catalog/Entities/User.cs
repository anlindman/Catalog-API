using System.Text.Json.Serialization;

namespace Catalog.Entities
{
    public record User
    {
        // User data
        [JsonPropertyName("id")]
        public Guid Id { get; init; }
        [JsonPropertyName("userId")]
        public string? UserId { get; init; }
        [JsonPropertyName("userName")]
        public string? UserName { get; init; }
        [JsonPropertyName("language")]
        public string? Language { get; init; }
        [JsonPropertyName("email")]
        public string? Email { get; init; }

        // Permission groups for role
        public int Administrator { get; init; }
        public int AccountsPayable { get; init; }
        public int AccountPoster { get; init; }
        public int ExtendedReportPermission { get; init; }
        public int PermissionBitCode16 { get; init; }

        // Role and Authorization
        [JsonPropertyName("userRole")]
        public string? UserRole { get; init; }
        [JsonPropertyName("managerRole")]
        public string? ManagerRole { get; init; }
        [JsonPropertyName("authorizationAmount")]
        public int AuthorizationAmount { get; init; }

        // Select permissions
        public string? Company { get; init; }
        public string? Account { get; init; }
        public string? Department { get; init; }
        public string? Category { get; init; }
        public string? Project { get; init; }
        public string? ObjectType4 { get; init; }
        public string? ObjectType5 { get; init; }
        public string? ObjectType6 { get; init; }
        public string? ObjectType7 { get; init; }
        public string? ObjectType8 { get; init; }

        // Reminder mail and escalation routines
        public int SendReminderAfterXDaysInInbox { get; init; }
        public int TransferInvoiceToManagerRoleAfterXDaysInInbox { get; init; }
        public int SendReminderToManagerRoleAfterXDaysInInbox { get; init; }
        public int SendReminderXDaysBeforeDueDate { get; init; }
        public int DirectReminder { get; init; }

        // Reference alias for identification of user/role
        public string? ReferenceAlias1 { get; init; }
        public string? ReferenceAlias2 { get; init; }
        public string? ReferenceAlias3 { get; init; }
    }
}
