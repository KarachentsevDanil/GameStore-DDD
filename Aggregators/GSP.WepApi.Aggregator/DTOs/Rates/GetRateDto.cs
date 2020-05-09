using GSP.WepApi.Aggregator.DTOs.Accoutns;
using System;

namespace GSP.WepApi.Aggregator.DTOs.Rates
{
    public class GetRateDto
    {
        public long Id { get; set; }

        public long GameId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public GetAccountDto Account { get; set; }
    }
}