using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eClaims.Web.Pages.Policy
{
    public class IndexModel : PageModel
    {
        public int PolicyNumber { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int policyNumber)
        {
            return RedirectToPage("signup", new { policyNumber });
        }
    }
}
