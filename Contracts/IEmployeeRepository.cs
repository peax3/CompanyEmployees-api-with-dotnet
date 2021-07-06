using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IEmployeeRepository
   {
      Task<IEnumerable<Employee>> GetAllEmployees(Guid companyId, bool trackChanges);

      Task<Employee> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);

      void CreateEmployeeForCompany(Guid companyId, Employee employee);

      void DeleteEmployee(Employee employee);
   }
}
