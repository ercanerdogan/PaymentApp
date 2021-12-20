using Payment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.API.Responses
{
    public class PaymentResponse
    {
        //public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public int Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int Status { get; set; } 

        public Order Order { get; set; }
    }
}
