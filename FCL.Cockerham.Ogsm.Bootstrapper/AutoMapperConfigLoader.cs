using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;

namespace FCL.Cockerham.Ogsm.Bootstrapper
{
    public static class AutoMapperConfigLoader
    {
        public static void RegisterMappings()
        {
            //Custom Dtos
            AutoMapper.Mapper.CreateMap<User, LoggedInUserDto>();
            AutoMapper.Mapper.CreateMap<LoggedInUserDto, User>();

            //Plain Entity Dtos
            AutoMapper.Mapper.CreateMap<ActionOperator, ActionOperatorPlainDto>();
            AutoMapper.Mapper.CreateMap<ActionOperatorPlainDto, ActionOperator>();

            AutoMapper.Mapper.CreateMap<ActionPlanComment, ActionPlanCommentPlainDto>();
            AutoMapper.Mapper.CreateMap<ActionPlanCommentPlainDto, ActionPlanComment>();

            AutoMapper.Mapper.CreateMap<ActionPlan, ActionPlanPlainDto>();
            AutoMapper.Mapper.CreateMap<ActionPlanPlainDto, ActionPlan>();

            AutoMapper.Mapper.CreateMap<ActionStatus, ActionStatusPlainDto>();
            AutoMapper.Mapper.CreateMap<ActionStatusPlainDto, ActionStatus>();

            AutoMapper.Mapper.CreateMap<AppSettingBase, AppSettingBasePlainDto>();
            AutoMapper.Mapper.CreateMap<AppSettingBasePlainDto, AppSettingBase>();

            AutoMapper.Mapper.CreateMap<AppSetting, AppSettingPlainDto>();
            AutoMapper.Mapper.CreateMap<AppSettingPlainDto, AppSetting>();

            AutoMapper.Mapper.CreateMap<BusinessUnit, BusinessUnitPlainDto>();
            AutoMapper.Mapper.CreateMap<BusinessUnitPlainDto, BusinessUnit>();

            AutoMapper.Mapper.CreateMap<CalendarEvent, CalendarEventPlainDto>();
            AutoMapper.Mapper.CreateMap<CalendarEventPlainDto, CalendarEvent>();

            AutoMapper.Mapper.CreateMap<Country, CountryPlainDto>();
            AutoMapper.Mapper.CreateMap<CountryPlainDto, Country>();

            AutoMapper.Mapper.CreateMap<Csf, CsfPlainDto>();
            AutoMapper.Mapper.CreateMap<CsfPlainDto, Csf>();

            AutoMapper.Mapper.CreateMap<StType, StTypePlainDto>();
            AutoMapper.Mapper.CreateMap<StTypePlainDto, StType>();

            AutoMapper.Mapper.CreateMap<DisplayBase, DisplayBasePlainDto>();
            AutoMapper.Mapper.CreateMap<DisplayBasePlainDto, DisplayBase>();

            AutoMapper.Mapper.CreateMap<DisplayName, DisplayNamePlainDto>();
            AutoMapper.Mapper.CreateMap<DisplayNamePlainDto, DisplayName>();

            AutoMapper.Mapper.CreateMap<Employee, EmployeePlainDto>();
            AutoMapper.Mapper.CreateMap<EmployeePlainDto, Employee>();

            AutoMapper.Mapper.CreateMap<EmployeeStrategy, EmployeeStrategyPlainDto>();
            AutoMapper.Mapper.CreateMap<EmployeeStrategyPlainDto, EmployeeStrategy>();

            AutoMapper.Mapper.CreateMap<FiscalYear, FiscalYearPlainDto>();
            AutoMapper.Mapper.CreateMap<FiscalYearPlainDto, FiscalYear>();

            AutoMapper.Mapper.CreateMap<GlobalRegion, GlobalRegionPlainDto>();
            AutoMapper.Mapper.CreateMap<GlobalRegionPlainDto, GlobalRegion>();

            AutoMapper.Mapper.CreateMap<GoalCategory, GoalCategoryPlainDto>();
            AutoMapper.Mapper.CreateMap<GoalCategoryPlainDto, GoalCategory>();

            AutoMapper.Mapper.CreateMap<Goal, GoalPlainDto>();
            AutoMapper.Mapper.CreateMap<GoalPlainDto, Goal>();

            AutoMapper.Mapper.CreateMap<GoalTarget, GoalTargetPlainDto>();
            AutoMapper.Mapper.CreateMap<GoalTargetPlainDto, GoalTarget>();

            AutoMapper.Mapper.CreateMap<Location, LocationPlainDto>();
            AutoMapper.Mapper.CreateMap<LocationPlainDto, Location>();

            AutoMapper.Mapper.CreateMap<Organization, OrganizationPlainDto>();
            AutoMapper.Mapper.CreateMap<OrganizationPlainDto, Organization>();

            AutoMapper.Mapper.CreateMap<Permission, PermissionPlainDto>();
            AutoMapper.Mapper.CreateMap<PermissionPlainDto, Permission>();

            AutoMapper.Mapper.CreateMap<Pillar, PillarPlainDto>();
            AutoMapper.Mapper.CreateMap<PillarPlainDto, Pillar>();

            AutoMapper.Mapper.CreateMap<Role, RolePlainDto>();
            AutoMapper.Mapper.CreateMap<RolePlainDto, Role>();

            AutoMapper.Mapper.CreateMap<ScorecardPerspective, ScorecardPerspectivePlainDto>();
            AutoMapper.Mapper.CreateMap<ScorecardPerspectivePlainDto, ScorecardPerspective>();

            AutoMapper.Mapper.CreateMap<State, StatePlainDto>();
            AutoMapper.Mapper.CreateMap<StatePlainDto, State>();

            AutoMapper.Mapper.CreateMap<StrategicDriver, StrategicDriverPlainDto>();
            AutoMapper.Mapper.CreateMap<StrategicDriverPlainDto, StrategicDriver>();

            AutoMapper.Mapper.CreateMap<StrategicDriverTarget, StrategicDriverTargetPlainDto>();
            AutoMapper.Mapper.CreateMap<StrategicDriverTargetPlainDto, StrategicDriverTarget>();

            AutoMapper.Mapper.CreateMap<User, UserPlainDto>();
            AutoMapper.Mapper.CreateMap<UserPlainDto, User>();

            //Main Entity Dtos
            AutoMapper.Mapper.CreateMap<ActionOperator, ActionOperatorDto>();
            AutoMapper.Mapper.CreateMap<ActionOperatorDto, ActionOperator>();

            AutoMapper.Mapper.CreateMap<ActionPlanComment, ActionPlanCommentDto>();
            AutoMapper.Mapper.CreateMap<ActionPlanCommentDto, ActionPlanComment>();

            AutoMapper.Mapper.CreateMap<ActionPlan, ActionPlanDto>();
            AutoMapper.Mapper.CreateMap<ActionPlanDto, ActionPlan>();

            AutoMapper.Mapper.CreateMap<ActionStatus, ActionStatusDto>();
            AutoMapper.Mapper.CreateMap<ActionStatusDto, ActionStatus>();

            AutoMapper.Mapper.CreateMap<AppSettingBase, AppSettingBaseDto>();
            AutoMapper.Mapper.CreateMap<AppSettingBaseDto, AppSettingBase>();

            AutoMapper.Mapper.CreateMap<AppSetting, AppSettingDto>();
            AutoMapper.Mapper.CreateMap<AppSettingDto, AppSetting>();

            AutoMapper.Mapper.CreateMap<Audit, AuditDto>();
            AutoMapper.Mapper.CreateMap<AuditDto, Audit>();

            AutoMapper.Mapper.CreateMap<BusinessUnit, BusinessUnitDto>();
            AutoMapper.Mapper.CreateMap<BusinessUnitDto, BusinessUnit>();

            AutoMapper.Mapper.CreateMap<CalendarEvent, CalendarEventDto>();
            AutoMapper.Mapper.CreateMap<CalendarEventDto, CalendarEvent>();

            AutoMapper.Mapper.CreateMap<Country, CountryDto>();
            AutoMapper.Mapper.CreateMap<CountryDto, Country>();

            AutoMapper.Mapper.CreateMap<Csf, CsfDto>();
            AutoMapper.Mapper.CreateMap<CsfDto, Csf>();

            AutoMapper.Mapper.CreateMap<StType, StTypeDto>();
            AutoMapper.Mapper.CreateMap<StTypeDto, StType>();

            AutoMapper.Mapper.CreateMap<DisplayBase, DisplayBaseDto>();
            AutoMapper.Mapper.CreateMap<DisplayBaseDto, DisplayBase>();

            AutoMapper.Mapper.CreateMap<DisplayName, DisplayNameDto>();
            AutoMapper.Mapper.CreateMap<DisplayNameDto, DisplayName>();

            AutoMapper.Mapper.CreateMap<Employee, EmployeeDto>();
            AutoMapper.Mapper.CreateMap<EmployeeDto, Employee>();

            AutoMapper.Mapper.CreateMap<EmployeeStrategy, EmployeeStrategyDto>();
            AutoMapper.Mapper.CreateMap<EmployeeStrategyDto, EmployeeStrategy>();

            AutoMapper.Mapper.CreateMap<FiscalYear, FiscalYearDto>();
            AutoMapper.Mapper.CreateMap<FiscalYearDto, FiscalYear>();

            AutoMapper.Mapper.CreateMap<GlobalRegion, GlobalRegionDto>();
            AutoMapper.Mapper.CreateMap<GlobalRegionDto, GlobalRegion>();

            AutoMapper.Mapper.CreateMap<GoalCategory, GoalCategoryDto>();
            AutoMapper.Mapper.CreateMap<GoalCategoryDto, GoalCategory>();

            AutoMapper.Mapper.CreateMap<Goal, GoalDto>();
            AutoMapper.Mapper.CreateMap<GoalDto, Goal>();

            AutoMapper.Mapper.CreateMap<GoalTarget, GoalTargetDto>();
            AutoMapper.Mapper.CreateMap<GoalTargetDto, GoalTarget>();

            AutoMapper.Mapper.CreateMap<Location, LocationDto>();
            AutoMapper.Mapper.CreateMap<LocationDto, Location>();

            AutoMapper.Mapper.CreateMap<Organization, OrganizationDto>();
            AutoMapper.Mapper.CreateMap<OrganizationDto, Organization>();

            AutoMapper.Mapper.CreateMap<Permission, PermissionDto>();
            AutoMapper.Mapper.CreateMap<PermissionDto, Permission>();

            AutoMapper.Mapper.CreateMap<Pillar, PillarDto>();
            AutoMapper.Mapper.CreateMap<PillarDto, Pillar>();

            AutoMapper.Mapper.CreateMap<Role, RoleDto>();
            AutoMapper.Mapper.CreateMap<RoleDto, Role>();

            AutoMapper.Mapper.CreateMap<ScorecardPerspective, ScorecardPerspectiveDto>();
            AutoMapper.Mapper.CreateMap<ScorecardPerspectiveDto, ScorecardPerspective>();

            AutoMapper.Mapper.CreateMap<State, StateDto>();
            AutoMapper.Mapper.CreateMap<StateDto, State>();

            AutoMapper.Mapper.CreateMap<StrategicDriver, StrategicDriverDto>();
            AutoMapper.Mapper.CreateMap<StrategicDriverDto, StrategicDriver>();

            AutoMapper.Mapper.CreateMap<StrategicDriverTarget, StrategicDriverTargetDto>();
            AutoMapper.Mapper.CreateMap<StrategicDriverTargetDto, StrategicDriverTarget>();

            AutoMapper.Mapper.CreateMap<Template, TemplateDto>();
            AutoMapper.Mapper.CreateMap<TemplateDto, Template>();

            AutoMapper.Mapper.CreateMap<User, UserDto>();
            AutoMapper.Mapper.CreateMap<UserDto, User>();
        }
    }
}
