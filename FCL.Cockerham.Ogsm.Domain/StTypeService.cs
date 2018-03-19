using AutoMapper;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IStTypeService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StTypeService : IStTypeService
    {
        public StTypeDto CreateStType(StTypeDto _stType, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StType> StTypeService = _dataRepositoryFactory.GetRepository<StType>();
            StTypeDto _createdStType = Mapper.Map<StTypeDto>(StTypeService.Add(Mapper.Map<StType>(_stType)));

            return _createdStType;
        }

        public StTypeDto UpdateStType(StTypeDto _stType, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StType> StTypeService = _dataRepositoryFactory.GetRepository<StType>();
            StTypeDto _updatedStType = Mapper.Map<StTypeDto>(StTypeService.Update(Mapper.Map<StType>(_stType)));

            return _updatedStType;
        }

        public StTypeDto UpdateStType(StTypeDto _stType, long _stTypeId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StType> StTypeService = _dataRepositoryFactory.GetRepository<StType>();
            StTypeDto _updatedStType = Mapper.Map<StTypeDto>(StTypeService.Update(Mapper.Map<StType>(_stType), _stTypeId));

            return _updatedStType;
        }

        public StTypeDto GetStTypeByStTypeId(long _stTypeId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StType> StTypeService = _dataRepositoryFactory.GetRepository<StType>();
            StTypeDto _stType = Mapper.Map<StTypeDto>(StTypeService.GetSingle(c => c.StTypeId == _stTypeId && c.OrganizationId == _organizationId));

            return _stType;
        }

        public ICollection<StTypeDto> GetAllStTypes(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StType> StTypeService = _dataRepositoryFactory.GetRepository<StType>();
            ICollection<StTypeDto> _allStTypes = Mapper.Map<ICollection<StTypeDto>>(StTypeService.GetAll(i => i.OrganizationId.Equals(_organizationId) && i.IsActive.Equals(true)));

            return _allStTypes;
        }

        public IEnumerable<StTypeDto> GetStTypeList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StType> StTypeService = _dataRepositoryFactory.GetRepository<StType>();
            IEnumerable<StTypeDto> _allStTypes = Mapper.Map<IEnumerable<StTypeDto>>(StTypeService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name)));
            return _allStTypes;
        }

        /// <summary>
        /// Comment On 11-13-2017 By Asela
        /// Change Request By Heven: Change order of the filters in Dashboard
        /// </summary>
        //public IEnumerable<StTypeDto> GetStTypesByBusinessUnitId(long _businessUnitId, IUnitOfWork _dataRepositoryFactory)
        //{
        //    IBaseRepository<StType> StTypeService = _dataRepositoryFactory.GetRepository<StType>();
        //    IEnumerable<StTypeDto> _businessUnitStTypes = Mapper.Map<IEnumerable<StTypeDto>>(StTypeService.GetList(c => c.BusinessUnitId == _businessUnitId, null, "BusinessUnit"));

        //    return _businessUnitStTypes;
        //}

        public long GetStTypeCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<StType> StTypeService = _dataRepositoryFactory.GetRepository<StType>();
            return StTypeService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}
