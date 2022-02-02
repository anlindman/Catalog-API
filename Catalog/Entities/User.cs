namespace Catalog.Entities
{
    public partial class User
    {
        public Guid Id { get; init; }
        public string? UserId { get; init; }
        public string? UserName { get; init; }
        public string? Language { get; init; }
        public string? Email { get; init; }

        //public partial class PermissionGroup
        //{
        //    public int Administrator { get; init; }
        //    public int AccountsPayable { get; init; }
        //    public int AccountPoster { get; init; }
        //    public int ExtendedReportPermission { get; init; }
        //    public int PermissionBitCode16 { get; init; }
        //}
        //public partial class RoleAndAuthorization
        //{
        //    public string? UserRole { get; init; }
        //    public string? ManagerRole { get; init; }
        //    public int AuthorizationAmount { get; init; }
        //}
        //public partial class Permission
        //{
        //    public string? Company { get; init; }
        //    public string? Account { get; init; }
        //    public string? Department { get; init; }
        //    public string? Category { get; init; }
        //    public string? Project { get; init; }
        //    public string? ObjectType4 { get; init; }
        //    public string? ObjectType5 { get; init; }
        //    public string? ObjectType6 { get; init; }
        //    public string? ObjectType7 { get; init; }
        //    public string? ObjectType8 { get; init; }
        //}
        //public partial class Reminder
        //{
        //    public int SendReminderAfterXDaysInInbox { get; init; }
        //    public int TransferInvoiceToManagerRoleAfterXDaysInInbox { get; init; }
        //    public int SendReminderToManagerRoleAfterXDaysInInbox { get; init; }
        //    public int SendReminderXDaysBeforeDueDate { get; init; }
        //    public int DirectReminder { get; init; }
        //}
        //public partial class ReferenceAlias
        //{
        //    public string? ReferenceAlias1 { get; init; }
        //    public string? ReferenceAlias2 { get; init; }
        //    public string? ReferenceAlias3 { get; init; }
        //}
    }
}
