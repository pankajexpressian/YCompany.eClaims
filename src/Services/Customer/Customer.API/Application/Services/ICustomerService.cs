using Customer.API.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Application.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDetailDto>> GetCustomers();
        Task<CustomerDetailDto> GetCustomer(int customerId);
        Task<(bool, CustomerDetailDto)> UpdateCustomer(CustomerDetailDto customerDetailDto);
        Task<bool> DoesCustomerExists(int customerId);
        Task<CustomerDetailDto> AddCustomer(CustomerDetailDto customerDetailDto);
        Task<bool> RemoveCustomer(int customerId);
    }
}
