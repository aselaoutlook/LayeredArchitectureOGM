using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("AppSetting")]
    public partial class AppSetting : EntityBase, IIdentifiableEntity
    {
        public long AppSettingId { get; set; }

        public long OrganizationId { get; set; }

        public long AppSettingBaseId { get; set; }

        [Required]
        [StringLength(50)]
        public string AppSettingValue { get; set; }

        public virtual AppSettingBase AppSettingBase { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return AppSettingId; }
            set { AppSettingId = value; }
        }

        #endregion

    }
}

