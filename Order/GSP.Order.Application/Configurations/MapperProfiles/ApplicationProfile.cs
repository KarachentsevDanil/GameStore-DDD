using AutoMapper;
using GSP.Order.Application.CQS.Commands.Games;
using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Domain.Entities;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Domain.Account.Entities;

namespace GSP.Order.Application.Configurations.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateAccountCommand, AddAccountDto>();
            CreateMap<UpdateAccountCommand, UpdateAccountDto>();
            CreateMap<SharedAccount, GetAccountDto>();

            CreateMap<CreateGameCommand, AddGameDto>();
            CreateMap<UpdateGameCommand, UpdateGameDto>();
            CreateMap<OrderGame, GetGameDto>()
                .ForMember(p => p.Id, o => o.Ignore())
                .ConstructUsing((m, mc) => mc.Mapper.Map<GetGameDto>(m.Game));
            CreateMap<Game, GetGameDto>();

            CreateMap<CreateOrderCommand, AddOrderDto>();
            CreateMap<CompleteOrderCommand, CompleteOrderDto>();
            CreateMap<AddOrderToGameCommand, OrderGameDto>();
            CreateMap<RemoveOrderToGameCommand, OrderGameDto>();
            CreateMap<OrderBase, GetOrderDto>();
        }
    }
}