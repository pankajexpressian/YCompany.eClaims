using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eClaims.Web.Models
{
    public class PolicyModel
    {
        public int PolicyNumber { get; set; }
        public int CustomerId { get; set; }
        public string IssuedOn { get; set; }
        public string StartsOn { get; set; }
        public string ExpiresOn { get; set; }
        public int PolicyType { get; set; }
        public int PolicyStatus { get; set; }
        public bool SignedUpAlready { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedAt { get; protected set; }
    }

    public class PolicyListModel
    {
        public IEnumerable<PolicyModel> Policies { get; set; }
    }
}
