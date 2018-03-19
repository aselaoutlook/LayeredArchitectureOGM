using System;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualBasic;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using AutoMapper;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IStrategicDriverService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StrategicDriverService : IStrategicDriverService
    {
        [Import]
        INullHandler _nullHandlerService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        public StrategicDriverDto CreateStrategicDriver(StrategicDriverDto _strategicDriver, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            StrategicDriverDto _createdStrategicDriver = Mapper.Map<StrategicDriverDto>(StrategicDriverService.Add(Mapper.Map<StrategicDriver>(_strategicDriver)));

            return _createdStrategicDriver;
        }

        public StrategicDriverDto UpdateStrategicDriver(StrategicDriverDto _strategicDriver, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            StrategicDriverDto _updatedStrategicDriver = Mapper.Map<StrategicDriverDto>(StrategicDriverService.Update(Mapper.Map<StrategicDriver>(_strategicDriver)));

            return _updatedStrategicDriver;
        }

        public StrategicDriverDto UpdateStrategicDriver(StrategicDriverDto _strategicDriver, long _strategicDriverId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            StrategicDriverDto _updatedStrategicDriver = Mapper.Map<StrategicDriverDto>(StrategicDriverService.Update(Mapper.Map<StrategicDriver>(_strategicDriver), _strategicDriverId));

            return _updatedStrategicDriver;
        }

        public StrategicDriverDto GetStrategicDriverByStrategicDriverId(long _strategicDriverId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            StrategicDriverDto _strategicDriver =
                Mapper.Map<StrategicDriverDto>(StrategicDriverService.GetSingle(s => s.StrategicDriverId == (_strategicDriverId) && s.OrganizationId == (_organizationId),
                    "Goal, Pillar, Owner, StType, StrategicDriverTargets, FiscalYear"));

            return _strategicDriver;
        }

        public IEnumerable<StrategicDriverDto> GetAllStrategicDrivers(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            IEnumerable<StrategicDriverDto> _allStrategicDrivers = Mapper.Map<IEnumerable<StrategicDriverDto>>(StrategicDriverService.GetList(i => i.OrganizationId.Equals(_organizationId), s => s.OrderBy(sd => sd.Name), "Goal, Pillar"));

            return _allStrategicDrivers;
        }

        public IEnumerable<StrategicDriverDto> GetStrategicDriverList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            IEnumerable<StrategicDriverDto> _allStrategicDrivers = Mapper.Map<IEnumerable<StrategicDriverDto>>(StrategicDriverService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), "Goal, Pillar, Owner"));
            return _allStrategicDrivers;
        }

        public long GetStrategicDriverCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            return StrategicDriverService.Count(i => i.OrganizationId.Equals(_organizationId));
        }

        public IEnumerable<StrategicDriverDto> GetStrategicDriverByGoalId(long _goalId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            long _categoryId = Convert.ToInt64(_goalId);
            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            IEnumerable<StrategicDriverDto> _strategicDrivers = Mapper.Map<IEnumerable<StrategicDriverDto>>(StrategicDriverService.GetList(c => c.GoalId == _categoryId && c.OrganizationId == _organizationId, null, "Goal, Pillar"));

            return _strategicDrivers;
        }

        public IEnumerable<StrategicDriverDto> GetStrategicDriverByGoalAndStrategyOwner(long _goalId, long _ownerId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            long _strategyGoalId = Convert.ToInt64(_goalId);
            long _strategyOwnerId = Convert.ToInt64(_ownerId);

            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            IEnumerable<StrategicDriverDto> _strategicDrivers = Mapper.Map<IEnumerable<StrategicDriverDto>>(StrategicDriverService.GetList(c => c.GoalId == _strategyGoalId && c.OwnerId == _strategyOwnerId && c.OrganizationId == _organizationId, null, "Goal, Pillar"));
            return _strategicDrivers;
        }

        public IEnumerable<StrategicDriverDto> GetStrategicDriverByStrategyOwnerId(long _ownerId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            long _strategyOwnerId = Convert.ToInt64(_ownerId);

            IBaseRepository<StrategicDriver> StrategicDriverService = _dataRepositoryFactory.GetRepository<StrategicDriver>();
            IEnumerable<StrategicDriverDto> _strategicDrivers = Mapper.Map<IEnumerable<StrategicDriverDto>>(StrategicDriverService.GetList(c => c.OwnerId == _strategyOwnerId && c.OrganizationId == _organizationId, null, "Goal, Pillar"));
            return _strategicDrivers;
        }

        public bool CreateStrategicDriverTargetsForStrategy(StrategicDriverDto _strategicDriver, LoggedInUserDto _loggedInUser, IStrategicDriverTargetService _strategicDriverTargetDomainService, IUnitOfWork _dataRepositoryFactory)
        {
            try
            {
                IFiscalYearRepository FiscalYearService = _dataRepositoryFactory.GetFiscalYearRepository();
                FiscalYearDto _fiscalYear = Mapper.Map<FiscalYearDto>(FiscalYearService.GetSingle(f => f.FiscalYearId == _strategicDriver.FiscalYearId));

                if (_fiscalYear != null)
                {
                    DateTime FromDate = DateTime.Parse(_fiscalYear.StartYear.ToString());
                    DateTime ToDate = DateTime.Parse(_fiscalYear.EndYear.ToString());

                    int monthsApart = 12 * (ToDate.Year - FromDate.Year) + ToDate.Month - FromDate.Month;
                    DateTime newToDate = Convert.ToDateTime(ToDate.Year.ToString() + "-" + ToDate.Month.ToString() + "-" + FromDate.Day.ToString());
                    TimeSpan t = ToDate - newToDate;
                    if (t.Days > 0)
                        monthsApart += 1;

                    decimal quaters = (Convert.ToDecimal(monthsApart.ToString()) / 3);
                    string myString = quaters.ToString();
                    System.Collections.ArrayList qt = new System.Collections.ArrayList(myString.Split('.'));
                    if (qt.Count == 2)
                    {
                        quaters = Convert.ToDecimal(qt[0].ToString());
                        quaters += 1;
                    }

                    bool _exist = false;
                    DateTime targetEndDate;

                    for (int i = 0; i < quaters; i++)
                    {
                        StrategicDriverTargetDto target = new StrategicDriverTargetDto();
                        target.QuaterName = "Q " + (i + 1).ToString();
                        if (i == (quaters - 1))
                        {
                            target.EndDate = ToDate;
                            target.BeginDate = FromDate;
                        }
                        else
                        {
                            targetEndDate = FromDate.AddMonths(3);
                            target.EndDate = DateAndTime.DateAdd(DateInterval.Day, -1, Convert.ToDateTime(targetEndDate.ToString()));
                            target.BeginDate = FromDate;
                        }
                        if (((_strategicDriver.StartDate <= target.EndDate) && (_strategicDriver.StartDate >= FromDate)) || ((_strategicDriver.EndDate <= target.EndDate) && (_strategicDriver.EndDate >= FromDate)) && (_exist == false))
                        {
                            target.IsActive = true;
                            _exist = true;
                        }
                        else
                        {
                            target.IsActive = false;
                            if (_exist)
                            {
                                if (((target.EndDate <= _strategicDriver.EndDate) && (_strategicDriver.EndDate >= FromDate)) || ((_strategicDriver.EndDate <= target.EndDate) && (_strategicDriver.EndDate >= FromDate)))
                                    target.IsActive = true;
                                else
                                    target.IsActive = false;
                            }
                        }

                        target.StrategicDriverId = _strategicDriver.StrategicDriverId;
                        target.QuaterValue = -1;
                        target.OrganizationId = _loggedInUser.OrganizationId;
                        target.CreatedBy = _loggedInUser.UserId;
                        target.UpdatedBy = _loggedInUser.UserId;
                        target.CreatedDate = DateTime.Now;
                        FromDate = Convert.ToDateTime(target.EndDate).AddDays(1);
                        target.UpdatedDate = _nullHandlerService.SetMinimumdate();

                        _strategicDriverTargetDomainService.CreateStrategicDriverTarget(target, _dataRepositoryFactory);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }
    }
}