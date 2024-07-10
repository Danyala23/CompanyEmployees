using Contracts_;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository(RepositoryContext repositoryContext) : RepositoryBase<Company>(repositoryContext), ICompanyRepository
    {
        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        }

        public Company GetCompany(Guid companyId, bool trackChanges) => 
            FindByCondition(x => x.Id.Equals(companyId), trackChanges).SingleOrDefault();

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) => 
            FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
    }
}
