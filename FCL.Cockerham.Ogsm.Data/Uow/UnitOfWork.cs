#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Uow
///MODULE        :         
///SUB MODULE    :    
///Class         : UnitOfWork
///AUTHOR        : Asela Chamara      
///CREATED       : 11/20/2015        
///DESCRIPTION   : Purpose is to provide UnitOfWork pattern to all repository classes 
///MODIFICATION HISTORY:  
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using System;
using FCL.Cockerham.Ogsm.Data.Data_Repositories;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using System.ComponentModel.Composition;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Uow
{
    [Export(typeof(IUnitOfWork))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private FclDBContext context = new FclDBContext();
        private Dictionary<string, object> _repositories;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private PermissionRepository permissionRepository;
        private AuditRepository auditRepository;
        private BusinessUnitRepository businessUnitRepository;
        private StTypeRepository stTypeRepository;
        private FiscalYearRepository fiscalYearRepository;
        private PillarRepository pillarRepository;
        private CsfRepository csfRepository;
        private GlobalRegionRepository globalRegionRepository;
        private LocationRepository locationRepository;
        private StateRepository stateRepository;
        private CountryRepository countryRepository;
        private ActionPlanCommentRepository actionPlanCommentRepository;
        private ActionPlanRepository actionPlanRepository;
        private AppSettingBaseRepository appSettingBaseRepository;
        private AppSettingRepository appSettingRepository;
        private CalendarEventRepository calendarEventRepository;
        private EmployeeRepository employeeRepository;
        private EmployeeStrategyRepository employeeStrategyRepository;
        private GoalCategoryRepository goalCategoryRepository;
        private GoalRepository goalRepository;
        private GoalTargetRepository goalTargetRepository;
        private OrganizationRepository organizationRepository;
        private ScorecardPerspectiveRepository scorecardPerspectiveRepository;
        private StrategicDriverRepository strategicDriverRepository;
        private TemplateRepository templateRepository;
        private DisplayBaseRepository displayBaseRepository;
        private DisplayNameRepository displayNameRepository;

        IBaseRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            var repositoryType = typeof(BaseRepository<>);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context));

            return (IBaseRepository<TEntity>)_repositories[type];
        }

        #region Repository
        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public RoleRepository RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new RoleRepository(context);
                }
                return roleRepository;
            }
        }

        public PermissionRepository PermissionRepository
        {
            get
            {
                if (this.permissionRepository == null)
                {
                    this.permissionRepository = new PermissionRepository(context);
                }
                return permissionRepository;
            }
        }

        public AuditRepository AuditRepository
        {
            get
            {
                if (this.auditRepository == null)
                {
                    this.auditRepository = new AuditRepository(context);
                }
                return auditRepository;
            }
        }

        public BusinessUnitRepository BusinessUnitRepository
        {
            get
            {
                if (this.businessUnitRepository == null)
                {
                    this.businessUnitRepository = new BusinessUnitRepository(context);
                }
                return businessUnitRepository;
            }
        }

        public StTypeRepository StTypeRepository
        {
            get
            {
                if (this.stTypeRepository == null)
                {
                    this.stTypeRepository = new StTypeRepository(context);
                }
                return stTypeRepository;
            }
        }

        public FiscalYearRepository FiscalYearRepository
        {
            get
            {
                if (this.fiscalYearRepository == null)
                {
                    this.fiscalYearRepository = new FiscalYearRepository(context);
                }
                return fiscalYearRepository;
            }
        }

        public PillarRepository PillarRepository
        {
            get
            {
                if (this.pillarRepository == null)
                {
                    this.pillarRepository = new PillarRepository(context);
                }
                return pillarRepository;
            }
        }

        public CsfRepository CsfRepository
        {
            get
            {
                if (this.csfRepository == null)
                {
                    this.csfRepository = new CsfRepository(context);
                }
                return csfRepository;
            }
        }

        public GlobalRegionRepository GlobalRegionRepository
        {
            get
            {
                if (this.globalRegionRepository == null)
                {
                    this.globalRegionRepository = new GlobalRegionRepository(context);
                }
                return globalRegionRepository;
            }
        }

        public LocationRepository LocationRepository
        {
            get
            {
                if (this.locationRepository == null)
                {
                    this.locationRepository = new LocationRepository(context);
                }
                return locationRepository;
            }
        }

        public StateRepository StateRepository
        {
            get
            {
                if (this.stateRepository == null)
                {
                    this.stateRepository = new StateRepository(context);
                }
                return stateRepository;
            }
        }

        public CountryRepository CountryRepository
        {
            get
            {
                if (this.countryRepository == null)
                {
                    this.countryRepository = new CountryRepository(context);
                }
                return countryRepository;
            }
        }

        public ActionPlanCommentRepository ActionPlanCommentRepository
        {
            get
            {
                if (this.actionPlanCommentRepository == null)
                {
                    this.actionPlanCommentRepository = new ActionPlanCommentRepository(context);
                }
                return actionPlanCommentRepository;
            }
        }

        public ActionPlanRepository ActionPlanRepository
        {
            get
            {
                if (this.actionPlanRepository == null)
                {
                    this.actionPlanRepository = new ActionPlanRepository(context);
                }
                return actionPlanRepository;
            }
        }

        public AppSettingBaseRepository AppSettingBaseRepository
        {
            get
            {
                if (this.appSettingBaseRepository == null)
                {
                    this.appSettingBaseRepository = new AppSettingBaseRepository(context);
                }
                return appSettingBaseRepository;
            }
        }

        public AppSettingRepository AppSettingRepository
        {
            get
            {
                if (this.appSettingRepository == null)
                {
                    this.appSettingRepository = new AppSettingRepository(context);
                }
                return appSettingRepository;
            }
        }

        public CalendarEventRepository CalendarEventRepository
        {
            get
            {
                if (this.calendarEventRepository == null)
                {
                    this.calendarEventRepository = new CalendarEventRepository(context);
                }
                return calendarEventRepository;
            }
        }

        public DisplayBaseRepository DisplayBaseRepository
        {
            get
            {
                if (this.displayBaseRepository == null)
                {
                    this.displayBaseRepository = new DisplayBaseRepository(context);
                }
                return displayBaseRepository;
            }
        }

        public DisplayNameRepository DisplayNameRepository
        {
            get
            {
                if (this.displayNameRepository == null)
                {
                    this.displayNameRepository = new DisplayNameRepository(context);
                }
                return displayNameRepository;
            }
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new EmployeeRepository(context);
                }
                return employeeRepository;
            }
        }

        public GoalCategoryRepository GoalCategoryRepository
        {
            get
            {
                if (this.goalCategoryRepository == null)
                {
                    this.goalCategoryRepository = new GoalCategoryRepository(context);
                }
                return goalCategoryRepository;
            }
        }

        public GoalRepository GoalRepository
        {
            get
            {
                if (this.goalRepository == null)
                {
                    this.goalRepository = new GoalRepository(context);
                }
                return goalRepository;
            }
        }

        public GoalTargetRepository GoalTargetRepository
        {
            get
            {
                if (this.goalTargetRepository == null)
                {
                    this.goalTargetRepository = new GoalTargetRepository(context);
                }
                return goalTargetRepository;
            }
        }

        public OrganizationRepository OrganizationRepository
        {
            get
            {
                if (this.organizationRepository == null)
                {
                    this.organizationRepository = new OrganizationRepository(context);
                }
                return organizationRepository;
            }
        }

        public ScorecardPerspectiveRepository ScorecardPerspectiveRepository
        {
            get
            {
                if (this.scorecardPerspectiveRepository == null)
                {
                    this.scorecardPerspectiveRepository = new ScorecardPerspectiveRepository(context);
                }
                return scorecardPerspectiveRepository;
            }
        }

        public StrategicDriverRepository StrategicDriverRepository
        {
            get
            {
                if (this.strategicDriverRepository == null)
                {
                    this.strategicDriverRepository = new StrategicDriverRepository(context);
                }
                return strategicDriverRepository;
            }
        }

        public TemplateRepository TemplateRepository
        {
            get
            {
                if (this.templateRepository == null)
                {
                    this.templateRepository = new TemplateRepository(context);
                }
                return templateRepository;
            }
        }

        public EmployeeStrategyRepository EmployeeStrategyRepository
        {
            get
            {
                if (this.employeeStrategyRepository == null)
                {
                    this.employeeStrategyRepository = new EmployeeStrategyRepository(context);
                }
                return employeeStrategyRepository;
            }
        }

        #endregion

        #region RepositoryInterfaces
        IUserRepository IUnitOfWork.GetUserRepository()
        {
            return this.UserRepository;
        }

        IRoleRepository IUnitOfWork.GetRoleRepository()
        {
            return this.RoleRepository;
        }

        IPermissionRepository IUnitOfWork.GetPermissionRepository()
        {
            return this.PermissionRepository;
        }

        IAuditRepository IUnitOfWork.GetAuditRepository()
        {
            return this.AuditRepository;
        }

        IBusinessUnitRepository IUnitOfWork.GetBusinessUnitRepository()
        {
            return this.BusinessUnitRepository;
        }

        IStTypeRepository IUnitOfWork.GetStTypeRepository()
        {
            return this.StTypeRepository;
        }

        IFiscalYearRepository IUnitOfWork.GetFiscalYearRepository()
        {
            return this.FiscalYearRepository;
        }

        IPillarRepository IUnitOfWork.GetPillarRepository()
        {
            return this.PillarRepository;
        }

        ICsfRepository IUnitOfWork.GetCsfRepository()
        {
            return this.CsfRepository;
        }

        IGlobalRegionRepository IUnitOfWork.GetGlobalRegionRepository()
        {
            return this.GlobalRegionRepository;
        }

        ILocationRepository IUnitOfWork.GetLocationRepository()
        {
            return this.LocationRepository;
        }

        IStateRepository IUnitOfWork.GetStateRepository()
        {
            return this.StateRepository;
        }

        ICountryRepository IUnitOfWork.GetCountryRepository()
        {
            return this.CountryRepository;
        }
        IActionPlanCommentRepository IUnitOfWork.GetActionPlanCommentRepository()
        {
            return this.ActionPlanCommentRepository;
        }


        IActionPlanRepository IUnitOfWork.GetActionPlanRepository()
        {
            return this.ActionPlanRepository;
        }


        IAppSettingBaseRepository IUnitOfWork.GetAppSettingBaseRepository()
        {
            return this.AppSettingBaseRepository;
        }


        IAppSettingRepository IUnitOfWork.GetAppSettingRepository()
        {
            return this.AppSettingRepository;
        }


        ICalendarEventRepository IUnitOfWork.GetCalendarEventRepository()
        {
            return this.CalendarEventRepository;
        }

        IEmployeeRepository IUnitOfWork.GetEmployeeRepository()
        {
            return this.EmployeeRepository;
        }

        IGoalCategoryRepository IUnitOfWork.GetGoalCategoryRepository()
        {
            return this.GoalCategoryRepository;
        }

        IGoalRepository IUnitOfWork.GetGoalRepository()
        {
            return this.GoalRepository;
        }

        IGoalTargetRepository IUnitOfWork.GetGoalTargetRepository()
        {
            return this.GoalTargetRepository;
        }

        IOrganizationRepository IUnitOfWork.GetOrganizationRepository()
        {
            return this.OrganizationRepository;
        }

        IScorecardPerspectiveRepository IUnitOfWork.GetScorecardPerspectiveRepository()
        {
            return this.ScorecardPerspectiveRepository;
        }


        IDisplayBaseRepository IUnitOfWork.GetDisplayBaseRepository()
        {
            return this.DisplayBaseRepository;
        }


        ITemplateRepository IUnitOfWork.GetTemplateRepository()
        {
            return this.TemplateRepository;
        }

        IStrategicDriverRepository IUnitOfWork.GetStrategicDriverRepository()
        {
            return this.StrategicDriverRepository;
        }

        IDisplayNameRepository IUnitOfWork.GetDisplayNameRepository()
        {
            return this.DisplayNameRepository;
        }

        IEmployeeStrategyRepository IUnitOfWork.GetEmployeeStrategyRepository()
        {
            return this.EmployeeStrategyRepository;
        }

        #endregion

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
