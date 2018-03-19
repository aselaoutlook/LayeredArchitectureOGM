using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;

namespace FCL.Cockerham.Ogsm.Entities
{
    public class Template : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public long TemplateID { get; set; }

        [DataMember]
        [StringLength(100)]
        [Required(ErrorMessage = "Template name is required")]
        //[Index("IX_Name", 1, IsUnique = true)]
        public string Name { get; set; }

        [DataMember]
        [StringLength(250)]
        public string Description { get; set; }

        [DataMember]
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Template content is required")]
        public string Content { get; set; }

        [DataMember]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataMember]
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [DataMember]
        [StringLength(50, MinimumLength = 3)]
        public string Salt { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public DateTime LastLoggedOn { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        [StringLength(5, MinimumLength = 5)]
        public string LanguageCode { get; set; }

        [DataMember]
        [StringLength(50, MinimumLength = 3)]
        public string TimeZone { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return TemplateID; }
            set { TemplateID = value; }
        }
        #endregion
    }
}
