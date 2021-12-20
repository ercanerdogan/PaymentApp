using Microsoft.EntityFrameworkCore;
using Payment.Core.Entities;
using Payment.Core.Repositories.Base;
using Payment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PaymentContext _paymentContext;

        public Repository(PaymentContext paymentContext)
        {
            _paymentContext = paymentContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _paymentContext.Set<T>().AddAsync(entity);
            await _paymentContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _paymentContext.Set<T>().Remove(entity);
            await _paymentContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _paymentContext.Set<T>().Include("Order").ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            var result = await _paymentContext.Set<T>().FindAsync(Id);
            if(result is null)
            {
                return null;
            }
            await _paymentContext.Entry(result).Reference("Order").LoadAsync();

            return result;
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
