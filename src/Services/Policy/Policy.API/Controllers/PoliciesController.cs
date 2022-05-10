using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Policy.API.Application.Dto;
using Policy.API.Application.Services;
using Policy.API.Domain.Entities;
using Policy.API.Infrastructure.Data;

namespace Policy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        private readonly ILogger<PoliciesController> _logger;

        public PoliciesController(IPolicyService policyService, ILogger<PoliciesController> logger)
        {
            _policyService = policyService;
            _logger = logger;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            var policies = await _policyService.GetPolicies();
            return Ok(policies);
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerPolicy(int id)
        {
            var customerPolicy = await _policyService.GetPolicy(id);

            if (customerPolicy == null)
            {
                return NotFound();
            }

            return Ok(customerPolicy);
        }

        // PUT: api/Policies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerPolicy(int id, CustomerPolicyDto customerPolicy)
        {
            if (id != customerPolicy.PolicyNumber)
            {
                return BadRequest();
            }

            if (!await _policyService.DoesPolicyExists(id))
            {
                return NotFound();
            }

            await _policyService.UpdatePolicy(customerPolicy);

            return NoContent();
        }

        // POST: api/Policies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerPolicyDto>> PostCustomerPolicy(CustomerPolicyDto customerPolicy)
        {

            var newPolicy = await _policyService.AddPolicy(customerPolicy);

            return CreatedAtAction("GetCustomerPolicy", new { id = newPolicy.PolicyNumber }, newPolicy);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerPolicy(int id)
        {
            if (!await _policyService.DoesPolicyExists(id))
            {
                return NotFound();
            }

            await _policyService.RemovePolicy(id);

            return NoContent();
        }
    }
}
