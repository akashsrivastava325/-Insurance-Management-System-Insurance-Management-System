using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAssignment.entity
{
    public class Claim
    {
        private int ClaimId { get; set; }
        private string ClaimNumber { get; set; }
        private string DateFiled { get; set; }
        private double ClaimAmount { get; set; }
        private string Status { get; set; }
        private string Policy { get; set; }
        private int ClientId { get; set; }

        public Claim() { }

        public Claim(int claimId, string claimNumber, string dateFiled, double claimAmount, string status,
                     string policy, int clientId)
        {
            ClaimId = claimId;
            ClaimNumber = claimNumber;
            DateFiled = dateFiled;
            ClaimAmount = claimAmount;
            Status = status;
            Policy = policy;
            ClientId = clientId;
        }

        public override string ToString()
        {
            return $"Claim{{ClaimId={ClaimId}, ClaimNumber='{ClaimNumber}', DateFiled='{DateFiled}', ClaimAmount={ClaimAmount}, Status='{Status}', Policy='{Policy}', ClientId={ClientId}}}";
        }

    }
}
