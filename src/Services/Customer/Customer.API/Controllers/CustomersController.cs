using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Customer.API.Application.Services;
using Customer.API.Application.Dto;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _customerService.GetCustomers());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetail(int id)
        {
            var customerDetail = await _customerService.GetCustomer(id);

            if (customerDetail == null)
            {
                return NotFound();
            }
            return Ok(customerDetail);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetail(int id, CustomerDetailDto customerDetailDto)
        {
            if (id != customerDetailDto.CustomerId)
            {
                return BadRequest();
            }

            var updatedCustomer = await _customerService.UpdateCustomer(customerDetailDto);
            if (updatedCustomer.Item1) return Ok(updatedCustomer.Item2);

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCustomerDetail(CustomerDetailDto customerDetailDto)
        {
            var addedCustomer = await _customerService.AddCustomer(customerDetailDto);

            return CreatedAtAction("GetCustomerDetail", new { id = addedCustomer.CustomerId }, addedCustomer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetail(int id)
        {
            var deleted=await _customerService.RemoveCustomer(id);
            return NoContent();
        }
    }
}
