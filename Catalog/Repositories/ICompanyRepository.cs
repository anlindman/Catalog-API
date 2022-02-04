using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyAsync(Guid id);
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task CreateCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(Guid id);
    }
}
