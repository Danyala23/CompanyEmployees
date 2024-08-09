using Contracts_;
using Entities;


namespace Repository
{
    public class RepositoryManager(RepositoryContext repositoryContext) : IRepositoryManager
    {
        private RepositoryContext _repositoryContext = repositoryContext
;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;

        public ICompanyRepository Company {  
            get {
                _companyRepository ??= new CompanyRepository(_repositoryContext);
                return _companyRepository; 
            } 
        }

        public IEmployeeRepository Employee
        {
            get
            {
                _employeeRepository ??= new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
