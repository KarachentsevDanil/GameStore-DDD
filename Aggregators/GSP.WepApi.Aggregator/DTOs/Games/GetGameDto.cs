namespace GSP.WepApi.Aggregator.DTOs.Games
{
    public class GetGameDto
    {
        public long Id { get; set; }

        public GameDetailsDto GameDetails { get; set; }
    }
}