using Payment.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.DTOs
{
    public class CreatePaymentDto
    {
        //public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter bigger than 0 for Amount value")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Currency code is required")]
        public string CurrencyCode { get; set; }
        public int Status { get; set; }
        public Order Order { get; set; }
    }
}
