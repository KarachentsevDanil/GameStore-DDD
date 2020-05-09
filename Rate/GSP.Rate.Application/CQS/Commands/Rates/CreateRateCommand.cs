using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Rate.Application.CQS.Commands.Rates
{
    public class CreateRateCommand : BaseCreateItemCommand<GetRateDto>
    {
        public long GameId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        public long AccountId { get; set; }
    }
}