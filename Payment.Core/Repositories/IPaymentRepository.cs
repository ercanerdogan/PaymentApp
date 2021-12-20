using Payment.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Repositories
{
    public interface IPaymentRepository : IRepository<Payment.Core.Entities.Payment>
    {
        Task<Payment.Core.Entities.Payment> GetLastPayment();
    }
}
