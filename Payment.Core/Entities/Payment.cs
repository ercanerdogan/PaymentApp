using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Entities
{
    public class Payment : BaseEntity
    {
        public DateTime CreationDate { get; set; }
        
        public int Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int Status { get; set; } //TODO : Create an Enum for this.
        public Order Order { get; set; }
    }
}
