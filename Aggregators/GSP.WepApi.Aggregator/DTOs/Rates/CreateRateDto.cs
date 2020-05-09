namespace GSP.WepApi.Aggregator.DTOs.Rates
{
    public class CreateRateDto
    {
        public long GameId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }
    }
}