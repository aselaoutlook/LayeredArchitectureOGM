using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("Audit")]
    public class Audit:EntityBase,IIdentifiableEntity
    {
        public Audit()
        {
            AuditChanges = false;
        }

        public long AuditId { get; set; }

        public DateTime EventDateUTC { get; set; }

        public string Action { get; set; }

        public string TableName { get; set; }

        public string UserName { get; set; }

        public string RecordID { get; set; }

        public string OldData { get; set; }

        public string NewData { get; set; }

        #region IIdentifiableEntity members
        public long EntityId
        {
            get { return AuditId; }
            set { AuditId = value; }
        }
        #endregion
    }
}
