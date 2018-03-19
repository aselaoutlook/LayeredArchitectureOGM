using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("FiscalYear")]
    public partial class FiscalYear : EntityBase, IIdentifiableEntity
    {
        public long FiscalYearId { get; set; }

        public long OrganizationId { get; set; }

        public DateTime StartYear { get; set; }

        public DateTime EndYear { get; set; }

        public int EvaluationLength { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return FiscalYearId; }
            set { FiscalYearId = value; }
        }

        #endregion

    }
}

