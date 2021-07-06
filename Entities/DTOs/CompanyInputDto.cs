using System;
using System.Collections.Generic;

namespace Entities.DTOs
{
   public class CompanyInputDto
   {
      public string Name { get; set; }
      public string Address { get; set; }

      public IEnumerable<EmployeeInputDto> Employees { get; set; }
   }
}
