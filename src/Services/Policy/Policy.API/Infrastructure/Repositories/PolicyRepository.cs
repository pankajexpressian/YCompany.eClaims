using Microsoft.EntityFrameworkCore;
using Policy.API.Application.Dto;
using Policy.API.Domain.Entities;
using Policy.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.API.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly PolicyContext _dbContext;

        public PolicyRepository(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerPolicy> AddPolicy(CustomerPolicy customerPolicy)
        {
            _dbContext.Policies.Add(customerPolicy);
            await _dbContext.SaveChangesAsync();
            return customerPolicy;
        }

        public async Task<bool> DoesPolicyExists(int policyId)
        {
            var policy = await GetPolicy(policyId);
            return policy != null ? true : false;
        }

        public async Task<IEnumerable<CustomerPolicy>> GetPolicies()
        {
            return await _dbContext.Policies.ToListAsync();
        }

        public async Task<CustomerPolicy> GetPolicy(int policyId)
        {
            return await _dbContext.Policies
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PolicyNumber == policyId);
        }

        public async Task<bool> RemovePolicy(int policyId)
        {
            var policy = await GetPolicy(policyId);
            _dbContext.Policies.Remove(policy);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<(bool, CustomerPolicy)> UpdatePolicy(CustomerPolicy customerPolicy)
        {
            var existingPolicy = await _dbContext.Policies
                .AsNoTracking()
                .Where(p => p.PolicyNumber == customerPolicy.PolicyNumber)
                //.Include(p => p.CreatedAt)
                .FirstOrDefaultAsync();

            customerPolicy.CreatedAt = existingPolicy.CreatedAt;

            if (_dbContext.Entry(customerPolicy).State != EntityState.Modified)
            {
                _dbContext.Entry(customerPolicy).State = EntityState.Modified;
            }

            var updated = await _dbContext.SaveChangesAsync();

            return (updated > 0, customerPolicy);
        }


        public async Task<(bool, CustomerPolicy)> UpdatePolicySignupDetails(CustomerPolicy customerPolicy)
        {
            var existingPolicy = await _dbContext.Policies
                .Where(p => p.PolicyNumber == customerPolicy.PolicyNumber)
                .FirstOrDefaultAsync();

            if (existingPolicy == null)
            {
                return (false, existingPolicy);
            }

            if (!existingPolicy.SignedUpAlready && !(existingPolicy.CustomerId > 0))
            {
                //existingPolicy.CreatedAt = existingPolicy.CreatedAt;
                existingPolicy.CustomerId = customerPolicy.CustomerId;
                existingPolicy.SignedUpAlready = customerPolicy.SignedUpAlready;
                existingPolicy.DOB = customerPolicy.DOB;

                if (_dbContext.Entry(existingPolicy).State != EntityState.Modified)
                {
                    _dbContext.Entry(existingPolicy).State = EntityState.Modified;
                }

                var updated = await _dbContext.SaveChangesAsync();

                return (true, existingPolicy);
            }

            return (false, existingPolicy);
        }
    }
}
