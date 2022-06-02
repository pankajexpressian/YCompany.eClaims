using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim.Domain.Enums
{
    public enum ClaimStatus { Draft, Submitted, ApprovalPending, Approved, Rejected }
    public enum ClaimStage { Initiated, UnderReview, ReviewComplted, ClaimAmountPaid }
}
