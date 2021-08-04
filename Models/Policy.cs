using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poc.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string policyType { get; set; }
        public string coverName { get; set; }
        public string premium { get; set; }
        public string sumInsured { get; set; }
        public string coverUpto { get; set; }
        public string description { get; set; }
        public string termsConditions { get; set; }
        public string email { get; set; }

    }
}
