using AutoMapper;
using Customer.API.Application.Dto;
using Customer.API.Application.Services;
using Customer.API.Domain.Entities;
using Customer.API.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Inrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CustomerDetailDto> AddCustomer(CustomerDetailDto customerDetailDto)
        {
            var customerToAdd=_mapper.Map<CustomerDetail>(customerDetailDto);
            var addedCustomer=await _customerRepository.AddCustomer(customerToAdd);
            return _mapper.Map<CustomerDetailDto>(addedCustomer);
        }

        public async Task<bool> DoesCustomerExists(int customerId)
        {
            return await _customerRepository.DoesCustomerExists(customerId);
        }

        public async Task<CustomerDetailDto> GetCustomer(int customerId)
        {
            var customer = await _customerRepository.GetCustomer(customerId);
            return  _mapper.Map<CustomerDetailDto>(customer);
        }

        public async Task<IEnumerable<CustomerDetailDto>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            return _mapper.Map<IEnumerable<CustomerDetailDto>>(customers);
        }

        public async Task<bool> RemoveCustomer(int customerId)
        {
            return await _customerRepository.RemoveCustomer(customerId);
        }

        public async Task<(bool, CustomerDetailDto)> UpdateCustomer(CustomerDetailDto customerDetailDto)
        {
            var customerToUpdate = _mapper.Map<CustomerDetail>(customerDetailDto);
            var updatedCustomer = await _customerRepository.UpdateCustomer(customerToUpdate);
            return (updatedCustomer.Item1, _mapper.Map<CustomerDetailDto>(updatedCustomer.Item2));
        }
    }
}
