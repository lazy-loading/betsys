namespace BettingSystem.Services
{
    public class BetRequest
    {
        public string UserId { get; set; }

        public int SelectionId { get; set; }

        public decimal BetValue { get; set; }
    }
}