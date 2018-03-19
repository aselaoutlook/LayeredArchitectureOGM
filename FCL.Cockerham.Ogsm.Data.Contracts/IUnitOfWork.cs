#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Contracts
///MODULE        :         
///SUB MODULE    :    
///Class         : IUnitOfWork
///AUTHOR        : Asela Chamara      
///CREATED       : 11/21/2015        
///DESCRIPTION   : Purpose is to provide an interface for FCL.Cockerham.Ogsm.Data.Uow.UnitOfWork class
///MODIFICATION HISTORY:  
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Web.Framework.Core.Common.Core;

namespace FCL.Cockerham.Ogsm.Data.Contracts
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        IUserRepository GetUserRepository();
        IRoleRepository GetRoleRepository();
        IPermissionRepository GetPermissionRepository();
        IAuditRepository GetAuditRepository();
        IBusinessUnitRepository GetBusinessUnitRepository();
        IStTypeRepository GetStTypeRepository();
        IFiscalYearRepository GetFiscalYearRepository();
        IPillarRepository GetPillarRepository();
        ICsfRepository GetCsfRepository();
        IGlobalRegionRepository GetGlobalRegionRepository();
        ILocationRepository GetLocationRepository();
        IStateRepository GetStateRepository();
        IActionPlanCommentRepository GetActionPlanCommentRepository();
        IActionPlanRepository GetActionPlanRepository();
        IAppSettingBaseRepository GetAppSettingBaseRepository();
        IAppSettingRepository GetAppSettingRepository();
        ICalendarEventRepository GetCalendarEventRepository();
        IEmployeeRepository GetEmployeeRepository();
        IGoalCategoryRepository GetGoalCategoryRepository();
        IGoalRepository GetGoalRepository();
        IGoalTargetRepository GetGoalTargetRepository();
        IOrganizationRepository GetOrganizationRepository();
        IScorecardPerspectiveRepository GetScorecardPerspectiveRepository();
        IDisplayBaseRepository GetDisplayBaseRepository();
        IDisplayNameRepository GetDisplayNameRepository();
        IStrategicDriverRepository GetStrategicDriverRepository();
        ITemplateRepository GetTemplateRepository();
        ICountryRepository GetCountryRepository();
        IEmployeeStrategyRepository GetEmployeeStrategyRepository();
        void Save();
        void Dispose();
    }
}
