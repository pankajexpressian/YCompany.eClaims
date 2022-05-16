using Policy.API.Application.Dto;
using System.Threading.Tasks;

namespace Policy.API.Infrastructure.Services
{
    public interface ICustomerService
    {
        Task<CustomerSignupDto> Signup(CustomerSignupDto customerSignupDto);
    }
}
