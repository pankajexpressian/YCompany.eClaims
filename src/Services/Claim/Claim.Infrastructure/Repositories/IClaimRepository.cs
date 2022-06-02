using Claim.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim.Infrastructure.Repositories
{
    public interface IClaimRepository
    {
        Task<ClaimDetail> AddClaim(ClaimDetail claimDetail);
        Task<(bool, ClaimDetail)> UpdateClaim(ClaimDetail claimDetail);
        Task<bool> RemoveClaim(ClaimDetail claimDetail);
        Task<IEnumerable<ClaimDetail>> GetClaims();
        Task<ClaimDetail> GetClaim(int claimId);
    }
}
