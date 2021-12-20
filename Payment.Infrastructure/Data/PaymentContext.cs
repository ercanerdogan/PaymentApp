using Microsoft.EntityFrameworkCore;

namespace Payment.Infrastructure.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {

        }

        public DbSet<Payment.Core.Entities.Payment> Payments { get; set; }
        public DbSet<Payment.Core.Entities.Order> MyProperty { get; set; }

    }
}
