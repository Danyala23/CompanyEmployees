using Contracts_;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EmployeeRepository(RepositoryContext repositoryContext) : RepositoryBase<Employee>(repositoryContext), IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            return await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).OrderBy(e => e.Name)
                .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
                .Take(employeeParameters.PageSize).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);
    }
}
