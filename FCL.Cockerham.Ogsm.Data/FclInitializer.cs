#region Header
///--------------------------------------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data
///MODULE        :         
///SUB MODULE    :    
///Class         : FclInitializer
///AUTHOR        : Asela Chamara      
///CREATED       : 02/10/2015
///LAST MODIFIED : 12/02/2015   
///DESCRIPTION   : Purpose is to initilize the database of the application and insert master/test data in to the database
///MODIFICATION HISTORY:  V2
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///--------------------------------------------------------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data
{
    public class FclInitializer : DropCreateDatabaseIfModelChanges<FclDBContext>
    {
        protected override void Seed(FclDBContext context)
        {
            //var roles = new List<Role>
            //    {
            //    new Role{RoleName="Adminisrator", RoleDescription="Administrator can access all areas of the application by default.", IsSysAdmin = true, Permissions = new List<Permission>(){new Permission(){PermissionId=1, PermissionDescription="admin-create"}}, 
            //        Users = new List<User>(){new User{UserName= "adminuser", FirstName= "Application", LastName= "Admin",Password = "123", IsActive= true, Email= "admin@fclanka.com", LastLoggedOn= DateTime.Parse("2015-09-11"), CreatedDate = DateTime.Parse("2015-09-11")}}},

            //    new Role{RoleName="Standard User", RoleDescription="Users of the application should be granted this role who are not permitted to undertake administrator duties.  This role must have individual permissions assigned unlike the Administrator role.", IsSysAdmin = true, Permissions = new List<Permission>(){new Permission(){PermissionId=2, PermissionDescription="home-index"}}, 
            //        Users = new List<User>(){new User{UserName="stduser", FirstName="Application", LastName="User",Password = "123", IsActive=true, Email="std@fclanka.com", LastLoggedOn=DateTime.Parse("2015-09-11"), CreatedDate = DateTime.Parse("2015-09-11")}}},
            //    };

            //roles.ForEach(s => context.Roles.Add(s));
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    var sb = new StringBuilder();
            //    foreach (var failure in ex.EntityValidationErrors)
            //    {
            //        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
            //        foreach (var error in failure.ValidationErrors)
            //        {
            //            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            //            sb.AppendLine();
            //        }
            //    }
            //    throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            //}
        }
    }
}