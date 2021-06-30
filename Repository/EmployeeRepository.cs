using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
   public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
   {
      public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
      {
      }

      public async Task<IEnumerable<Employee>> GetAllEmployees(Guid companyId, bool trackChanges)
      {
         return await FIndByCondition(e => e.CompanyId.Equals(companyId),
                                      trackChanges
                                      ).OrderBy(e => e.Name).ToListAsync();
      }

      public async Task<Employee> GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
      {
         return await FIndByCondition(e => e.CompanyId.Equals(companyId) && e.EmployeeId.Equals(employeeId),
                                      trackChanges
                                      ).SingleOrDefaultAsync();
      }
   }
}
