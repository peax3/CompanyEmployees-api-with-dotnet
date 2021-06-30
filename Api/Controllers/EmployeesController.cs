using AutoMapper;
using Contracts;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
   [Route("api/companies/{companyId}/[controller]")]
   [ApiController]
   public class EmployeesController : ControllerBase
   {
      private readonly IRepositoryManager _repositoryManager;
      private readonly IMapper _mapper;

      public EmployeesController(IRepositoryManager repositoryManager, IMapper mapper)
      {
         this._repositoryManager = repositoryManager;
         this._mapper = mapper;
      }

      [HttpGet]
      public async Task<IActionResult> GetEmployeesForCompany(Guid companyId)
      {
         var company = await _repositoryManager.Company.GetCompany(companyId, false);
         if (company == null)
         {
            return NotFound();
         }

         var employees = await _repositoryManager.Employee.GetAllEmployees(companyId, false);

         var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

         return Ok(employeesDto);

      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid Id)
      {
         var company = await _repositoryManager.Company.GetCompany(companyId, false);
         if (company == null)
         {
            return NotFound();
         }

         var employee = await _repositoryManager.Employee.GetEmployee(companyId, Id, false);

         var employeeDto = _mapper.Map<EmployeeDto>(employee);

         return Ok(employeeDto);
      }
   }
}
