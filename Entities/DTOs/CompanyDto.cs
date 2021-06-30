using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class CompanyDto
   {
      public Guid CompanyId { get; set; }
      public string Name { get; set; }
      public string Address { get; set; }
   }
}
