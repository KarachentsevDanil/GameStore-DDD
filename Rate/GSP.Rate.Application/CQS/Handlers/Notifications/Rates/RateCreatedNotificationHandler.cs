using GSP.Rate.Application.CQS.Bus;
using GSP.Rate.Application.CQS.Bus.Messages;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Rate.Domain.Events;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Rate.Application.CQS.Handlers.Notifications.Rates
{
    public class RateCreatedNotificationHandler : BaseNotificationHandler<RateCreatedEvent>
    {
        private readonly IRateService _rateService;

        private readonly IServiceBusClient _serviceBusClient;

        public RateCreatedNotificationHandler(
            ILogger<RateCreatedEvent> logger,
            IRateService rateService,
            IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _rateService = rateService;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task ExecuteAsync(RateCreatedEvent request, CancellationToken ct)
        {
            double averageRating = await _rateService.GetAverageRatingByGameIdAsync(request.GameId, ct);
            int countOfReviews = await _rateService.GetCountOfReviewByGameIdAsync(request.GameId, ct);

            GameRatingUpdatedMessage message = new GameRatingUpdatedMessage(request.GameId, countOfReviews, averageRating);
            await _serviceBusClient.PublishGameRatingUpdatedAsync(message);
        }
    }
}