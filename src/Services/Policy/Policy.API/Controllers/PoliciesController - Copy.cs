using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Policy.API.Domain.Entities;
using Policy.API.Infrastructure.Data;

namespace Policy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesCController : ControllerBase
    {
        private readonly PolicyContext _context;

        public PoliciesCController(PolicyContext context)
        {
            _context = context;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerPolicy>>> GetPolicies()
        {
            return await _context.Policies.ToListAsync();
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerPolicy>> GetCustomerPolicy(int id)
        {
            var customerPolicy = await _context.Policies.FindAsync(id);

            if (customerPolicy == null)
            {
                return NotFound();
            }

            return customerPolicy;
        }

        // PUT: api/Policies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerPolicy(int id, CustomerPolicy customerPolicy)
        {
            if (id != customerPolicy.PolicyNumber)
            {
                return BadRequest();
            }

            _context.Entry(customerPolicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerPolicyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Policies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerPolicy>> PostCustomerPolicy(CustomerPolicy customerPolicy)
        {
            _context.Policies.Add(customerPolicy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerPolicy", new { id = customerPolicy.PolicyNumber }, customerPolicy);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerPolicy(int id)
        {
            var customerPolicy = await _context.Policies.FindAsync(id);
            if (customerPolicy == null)
            {
                return NotFound();
            }

            _context.Policies.Remove(customerPolicy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerPolicyExists(int id)
        {
            return _context.Policies.Any(e => e.PolicyNumber == id);
        }
    }
}
