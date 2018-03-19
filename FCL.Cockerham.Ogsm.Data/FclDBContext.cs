#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data
///MODULE        :         
///SUB MODULE    :    
///Class         : FclDBContext
///AUTHOR        : Asela Chamara      
///CREATED       : 05/10/2015
///LAST MODIFIED : 12/05/2015   
///DESCRIPTION   : Purpose is to provide overided db context for the application
///MODIFICATION HISTORY:  V2
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Utils;
using Newtonsoft.Json;
using FCL.Cockerham.Ogsm.Data.Entity_Configurations;

namespace FCL.Cockerham.Ogsm.Data
{
    public partial class FclDBContext : DbContext
    {
        #region Initialize DbSets
        public DbSet<ActionPlan> ActionPlans { get; set; }
        public DbSet<ActionPlanComment> ActionPlanComments { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<AppSettingBase> AppSettingBases { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Csf> Csfs { get; set; }
        public DbSet<StType> StTypes { get; set; }
        public DbSet<DisplayBase> DisplayBases { get; set; }
        public DbSet<DisplayName> DisplayNames { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FiscalYear> FiscalYears { get; set; }
        public DbSet<GlobalRegion> GlobalRegions { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalCategory> GoalCategories { get; set; }
        public DbSet<GoalTarget> GoalTargets { get; set; }
        public DbSet<StrategicDriverTarget> StrategicDriverTargets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Pillar> Pillars { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ScorecardPerspective> ScorecardPerspectives { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StrategicDriver> StrategicDrivers { get; set; }
        public DbSet<User> Users { get; set; }
        public virtual DbSet<EmployeeStrategy> EmployeeStrategies { get; set; }

        #endregion Initialize DbSets
        
        public FclDBContext()
            : base("FclDBContext") 
        {
            // This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error

            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new RoleEntityConfiguration());
            modelBuilder.Configurations.Add(new PermissionEntityConfiguration());
            modelBuilder.Configurations.Add(new AuditEntityConfiguration());
            modelBuilder.Configurations.Add(new ActionPlanEntityConfiguration());
            modelBuilder.Configurations.Add(new ActionPlanCommentEntityConfiguration());
            modelBuilder.Configurations.Add(new BusinessUnitEntityConfiguration());
            modelBuilder.Configurations.Add(new CalendarEventEntityConfiguration());
            modelBuilder.Configurations.Add(new CountryEntityConfiguration());
            modelBuilder.Configurations.Add(new CSFEntityConfiguration());
            modelBuilder.Configurations.Add(new StTypeEntityConfiguration());
            modelBuilder.Configurations.Add(new DisplayBaseEntityConfiguration());
            modelBuilder.Configurations.Add(new DisplayNameEntityConfiguration());
            modelBuilder.Configurations.Add(new EmployeeEntityConfiguration());
            modelBuilder.Configurations.Add(new FiscalYearEntityConfiguration());
            modelBuilder.Configurations.Add(new GlobalRegionEntityConfiguration());
            modelBuilder.Configurations.Add(new GoalEntityConfiguration());
            modelBuilder.Configurations.Add(new GoalCategoryEntityConfiguration());
            modelBuilder.Configurations.Add(new GoalTargetEntityConfiguration());
            modelBuilder.Configurations.Add(new StrategicDriverTargetEntityConfiguration());
            modelBuilder.Configurations.Add(new LocationEntityConfiguration());
            modelBuilder.Configurations.Add(new OrganizationEntityConfiguration());
            modelBuilder.Configurations.Add(new PillarEntityConfiguration());
            modelBuilder.Configurations.Add(new ScorecardPerspectiveEntityConfiguration());
            modelBuilder.Configurations.Add(new AppSettingEntityConfiguration());
            modelBuilder.Configurations.Add(new AppSettingBaseEntityConfiguration());
            modelBuilder.Configurations.Add(new StateEntityConfiguration());
            modelBuilder.Configurations.Add(new StrategicDriverEntityConfiguration());
            modelBuilder.Configurations.Add(new EmployeeStrategyEntityConfiguration());
            modelBuilder.Configurations.Add(new ActionStatusEntityConfiguration());
            modelBuilder.Configurations.Add(new ActionOperatorEntityConfiguration());
        }

        #region Override SaveChanges
        /// <summary>
        /// Overriding DbContext Save changes method to achive auditing capability
        /// </summary>
        /// <returns></returns>
        //public override int SaveChanges()
        //{
        //    var retVal = 0;
        //    var sessionTime = DateTime.Now;

        //    // Get all Added/Deleted/Modified entities
        //    foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified))
        //    {
        //        //Check whether this entity is marked as auditable & do the needful
        //        var auditableEntity = ent.Entity as IAuditableEntity;
        //        if (auditableEntity != null && !auditableEntity.AuditChanges)
        //            continue;


        //        // Get the Table() attribute, if one exists
        //        var tableAttr = ent.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
        //        var tableName = tableAttr != null ? tableAttr.Name : ent.Entity.GetType().Name;

        //        var audit = new Audit
        //        {
        //            //AuditId = Guid.NewGuid(),
        //            EventDateUTC = sessionTime,
        //            TableName = tableName,
        //            Action = ent.State.ToString(),
        //            UserName = "test"
        //        };


        //        var objectStateMgr = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager;

        //        var objectStateEntry = objectStateMgr.GetObjectStateEntry(ent.Entity);
        //        var id = string.Empty;

        //        if (objectStateEntry.EntityKey.EntityKeyValues != null)
        //            id = objectStateEntry.EntityKey.EntityKeyValues[0].Value.ToString();

        //        var setBase = objectStateMgr.GetObjectStateEntry(ent.Entity).EntitySet;

        //        var keyNames = setBase.ElementType.KeyMembers.Select(k => k.Name).ToArray();
        //        var keyName = (keyNames.Length != 0) ? keyNames.FirstOrDefault() : "Not Found";


        //        audit.RecordID = String.Format("{{PropertyName:{0};Value:{1}}}", id, keyName);

        //        switch (ent.State)
        //        {
        //            case EntityState.Added:
        //                audit.NewData = Serializer.Json(ent.CurrentValues.ToObject(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        //                break;
        //            case EntityState.Deleted:
        //                audit.OldData = Serializer.Json(ent.GetDatabaseValues().ToObject(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        //                break;
        //            case EntityState.Modified:
        //                audit.OldData = Serializer.Json(ent.GetDatabaseValues().ToObject(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });//SerializeToXml(ent.GetDatabaseValues().ToObject());
        //                audit.NewData = Serializer.Json(ent.CurrentValues.ToObject(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });//SerializeToXml(ent.CurrentValues.ToObject());
        //                break;
        //        }
        //        this.Audits.Add(audit);
        //    }
        //    retVal = base.SaveChanges();
        //    return retVal;
        //}
        #endregion Override SaveChanges

    }
}