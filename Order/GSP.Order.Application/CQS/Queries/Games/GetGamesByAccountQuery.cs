using GSP.Order.Application.UseCases.DTOs.Games;
using MediatR;
using System.Collections.Immutable;

namespace GSP.Order.Application.CQS.Queries.Games
{
    public class GetGamesByAccountQuery : IRequest<IImmutableList<GetGameDto>>
    {
        public long AccountId { get; set; }
    }
}