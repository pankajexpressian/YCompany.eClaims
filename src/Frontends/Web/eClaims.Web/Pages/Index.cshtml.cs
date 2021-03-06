using eClaims.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eClaims.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public int PolicyNumber { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
           
        }

        public IActionResult OnGet()
        {
            return Page();
        }

    }
}
