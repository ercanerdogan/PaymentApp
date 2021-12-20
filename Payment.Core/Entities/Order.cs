using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Entities
{
    public class Order : BaseEntity
    {
        [Required(ErrorMessage = "Consumer name is required")]
        public string ConsumerFullName { get; set; }
        [Required(ErrorMessage = "Consumer address is required")]
        public string ConsumerAddress { get; set; }
    }
}
