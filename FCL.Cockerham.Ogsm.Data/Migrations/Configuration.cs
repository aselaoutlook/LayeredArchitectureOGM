namespace FCL.Cockerham.Ogsm.Data.Migrations
{
    using FCL.Cockerham.Ogsm.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using FizzWare.NBuilder;

    internal sealed class Configuration : DbMigrationsConfiguration<FCL.Cockerham.Ogsm.Data.FclDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(FCL.Cockerham.Ogsm.Data.FclDBContext context)
        //{
        //    context.Organizations.AddOrUpdate(
        //          new Organization { OrganizationId = 1, Name = "ABC Company", IsActive = true },
        //          new Organization { OrganizationId = 2, Name = "XYZ Company", IsActive = true },
        //          new Organization { OrganizationId = 3, Name = "PQR Company", IsActive = true },
        //          new Organization { OrganizationId = 4, Name = "TUV Company", IsActive = true }
        //        );

        //    var roles = new List<Role>
        //        {
        //        new Role{RoleName="Adminisrator", RoleDescription="Administrator can access all areas of the application by default.", IsSysAdmin = true, Permissions = new List<Permission>(){new Permission(){PermissionId=1, PermissionDescription="admin-create"}}, 
        //            Users = new List<User>(){new User{ UserId=1, OrganizationId=1, UserName= "adminuser", FirstName= "Application", LastName= "Admin",Password = "123", IsActive= true, Email= "admin@fclanka.com", LastLoggedOn= DateTime.Parse("2015-09-11"), CreatedDate = DateTime.Parse("2015-09-11")}}},

        //        new Role{RoleName="Standard User", RoleDescription="Users of the application should be granted this role who are not permitted to undertake administrator duties.  This role must have individual permissions assigned unlike the Administrator role.", IsSysAdmin = true, Permissions = new List<Permission>(){new Permission(){PermissionId=2, PermissionDescription="home-index"}}, 
        //            Users = new List<User>(){new User{ UserId=2, OrganizationId=1, UserName="stduser", FirstName="Application", LastName="User",Password = "123", IsActive=true, Email="std@fclanka.com", LastLoggedOn=DateTime.Parse("2015-09-11"), CreatedDate = DateTime.Parse("2015-09-11")}}},
        //        };

        //    roles.ForEach(s => context.Roles.Add(s));
        //    try
        //    {
        //        context.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        var sb = new StringBuilder();
        //        foreach (var failure in ex.EntityValidationErrors)
        //        {
        //            sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
        //            foreach (var error in failure.ValidationErrors)
        //            {
        //                sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
        //                sb.AppendLine();
        //            }
        //        }
        //        throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
        //    }

        //    var businessUnits = Builder<BusinessUnit>.CreateListOfSize(30)
        //       .All()
        //           .With(c => c.OrganizationId = 1)
        //           .With(c => c.Name = "Business Unit " + Faker.RandomNumber.Next())
        //           .With(c => c.Description = Faker.Lorem.Sentence())
        //           .With(c => c.IsActive = true)
        //           .With(c => c.CreatedBy = 1)
        //           .With(c => c.CreatedDate = DateTime.Now)
        //           .With(c => c.UpdatedBy = 1)
        //           .With(c => c.UpdatedDate = new DateTime(1900, 1, 1, 0, 0, 0))
        //       .Build();
        //    foreach (var businessUnit in businessUnits)
        //    {
        //        context.BusinessUnits.AddOrUpdate(c => c.BusinessUnitId,
        //            businessUnit);
        //    }

        //    var stTypes = Builder<StType>.CreateListOfSize(30)
        //       .All()
        //           .With(c => c.OrganizationId = 1)
        //           .With(c => c.Name = "StType " + Faker.RandomNumber.Next())
        //           .With(c => c.Description = Faker.Lorem.Sentence())
        //           .With(c => c.IsActive = true)
        //           .With(c => c.CreatedBy = 1)
        //           .With(c => c.CreatedDate = DateTime.Now)
        //           .With(c => c.UpdatedBy = 1)
        //           .With(c => c.UpdatedDate = new DateTime(1900, 1, 1, 0, 0, 0))
        //       .Build();
        //    foreach (var stType in stTypes)
        //    {
        //        context.StTypes.AddOrUpdate(c => c.StTypeId,
        //            stType);
        //    }

        //    var globalRegions = Builder<GlobalRegion>.CreateListOfSize(30)
        //       .All()
        //           .With(c => c.OrganizationId = 1)
        //           .With(c => c.Name = "Global Region " + Faker.RandomNumber.Next())
        //       .Build();
        //    foreach (var globalRegion in globalRegions)
        //    {
        //        context.GlobalRegions.AddOrUpdate(c => c.GlobalRegionId,
        //            globalRegion);
        //    }

        //    var countries = Builder<Country>.CreateListOfSize(20)
        //       .All()
        //           .With(c => c.OrganizationId = 1)
        //           .With(c => c.Name = Faker.Address.Country())
        //           .With(c => c.GlobalRegionId = Faker.RandomNumber.Next(1, 30))
        //       .Build();
        //    foreach (var country in countries)
        //    {
        //        context.Countries.AddOrUpdate(c => c.CountryId,
        //            country);
        //    }

        //    var states = Builder<State>.CreateListOfSize(20)
        //       .All()
        //           .With(c => c.OrganizationId = 1)
        //           .With(c => c.StateName = Faker.Address.State())
        //           .With(c => c.StateCode = Faker.Address.StateAbbreviation())
        //           .With(c => c.CountryId = Faker.RandomNumber.Next(1, 20))
        //       .Build();
        //    foreach (var state in states)
        //    {
        //        context.States.AddOrUpdate(c => c.StateId,
        //            state);
        //    }

        //    var locations = Builder<Location>.CreateListOfSize(30)
        //       .All()
        //           .With(c => c.OrganizationId = 1)
        //           .With(c => c.Name = Faker.Address.StreetName())
        //           .With(c => c.IsGlobal = true)
        //           .With(c => c.StateId = Faker.RandomNumber.Next(1, 20))
        //           .With(c => c.CountryId = Faker.RandomNumber.Next(1, 20))
        //           .With(c => c.GlobalRegionId = Faker.RandomNumber.Next(1, 30))
        //           .With(c => c.CreatedBy = 1)
        //           .With(c => c.CreatedDate = DateTime.Now)
        //           .With(c => c.UpdatedBy = 1)
        //           .With(c => c.UpdatedDate = new DateTime(1900, 1, 1, 0, 0, 0))
        //       .Build();
        //    foreach (var location in locations)
        //    {
        //        context.Locations.AddOrUpdate(c => c.LocationId,
        //            location);
        //    }

        //    var pillers = Builder<Pillar>.CreateListOfSize(30)
        //       .All()
        //           .With(c => c.OrganizationId = 1)
        //           .With(c => c.Name = "Piller " + Faker.RandomNumber.Next())
        //           .With(c => c.Description = Faker.Lorem.Sentence())
        //           .With(c => c.IsActive = true)
        //           .With(c => c.CreatedBy = 1)
        //           .With(c => c.CreatedDate = DateTime.Now)
        //           .With(c => c.UpdatedBy = 1)
        //           .With(c => c.UpdatedDate = new DateTime(1900, 1, 1, 0, 0, 0))
        //       .Build();
        //    foreach (var piller in pillers)
        //    {
        //        context.Pillars.AddOrUpdate(c => c.PillarId,
        //            piller);
        //    }

        //    var csfs = Builder<Csf>.CreateListOfSize(30)
        //       .All()
        //           .With(c => c.OrganizationId = 1)
        //           .With(c => c.Name = "Csf " + Faker.RandomNumber.Next())
        //           .With(c => c.Description = Faker.Lorem.Sentence())
        //           .With(c => c.IsActive = true)
        //           .With(c => c.CreatedBy = 1)
        //           .With(c => c.CreatedDate = DateTime.Now)
        //           .With(c => c.UpdatedBy = 1)
        //           .With(c => c.UpdatedDate = new DateTime(1900, 1, 1, 0, 0, 0))
        //       .Build();
        //    foreach (var csf in csfs)
        //    {
        //        context.Csfs.AddOrUpdate(c => c.CsfId,
        //            csf);
        //    }
        //}
    }
}
