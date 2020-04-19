using MediatR;

namespace GSP.Shared.Utils.Application.CQS.Commands
{
    public class BaseUpdateItemCommand<TResponse> : IRequest<TResponse>
    {
        public long Id { get; set; }
    }
}