namespace Services.DTO
{
    public class TestersStatisticsDto
    {
        public string TesterName { get; set; }
        public int TestsInProgress { get; set; }
        public int TestsFailed { get; set; }
        public int TestsPassed { get; set; }
        public int TestsNotStarted { get; set; }
    }
}
