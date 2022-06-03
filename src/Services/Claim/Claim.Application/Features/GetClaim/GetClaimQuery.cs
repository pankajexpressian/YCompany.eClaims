using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Claim.Application.Features.GetClaim
{
    public class GetClaimQuery : IRequest<IEnumerable<GetClaimResponse>>
    {
        public bool ReturnAllClaims { get; private set; } = true;
        private int _id=0;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value > 0)
                {
                    ReturnAllClaims = false;
                }
                _id = value;
            }
        }

    }
}
