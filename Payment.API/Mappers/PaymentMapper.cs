using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.API.Mappers
{
    public class PaymentMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<PaymentMappingProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;

        });

        public static IMapper Mapper => Lazy.Value;
    }
}
