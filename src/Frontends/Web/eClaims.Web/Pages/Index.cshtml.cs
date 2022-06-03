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
        private readonly PolicyService apiGatewayClient;

        public IndexModel(ILogger<IndexModel> logger, PolicyService apiGatewayClient)
        {
            _logger = logger;
            this.apiGatewayClient = apiGatewayClient;
        }

        public void OnGet()
        {

        }
    }
}
