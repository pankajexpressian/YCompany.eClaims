using eClaims.Web.Extensions;
using eClaims.Web.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using eClaims.Web.Extensions;

namespace eClaims.Web.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PolicyService> _logger;

        public PolicyService(HttpClient httpClient, ILogger<PolicyService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<PolicyModel>> GetAllPolicies()
        {
            IEnumerable<PolicyModel> policies = null;
            try
            {
                string url = "policies";
                var response = await _httpClient.GetAsync(url);
                policies = await response.ReadContentAs<IEnumerable<PolicyModel>>();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Something went wrong when calling Policies service", ex);
            }

            return policies;
        }

        public async Task<PolicyModel> GetPolicyById(int id)
        {
            PolicyModel policy = null;
            try
            {
                string url = $"policies/{id}";
                var response = await _httpClient.GetAsync(url);
                policy = await response.ReadContentAs<PolicyModel>();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Something went wrong when calling Policies service", ex);
            }

            return policy;
        }

        public async Task<CustomerSignupDto> SignupCustomer(CustomerSignupDto dto)
        {
            CustomerSignupDto result = null;
            try
            {
                string url = $"policies/{dto.PolicyNumber}/Signup";
                var response = await _httpClient.PutAsJson(url,dto);
                result = await response.ReadContentAs<CustomerSignupDto>();
               
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Something went wrong when calling Policies service", ex);
            }

            return result;
        }

    }
}
