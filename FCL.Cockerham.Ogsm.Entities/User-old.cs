using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;

namespace FCL.Client.Project.Entities
{
    public class User : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Username is required")]
        public string FirstName { get; set; }

        [DataMember]
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Username is required")]
        public string LastName { get; set; }

        [DataMember]
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Username is required")]
        public string LoginName { get; set; }

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

        public int EntityId
        {
            get { return UserID; }
            set { UserID = value; }
        }
        #endregion
    }
}
