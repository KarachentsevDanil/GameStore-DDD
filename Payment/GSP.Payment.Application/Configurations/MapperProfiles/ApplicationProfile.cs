using AutoMapper;
using GSP.Payment.Application.CQS.Commands.PaymentHistories;
using GSP.Payment.Application.CQS.Commands.PaymentMethods;
using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;
using GSP.Payment.Domain.Entities;

namespace GSP.Payment.Application.Configurations.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreatePaymentHistoryCommand, AddPaymentHistoryDto>();
            CreateMap<PaymentHistory, GetPaymentHistoryDto>();

            CreateMap<CreatePaymentMethodCommand, AddPaymentMethodDto>();
            CreateMap<PaymentMethod, GetPaymentMethodDto>();
        }
    }
}