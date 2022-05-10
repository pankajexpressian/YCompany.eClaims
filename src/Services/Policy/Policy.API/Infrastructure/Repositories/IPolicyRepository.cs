using Policy.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Policy.API.Infrastructure.Repositories
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<CustomerPolicy>> GetPolicies();
        Task<CustomerPolicy> GetPolicy(int policyId);
        Task<(bool, CustomerPolicy)> UpdatePolicy(CustomerPolicy customerPolicy);
        Task<bool> DoesPolicyExists(int policyId);
        Task<CustomerPolicy> AddPolicy(CustomerPolicy customerPolicy);
        Task<bool> RemovePolicy(int policyId);
    }
}
