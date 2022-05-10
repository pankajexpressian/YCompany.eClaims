using Policy.API.Application.Dto;
using Policy.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Policy.API.Application.Services
{
    public interface IPolicyService
    {
        Task<IEnumerable<CustomerPolicyDto>> GetPolicies();
        Task<CustomerPolicyDto> GetPolicy(int policyId);
        Task<(bool, CustomerPolicyDto)> UpdatePolicy(CustomerPolicyDto customerPolicy);
        Task<bool> DoesPolicyExists(int policyId);
        Task<CustomerPolicyDto> AddPolicy(CustomerPolicyDto customerPolicy);
        Task<bool> RemovePolicy(int policyId);
    }
}
