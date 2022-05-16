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
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public PolicyService(IPolicyRepository policyRepository, IMapper mapper, ICustomerService customerService)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
            _customerService = customerService;
        }
        public async Task<ReadPolicyDto> AddPolicy(CreatePolicyDto createPolicyDto)
        {
            var policyToAdd = _mapper.Map<CustomerPolicy>(createPolicyDto);
            var newlyAddedPolicy = await _policyRepository.AddPolicy(policyToAdd);
            return _mapper.Map<ReadPolicyDto>(newlyAddedPolicy);
        }

        public async Task<bool> DoesPolicyExists(int policyId)
        {
            return await _policyRepository.DoesPolicyExists(policyId);
        }

        public async Task<IEnumerable<ReadPolicyDto>> GetPolicies()
        {
            var policies = await _policyRepository.GetPolicies();
            var policiesToReturn = _mapper.Map<IEnumerable<ReadPolicyDto>>(policies);
            return policiesToReturn;
        }

        public async Task<ReadPolicyDto> GetPolicy(int policyId)
        {
            var policy = await _policyRepository.GetPolicy(policyId);
            var policyToReturn = _mapper.Map<ReadPolicyDto>(policy);
            return policyToReturn;
        }

        public Task<bool> RemovePolicy(int policyId)
        {
            return _policyRepository.RemovePolicy(policyId);
        }


        public async Task<(bool, ReadPolicyDto)> UpdatePolicy(UpdatePolicyDto UpdatePolicyDto)
        {
            var policyToUpdate = _mapper.Map<CustomerPolicy>(UpdatePolicyDto);
            var updatedPolicy = await _policyRepository.UpdatePolicy(policyToUpdate);
            return (updatedPolicy.Item1, _mapper.Map<ReadPolicyDto>(updatedPolicy.Item2));
        }
        public async Task<(bool, CustomerSignupDto)> SignupCustomer(CustomerSignupDto customerSignupDto)
        {
            var signedupCustomer = await _customerService.Signup(customerSignupDto);

            if (signedupCustomer.CustomerId > 0)
            {
                var customerPolicy = _mapper.Map<CustomerPolicy>(signedupCustomer);
                
                var updatedPolicySignupDetails = await _policyRepository.UpdatePolicySignupDetails(customerPolicy);

                if (updatedPolicySignupDetails.Item1)
                {
                    return (true, signedupCustomer);
                }
            }

            return (false, customerSignupDto);

        }
    }
}
