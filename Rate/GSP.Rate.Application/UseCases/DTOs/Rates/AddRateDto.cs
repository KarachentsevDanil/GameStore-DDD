using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Rate.Application.UseCases.DTOs.Rates
{
    public class AddRateDto : BaseAddItemDto
    {
        public long GameId { get; set; }

        public long AccountId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }
    }
}