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
   [Route("api/companies")]
   [ApiController]
   public class CompaniesController : ControllerBase
   {
      private readonly IRepositoryManager _repositoryManager;
      private readonly IMapper _mapper;

      public CompaniesController(IRepositoryManager repositoryManager, IMapper mapper)
      {
         this._repositoryManager = repositoryManager;
         this._mapper = mapper;
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAllCompanies()
      {
         var companies = await _repositoryManager.Company.GetAllCompanies(false);

         var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

         return Ok(companiesDto);

      }

      [HttpGet("{id}")]
      public async Task<ActionResult<CompanyDto>> GetCompany(Guid Id)
      {
         var company = await _repositoryManager.Company.GetCompany(Id, false);

         if (company == null)
         {
            return NotFound();
         }

         var companyDto = _mapper.Map<CompanyDto>(company);

         return Ok(companyDto);
      }

      [HttpPost]
      public async Task<IActionResult> CreateCompany([FromBody] CompanyInputDto companyInput)
      {
         if (companyInput == null)
         {
            return BadRequest("cannot find company object in the request");
         }

         var company = _mapper.Map<Company>(companyInput);
         _repositoryManager.Company.CreateCompany(company);

         await _repositoryManager.SaveAsync();

         var companyToReturn = _mapper.Map<CompanyDto>(company);

         return StatusCode(201, new { id = companyToReturn.CompanyId });

      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteCompany(Guid id)
      {
         var company = await _repositoryManager.Company.GetCompany(id, false);
         if (company == null)
         {
            return NotFound();
         }

         _repositoryManager.Company.DeleteCompany(company);
         await _repositoryManager.SaveAsync();

         return NoContent();
      }
   }
}
