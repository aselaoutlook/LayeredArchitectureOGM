using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using FCL.Web.Framework.Core.Common.Contracts;

namespace FCL.Web.Framework.Core.Common.Core
{
    public abstract class EntityBase : IExtensibleDataObject, IAuditableEntity
    {
        private bool auditEntity = true;
       
        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion

        [NotMapped]
        [DefaultValue(true)]
        public bool AuditChanges
        {
            get { return auditEntity; }
            set { auditEntity = value; }
        }
    }
}
