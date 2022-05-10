using AutoMapper;
using Policy.API.Application.Dto;
using Policy.API.Application.Services;
using Policy.API.Domain.Entities;
using Policy.API.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Policy.API.Infrastructure.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IMapper _mapper;
        public PolicyService(IPolicyRepository policyRepository, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
        }
        public async Task<CustomerPolicyDto> AddPolicy(CustomerPolicyDto customerPolicy)
        {
            var policyToAdd = _mapper.Map<CustomerPolicy>(customerPolicy);
            var newlyAddedPolicy = await _policyRepository.AddPolicy(policyToAdd);
            return _mapper.Map<CustomerPolicyDto>(newlyAddedPolicy);
        }

        public async Task<bool> DoesPolicyExists(int policyId)
        {
            return await _policyRepository.DoesPolicyExists(policyId);
        }

        public async Task<IEnumerable<CustomerPolicyDto>> GetPolicies()
        {
            var policies = await _policyRepository.GetPolicies();
            var policiesToReturn = _mapper.Map<IEnumerable<CustomerPolicyDto>>(policies);
            return policiesToReturn;
        }

        public async Task<CustomerPolicyDto> GetPolicy(int policyId)
        {
            var policy = await _policyRepository.GetPolicy(policyId);
            var policyToReturn = _mapper.Map<CustomerPolicyDto>(policy);
            return policyToReturn;
        }

        public Task<bool> RemovePolicy(int policyId)
        {
            return _policyRepository.RemovePolicy(policyId);
        }

        public async Task<(bool, CustomerPolicyDto)> UpdatePolicy(CustomerPolicyDto customerPolicy)
        {
            var policyToUpdate = _mapper.Map<CustomerPolicy>(customerPolicy);
            var updatedPolicy = await _policyRepository.UpdatePolicy(policyToUpdate);
            return (updatedPolicy.Item1, _mapper.Map<CustomerPolicyDto>(updatedPolicy.Item2));
        }
    }
}
