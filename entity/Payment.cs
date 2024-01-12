using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAssignment.entity
{
    public class Payment
    {
        private int PaymentId { get; set; }
        private string PaymentDate { get; set; }
        private double PaymentAmount { get; set; }
        private int ClientId { get; set; }

        public Payment() { }

        public Payment(int paymentId, string paymentDate, double paymentAmount, int clientId)
        {
            PaymentId = paymentId;
            PaymentDate = paymentDate;
            PaymentAmount = paymentAmount;
            ClientId = clientId;
        }

        public override string ToString()
        {
            return $"Payment{{PaymentId={PaymentId}, PaymentDate='{PaymentDate}', PaymentAmount={PaymentAmount}, ClientId={ClientId}}}";
        }

    }
}
