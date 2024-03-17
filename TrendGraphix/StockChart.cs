using ScottPlot;

namespace TrendGraphix
{
    public class StockChart
    {
        public StockChart() 
        {
            Plot = new Plot();
            Setup();
        }
        public Plot Plot { get; private set; }

        private void Setup()
        {
            var candles = ScottPlot.Generate.RandomOHLCs(1200);
            var plot = Plot.Add.Candlestick(candles);
            Plot.Axes.DateTimeTicksBottom();

            plot.Axes.YAxis = Plot.Axes.Right;
            plot.Sequential = false;
            plot.FallingLineStyle.Width = 1;
            plot.RisingLineStyle.Width = 1;
        }
    }
}

