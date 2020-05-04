using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Rate.Application.UseCases.DTOs.Rates
{
    public class UpdateRateDto : BaseUpdateItemDto
    {
        public string Comment { get; set; }

        public int Rating { get; set; }

        public long AccountId { get; set; }
    }
}