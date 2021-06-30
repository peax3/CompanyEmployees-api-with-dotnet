using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         CreateMap<Company, CompanyDto>();
         CreateMap<Employee, EmployeeDto>();
      }
   }
}

