using Claim.Domain.Entities;
using Claim.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claim.Infrastructure.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly ClaimDbContext _dbContext;
        public ClaimRepository(ClaimDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ClaimDetail> AddClaim(ClaimDetail claimDetail)
        {
            await _dbContext.Claims.AddAsync(claimDetail);
            await _dbContext.SaveChangesAsync();
            return claimDetail;
        }

        public async Task<ClaimDetail> GetClaim(int claimId)
        {
            return await _dbContext.Claims.FindAsync(claimId);
        }

        public async Task<IEnumerable<ClaimDetail>> GetClaims()
        {
            return await _dbContext.Claims.ToListAsync();
        }

        public async Task<bool> RemoveClaim(ClaimDetail claimDetail)
        {
            _dbContext.Claims.Remove(claimDetail);
            var deleted=await _dbContext.SaveChangesAsync();
            return (deleted > 0);
        }
        public async Task<(bool,ClaimDetail)> UpdateClaim(ClaimDetail claimDetail)
        {
            var existingClaim = await _dbContext.Claims
                .AsNoTracking()
                .Where(p => p.Id == claimDetail.Id)
                .FirstOrDefaultAsync();

            claimDetail.CreatedAt = existingClaim.CreatedAt;

            if (_dbContext.Entry(claimDetail).State != EntityState.Modified)
            {
                _dbContext.Entry(claimDetail).State = EntityState.Modified;
            }

            var updated = await _dbContext.SaveChangesAsync();

            return (updated > 0, claimDetail);
        }
    }
}
