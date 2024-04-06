namespace TrendGraphix.Indicators
{
    public class Fill
    {
        public Fill(string serieA, string serieB) 
        {
            SerieA = serieA;
            SerieB = serieB;
        }

        public string SerieA { get; }

        public string SerieB { get; }
    }
}