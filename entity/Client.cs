using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAssignment.entity
{
    public class Client
    {
        private int ClientId { get; set; }
        private string ClientName { get; set; }
        private string ContactInfo { get; set; }
        private string Policy { get; set; }

        public Client() { }

        public Client(int clientId, string clientName, string contactInfo, string policy)
        {
            ClientId = clientId;
            ClientName = clientName;
            ContactInfo = contactInfo;
            Policy = policy;
        }

        public int GetClientId()
        {
            return ClientId;
        }

        public string GetClientName()
        {
            return ClientName;
        }

        public string GetContactInfo()
        {
            return ContactInfo;
        }

        public string GetPolicy()
        {
            return Policy;
        }

        public override string ToString()
        {
            return $"Client{{ClientId={ClientId}, ClientName='{ClientName}', ContactInfo='{ContactInfo}', Policy='{Policy}'}}";
        }
    }
}
