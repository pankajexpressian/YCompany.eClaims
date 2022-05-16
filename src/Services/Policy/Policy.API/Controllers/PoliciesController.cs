using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        //TODO - change response type of all the action methods below and for the customers service.
        //TODO - Customer service dosn't have dedicated dtos for CRUD, add them
        // GET: api/Policies

        #region[GET ALL POLICIES]
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ApiResponse> GetPolicies()
        {
            var policies = await _policyService.GetPolicies();
            if (policies != null)
                return BuildResponse(ApiResponseConstants.SuccessStatusCode,
                    ApiResponseConstants.SuccessStatus,
                    String.Empty,
                    policies);

            return BuildResponse(ApiResponseConstants.NotFoundStatusCode,
                ApiResponseConstants.SuccessStatus,
                "No policies found");
        }
        #endregion

        #region[GET POLICY BY POLICY NUMBER]
        [HttpGet("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerPolicy(int id)
        {
            var customerPolicy = await _policyService.GetPolicy(id);

            if (customerPolicy == null)
            {
                return NotFound();
            }

            return Ok(customerPolicy);
        }
        #endregion

        #region[UPDATE POLICY]
        [HttpPut("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutCustomerPolicy(int id, UpdatePolicyDto updatePolicyDto)
        {
            if (id != updatePolicyDto.PolicyNumber)
            {
                return BadRequest();
            }

            if (!await _policyService.DoesPolicyExists(id))
            {
                return NotFound();
            }

            await _policyService.UpdatePolicy(updatePolicyDto);

            return NoContent();
        }
        #endregion

        #region[CREATE POLICY]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostCustomerPolicy(CreatePolicyDto createPolicyDto)
        {

            var newPolicy = await _policyService.AddPolicy(createPolicyDto);

            return CreatedAtAction("GetCustomerPolicy", new { id = newPolicy.PolicyNumber }, newPolicy);
        }
        #endregion

        #region[DELETE POLICY]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomerPolicy(int id)
        {
            if (!await _policyService.DoesPolicyExists(id))
            {
                return NotFound();
            }

            await _policyService.RemovePolicy(id);

            return NoContent();
        }
        #endregion

        #region[POST-SIGN UP CUSTOMER BY POLICY NUMBER]
        [HttpPut("{id}/Signup")]
        public async Task<IActionResult> Signup(int id, CustomerSignupDto customerSignupDto)
        {
            if (!await _policyService.DoesPolicyExists(id))
            {
                return NotFound();
            }

            var added = await _policyService.SignupCustomer(customerSignupDto);

            if (added.Item1) return Ok(added.Item2);

            return Ok(added.Item1);
        }
        #endregion

        private ApiResponse BuildResponse(string statusCode, string status, string message, dynamic data = null)
        {
            var metaData = new ApiResponseMetaData()
            {
                Staus = status,
                StausCode = statusCode,
                Message = message
            };
            var response = new ApiResponse()
            {
                Data = data,
                MetaData = metaData
            };

            return response;
        }
    }
}
