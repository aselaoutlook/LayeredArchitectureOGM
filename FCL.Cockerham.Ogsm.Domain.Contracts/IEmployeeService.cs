using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface IEmployeeService
    {
        EmployeeDto CreateEmployee(EmployeeDto _employee, IUnitOfWork _dataRepositoryFactory);
        EmployeeDto UpdateEmployee(EmployeeDto _employee, IUnitOfWork _dataRepositoryFactory);
        EmployeeDto UpdateEmployee(EmployeeDto _employee, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        EmployeeDto GetEmployeeByEmployeeId(long _employeeId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<EmployeeDto> GetAllEmployees(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<EmployeeDto> GetEmployeeList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetEmployeeCount(long _organizationId, IUnitOfWork _dataRepositoryFactory); 
    }
}