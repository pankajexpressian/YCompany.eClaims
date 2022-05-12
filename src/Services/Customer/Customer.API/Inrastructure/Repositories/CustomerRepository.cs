using Customer.API.Domain.Entities;
using Customer.API.Inrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _dbContext;

        public CustomerRepository(CustomerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerDetail> AddCustomer(CustomerDetail customerDetail)
        {
            _dbContext.Customers.Add(customerDetail);
            await _dbContext.SaveChangesAsync();
            return customerDetail;
        }

        public async Task<bool> DoesCustomerExists(int customerId)
        {
            var customer = await GetCustomer(customerId);
            return customer != null ? true : false;
        }

        public async Task<IEnumerable<CustomerDetail>> GetCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<CustomerDetail> GetCustomer(int customerId)
        {
            return await _dbContext.Customers
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.CustomerId == customerId);
        }

        public async Task<bool> RemoveCustomer(int customerId)
        {
            var customer = await GetCustomer(customerId);
            _dbContext.Customers.Remove(customer);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<(bool, CustomerDetail)> UpdateCustomer(CustomerDetail customerDetail)
        {
            var existingCustomer = await _dbContext.Customers
                .AsNoTracking()
                .Where(p => p.CustomerId == customerDetail.CustomerId)
                .FirstOrDefaultAsync();
            
            customerDetail.CreatedAt = existingCustomer.CreatedAt;

            if (_dbContext.Entry(customerDetail).State != EntityState.Modified)
            {
                _dbContext.Entry(customerDetail).State = EntityState.Modified;
            }

            var updated = await _dbContext.SaveChangesAsync();
            return (updated > 0, customerDetail);
        }
    }
}
