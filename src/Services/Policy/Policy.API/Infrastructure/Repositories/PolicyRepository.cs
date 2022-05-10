using Microsoft.EntityFrameworkCore;
using Policy.API.Domain.Entities;
using Policy.API.Infrastructure.Data;
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
            if (_dbContext.Entry(customerPolicy).State != EntityState.Modified)
            {
                _dbContext.Entry(customerPolicy).State = EntityState.Modified;
            }
            var updated = await _dbContext.SaveChangesAsync();
            return (updated > 0, customerPolicy);
        }
    }
}
