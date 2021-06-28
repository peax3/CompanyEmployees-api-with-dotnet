using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
   public class Employee
   {
      [Key]
      public Guid EmployeeId { get; set; }

      [Required(ErrorMessage = "Employee address is required")]
      [MaxLength(20, ErrorMessage = "Maximum length for Employee name is 20 characters.")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Employee age is a required")]
      public int Age { get; set; }

      [Required(ErrorMessage = "Position is a required field.")]
      [MaxLength(20, ErrorMessage = "Maximum length for Employee position is 20 characters.")]
      public string Position { get; set; }

      // relationship
      [ForeignKey(nameof(Company))]
      public Guid CompanyId { get; set; }
      public Company Company { get; set; }

   }
}
