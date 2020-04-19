using MediatR;

namespace GSP.Shared.Utils.Application.CQS.Queries
{
    public class BaseGetByIdQuery<TResponse> : IRequest<TResponse>
    {
        public long Id { get; set; }
    }
}