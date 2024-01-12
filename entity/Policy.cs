using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAssignment.entity
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public string CoverageDetails { get; set; }

        public Policy() { }

        public Policy(int policyId, string policyNumber, string coverageDetails)
        {
            PolicyId = policyId;
            PolicyNumber = policyNumber;
            CoverageDetails = coverageDetails;
        }

        public override string ToString()
        {
            return $"Policy{{PolicyId={PolicyId}, PolicyNumber='{PolicyNumber}', CoverageDetails='{CoverageDetails}'}}";
        }
    }
}
