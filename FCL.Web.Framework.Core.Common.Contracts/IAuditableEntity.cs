namespace FCL.Web.Framework.Core.Common.Contracts
{
    public interface IAuditableEntity
    {
        bool AuditChanges { get; set; }
    }
}