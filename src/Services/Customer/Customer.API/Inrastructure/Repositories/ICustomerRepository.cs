using Customer.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDetail>> GetCustomers();
        Task<CustomerDetail> GetCustomer(int customerId);
        Task<(bool, CustomerDetail)> UpdateCustomer(CustomerDetail customerDetail);
        Task<bool> DoesCustomerExists(int customerId);
        Task<CustomerDetail> AddCustomer(CustomerDetail customerDetail);
        Task<bool> RemoveCustomer(int customerId);
    }
}
