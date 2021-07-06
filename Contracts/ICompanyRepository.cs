using Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
   public interface ICompanyRepository
   {
      Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges);
      Task<Company> GetCompany(Guid Id, bool trackChanges);
      void CreateCompany(Company company);
      void DeleteCompany(Company company);
   }
}
