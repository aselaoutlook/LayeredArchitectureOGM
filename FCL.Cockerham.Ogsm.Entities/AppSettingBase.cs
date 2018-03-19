using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("AppSettingBase")]
    public partial class AppSettingBase : EntityBase, IIdentifiableEntity
    {
        public AppSettingBase()
        {
            AppSettings = new HashSet<AppSetting>();
        }

        public long AppSettingBaseId { get; set; }

        [Required]
        [StringLength(50)]
        public string SettingValue { get; set; }


        public virtual ICollection<AppSetting> AppSettings { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return AppSettingBaseId; }
            set { AppSettingBaseId = value; }
        }

        #endregion
    }
}
