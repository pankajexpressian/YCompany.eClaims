using Policy.API.Application.Dto;
using Policy.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Policy.API.Application.Services
{
    public interface IPolicyService
    {
        Task<IEnumerable<ReadPolicyDto>> GetPolicies();
        Task<ReadPolicyDto> GetPolicy(int policyId);
        Task<(bool, ReadPolicyDto)> UpdatePolicy(UpdatePolicyDto updatePolicyDto);
        Task<bool> DoesPolicyExists(int policyId);
        Task<ReadPolicyDto> AddPolicy(CreatePolicyDto createPolicyDto);
        Task<bool> RemovePolicy(int policyId);
        Task<(bool, CustomerSignupDto)> SignupCustomer(CustomerSignupDto customerSignupDto);
    }
}
