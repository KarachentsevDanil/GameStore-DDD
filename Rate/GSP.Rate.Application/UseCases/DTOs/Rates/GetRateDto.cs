using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.UseCases.DTOs;
using System;

namespace GSP.Rate.Application.UseCases.DTOs.Rates
{
    public class GetRateDto : BaseGetItemDto
    {
        public long GameId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public GetAccountDto Account { get; set; }
    }
}