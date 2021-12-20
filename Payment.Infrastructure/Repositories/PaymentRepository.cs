using Microsoft.EntityFrameworkCore;
using Payment.Core.Repositories;
using Payment.Infrastructure.Data;
using Payment.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    public class PaymentRepository : Repository<Payment.Core.Entities.Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentContext paymentContext) : base(paymentContext)
        {
        }

        public async Task<Core.Entities.Payment> GetLastPayment()
        {
            Core.Entities.Payment lastPayment = await _paymentContext.Payments
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();


            return lastPayment;
        }
    }
}
