using CommunityToolkit.Mvvm.ComponentModel;
using ScottPlot;
using ScottPlot.Plottables;

namespace TrendGraphix
{
    public class StockChart 
    {
        #region private fields
        private OhlcPlot _holcPlot;
        private CandlestickPlot _candlestickPlot;
        private Scatter _linePlot;
        private Scatter _dotPlot;
        #endregion
        public StockChart() 
        { 
            Init();
        }
       
        private void Init()
        {
            CandlesDatas = ScottPlot.Generate.RandomOHLCs(450);
            PricePlot.Axes.DateTimeTicksBottom();

            _holcPlot = PricePlot.Add.OHLC(CandlesDatas); 
            _holcPlot.Axes.YAxis = PricePlot.Axes.Right;
            _holcPlot.FallingStyle.Width = 1;
            _holcPlot.RisingStyle.Width = 1;
            _holcPlot.IsVisible = true;

            _candlestickPlot = PricePlot.Add.Candlestick(CandlesDatas);
            _candlestickPlot.Axes.YAxis = PricePlot.Axes.Right;
            _candlestickPlot.FallingLineStyle.Width = 1;
            _candlestickPlot.RisingLineStyle.Width = 1;
            _candlestickPlot.IsVisible = false;

            _linePlot = PricePlot.Add.Scatter(CandlesDatas.Select(x => x.DateTime).ToList(), CandlesDatas.Select(x=> x.Close).ToList());
            _linePlot.Axes.YAxis = PricePlot.Axes.Right;
            _linePlot.MarkerStyle.IsVisible = false;
            _linePlot.IsVisible = false;

            _dotPlot = PricePlot.Add.Scatter(CandlesDatas.Select(x => x.DateTime).ToList(), CandlesDatas.Select(x => x.Close).ToList());
            _dotPlot.Axes.YAxis = PricePlot.Axes.Right;
            _dotPlot.LineStyle.IsVisible = false;
            _dotPlot.IsVisible = false;
        }

        #region public fields
        public Plot PricePlot { get; private set; } = new Plot();

        public List<OHLC> CandlesDatas { get; private set;} = new List<OHLC>();


        #endregion
    } 
}

