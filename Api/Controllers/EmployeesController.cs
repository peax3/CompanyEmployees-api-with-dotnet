using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Models;
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

      [HttpPost]
      public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeInputDto employeeInput)
      {
         if (employeeInput == null)
         {
            return BadRequest("cannot find cemployee object in request body");
         }

         var company = _repositoryManager.Company.GetCompany(companyId, false);

         if (company == null)
         {
            return NotFound();
         }

         var employee = _mapper.Map<Employee>(employeeInput);
         _repositoryManager.Employee.CreateEmployeeForCompany(companyId, employee);

         await _repositoryManager.SaveAsync();

         var employeeToReturn = _mapper.Map<EmployeeDto>(employee);

         return StatusCode(201, new { id = employeeToReturn.EmployeeId });

      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
      {
         var company = _repositoryManager.Company.GetCompany(companyId, false);
         if (company == null)
         {
            return NotFound();
         }

         var employeeForCompany = await _repositoryManager.Employee.GetEmployee(companyId, id, false);
         if (employeeForCompany == null)
         {
            return NotFound();
         }

         _repositoryManager.Employee.DeleteEmployee(employeeForCompany);
         await _repositoryManager.SaveAsync();

         return NoContent();
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeUpdateDto employeeUpdateDto)
      {
         if (employeeUpdateDto == null)
         {
            return BadRequest("cannot find employeeUpdateDto object in body");
         }

         var company = await _repositoryManager.Company.GetCompany(companyId, false);

         if (company == null)
         {
            return NotFound();
         }

         var employeeEntity = await _repositoryManager.Employee.GetEmployee(companyId, id, true);

         if (employeeEntity == null)
         {
            return NotFound();
         }

         _mapper.Map(employeeUpdateDto, employeeEntity);
         await _repositoryManager.SaveAsync();

         return NoContent();
      }
   }
}
