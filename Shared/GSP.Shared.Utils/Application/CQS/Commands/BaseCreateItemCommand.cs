using MediatR;

namespace GSP.Shared.Utils.Application.CQS.Commands
{
    public class BaseCreateItemCommand<TResponse> : IRequest<TResponse>
    {
    }
}