namespace RaceSetUpLibary
{
    public class RaceCarRankDetails
    {
        public RaceCarConfiguration? RaceCarConfiguration
        { get; set; }
        public double RaceCompletionTime { get; set; }
        public int Rank { get; set; }
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
