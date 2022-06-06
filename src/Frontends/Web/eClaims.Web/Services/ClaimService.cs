using System.Net.Http;

namespace eClaims.Web.Services
{
    public class ClaimService : IClaimService
    {
        private readonly HttpClient _httpClient;

        public ClaimService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
