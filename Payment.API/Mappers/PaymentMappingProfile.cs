using AutoMapper;
using Payment.API.DTOs;
using Payment.API.Responses;

namespace Payment.API.Mappers
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<Payment.Core.Entities.Payment, PaymentResponse>().ReverseMap();
            CreateMap<Payment.Core.Entities.Payment, CreatePaymentDto>().ReverseMap();
        }
    }
}
