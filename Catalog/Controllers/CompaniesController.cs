using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        public CompaniesController(ICompanyRepository repository)
        {
            _repository = repository;
        }

        // GET /companies
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
        {
            var companies = (await _repository.GetAllCompaniesAsync())
                        .Select(company => company.AsDto());

            return companies;
        }

        // GET /companies{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompanyAsync(Guid id)
        {
            var company = await _repository.GetCompanyAsync(id);

            if (company is null)
            {
                return NotFound();
            }

            return company.AsDto();
        }

        // POST /companies
        [HttpPost]
        public async Task<ActionResult<CompanyDto>> CreateCompanyAsync(CreateCompanyDto companyDto)
        {
            Company company = new()
            {
                Id = Guid.NewGuid(),
                CompanyId = companyDto.CompanyId,
                CompanyName = companyDto.CompanyName,
                CompanyBaseCurrency = companyDto.CompanyBaseCurrency,
                TaxRegistrationNumber = companyDto.TaxRegistrationNumber,
                ContactPerson = companyDto.ContactPerson,
                ContactPersonEmail = companyDto.ContactPersonEmail,
                ErrorHandlingRole = companyDto.ErrorHandlingRole,
                PreliminaryRecordingInERP = companyDto.PreliminaryRecordingInERP
            };

            await _repository.CreateCompanyAsync(company);

            return CreatedAtAction(nameof(GetCompanyAsync), new { id = company.Id }, company.AsDto());
        }

        // PUT /companies/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompanyAsync(Guid id, UpdateCompanyDto companyDto)
        {
            var existingCompany = await _repository.GetCompanyAsync(id);

            if (existingCompany is null)
            {
                return NotFound();
            }

            Company updatedCompany = existingCompany with
            {
                CompanyId = companyDto.CompanyId,
                CompanyName = companyDto.CompanyName,
                CompanyBaseCurrency = companyDto.CompanyBaseCurrency,
                TaxRegistrationNumber = companyDto.TaxRegistrationNumber,
                ContactPerson = companyDto.ContactPerson,
                ContactPersonEmail = companyDto.ContactPersonEmail,
                ErrorHandlingRole = companyDto.ErrorHandlingRole,
                PreliminaryRecordingInERP = companyDto.PreliminaryRecordingInERP
            };

            await _repository.UpdateCompanyAsync(updatedCompany);

            return NoContent();
        }

        // DELETE /companies/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompanyAsync(Guid id)
        {
            var existingCompany = await _repository.GetCompanyAsync(id);

            if (existingCompany is null)
            {
                return NotFound();
            }

            await _repository.DeleteCompanyAsync(id);

            return NoContent();
        }

    }
}
