using eClaims.Web.Models;
using eClaims.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace eClaims.Web.Pages.Policy
{
    public class SignupModel : PageModel
    {
        private readonly PolicyService _policyService;
        public PolicyModel Policy { get; set; }
        public SignupModel(PolicyService policyService)
        {
            _policyService = policyService;
        }

        public async Task<IActionResult> OnGet(int policyNumber)
        {
            ViewData["Message"] = string.Empty;
            Policy = await _policyService.GetPolicyById(policyNumber);
            if (Policy == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(CustomerSignupDto model)
        {
            var res = await _policyService.SignupCustomer(model);

            Policy = await _policyService.GetPolicyById(res.PolicyNumber);

            if (Policy.SignedUpAlready && Policy.CustomerId > 0)
            {
                ViewData["Message"] = $"You have successfully signed up. Your customer id is {Policy.CustomerId}";
            }
            return Page();
        }
    }


}
