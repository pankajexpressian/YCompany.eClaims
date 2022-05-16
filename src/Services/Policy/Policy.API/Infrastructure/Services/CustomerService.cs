using Newtonsoft.Json;
using Policy.API.Application.Dto;
using System.Net.Http;
using System.Threading.Tasks;
using Policy.API.Extensions;
using System;

namespace Policy.API.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CustomerSignupDto> Signup(CustomerSignupDto customerSignupDto)
        {
            try
            {
                var response = await _httpClient.PostAsJson($"customers", customerSignupDto);

                if (response.IsSuccessStatusCode)
                { 
                    var signedUpCustomer=await response.ReadContentAs<CustomerSignupDto>();
                    signedUpCustomer.PolicyNumber = customerSignupDto.PolicyNumber;
                    return signedUpCustomer;
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
