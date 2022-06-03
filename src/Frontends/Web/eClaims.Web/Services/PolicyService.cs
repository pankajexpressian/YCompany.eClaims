using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace eClaims.Web.Services
{
    public class PolicyService
    {
        private readonly HttpClient _httpClient;

        public PolicyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetPolicies(int policyId = 0)
        {
            try
            {
                string url = "policies";
                if (policyId > 0)
                {
                    url = $"policies/{policyId}";
                }

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var res= await response.Content.ReadAsStringAsync();
                    return res;
                }
                else
                {
                    throw new Exception("Something went wrong when calling api.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Something went wrong when calling api.", ex);
            }
        }
    }
}
