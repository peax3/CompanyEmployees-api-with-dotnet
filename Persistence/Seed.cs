using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
   public class Seed
   {
      public static async Task SeedData(RepositoryContext repositoryContext)
      {

         if (repositoryContext.Companies.Any() && repositoryContext.Employees.Any())
            return;

         var companies = new List<Company>
         {
            new Company
            {
               CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
               Name = "IT_Solutions Ltd",
               Address = "583 Wall Dr. Gwynn Oak, MD 21207, NG"
            },
            new Company
            {
               CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
               Name = "Admin_Solutions Ltd",
               Address = "312 Forest Avenue, BF 923, NG"
            }
         };


         var employees = new List<Employee>
         {
            new Employee
            {  EmployeeId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
               Name = "Sam Raiden", Age = 26,
               Position = "Software developer",
               CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            },
            new Employee
            {
               EmployeeId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
               Name = "Jana McLeaf", Age = 30, Position = "Software developer",
               CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            },
            new Employee
            {
               EmployeeId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
               Name = "Kane Miller",
               Age = 35, Position = "Administrator",
               CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
            }
         };

         await repositoryContext.Companies.AddRangeAsync(companies);
         await repositoryContext.Employees.AddRangeAsync(employees);
         await repositoryContext.SaveChangesAsync();
      }
   }
}
