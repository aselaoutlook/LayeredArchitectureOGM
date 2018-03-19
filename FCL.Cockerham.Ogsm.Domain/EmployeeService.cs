using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using AutoMapper;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(IEmployeeService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EmployeeService
    {
        public EmployeeDto CreateEmployee(EmployeeDto _employee, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Employee> EmployeeService = _dataRepositoryFactory.GetRepository<Employee>();
            EmployeeDto _createdEmployee = Mapper.Map<EmployeeDto>(EmployeeService.Add(Mapper.Map<Employee>(_employee)));

            return _createdEmployee;
        }

        public EmployeeDto UpdateEmployee(EmployeeDto _employee, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Employee> EmployeeService = _dataRepositoryFactory.GetRepository<Employee>();
            EmployeeDto _updatedEmployee = Mapper.Map<EmployeeDto>(EmployeeService.Update(Mapper.Map<Employee>(_employee)));

            return _updatedEmployee;
        }

        public EmployeeDto UpdateEmployee(EmployeeDto _employee, long _employeeId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Employee> EmployeeService = _dataRepositoryFactory.GetRepository<Employee>();
            EmployeeDto _updatedEmployee = Mapper.Map<EmployeeDto>(EmployeeService.Update(Mapper.Map<Employee>(_employee), _employeeId));

            return _updatedEmployee;
        }

        public EmployeeDto GetEmployeeByEmployeeId(long _employeeId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Employee> EmployeeService = _dataRepositoryFactory.GetRepository<Employee>(); 
            EmployeeDto _employee = Mapper.Map<EmployeeDto>(EmployeeService.GetSingle(i => i.EmployeeId.Equals(_employeeId) && i.OrganizationId.Equals(_organizationId)));

            return _employee;
        }

        public ICollection<EmployeeDto> GetAllEmployees(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Employee> EmployeeService = _dataRepositoryFactory.GetRepository<Employee>();
            ICollection<EmployeeDto> _allEmployees = Mapper.Map<ICollection<EmployeeDto>>(EmployeeService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allEmployees;
        }

        public IEnumerable<EmployeeDto> GetEmployeeList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Employee> EmployeeService = _dataRepositoryFactory.GetRepository<Employee>();
            IEnumerable<EmployeeDto> _allEmployees = Mapper.Map<IEnumerable<EmployeeDto>>(EmployeeService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.EmployeeId), null));

            return _allEmployees;
        }

        public long GetEmployeeCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Employee> EmployeeService = _dataRepositoryFactory.GetRepository<Employee>(); 
            return EmployeeService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}