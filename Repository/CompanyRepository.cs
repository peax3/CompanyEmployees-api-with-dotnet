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
   public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
   {
      public CompanyRepository(RepositoryContext repositoryContext)
         : base(repositoryContext)
      {
      }

      public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges)
      {
         return await FindAll(trackChanges).OrderBy(c => c.Name)
                                                      .ToListAsync();
      }

      public async Task<Company> GetCompany(Guid Id, bool trackChanges)
      {
         return await FIndByCondition(c => c.CompanyId == Id,
                                      trackChanges
                                      ).SingleOrDefaultAsync();
      }
   }
}
