using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class Company
   {
      [Key]
      public Guid CompanyId { get; set; }

      [Required(ErrorMessage = "Company name is required")]
      [MaxLength(40, ErrorMessage = "Maximum length for the Company name is 40 characters.")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Company address is required")]
      public string Address { get; set; }

      // relationship
      public ICollection<Employee> Employees { get; set; }
   }
}
