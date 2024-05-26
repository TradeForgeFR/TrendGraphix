using CommunityToolkit.Mvvm.ComponentModel;
using ScottPlot;
using ScottPlot.Plottables;

namespace TrendGraphix.Models
{
    public enum ChartType : int
    {
        Candlestick = 0,
        OHLC = 1,
        Line = 2,
        Dot = 3
    }
    public class StockChartModel
    {
        #region private fields
        private OhlcPlot _holcPlot;
        private CandlestickPlot _candlestickPlot;
        private Scatter _linePlot;
        private Scatter _dotPlot;
        ChartType _chartType = ChartType.Line;
        #endregion
        public StockChartModel()
        {
            Init();
        }

        private void Init()
        {
            PriceDatas.AddRange(Generate.RandomOHLCs(2000).Select(x => new PriceModel()
            {
                Open = x.Open,
                High = x.High,
                Low = x.Low,
                Close = x.Close,
                Time = x.DateTime
            }));

            PricePlot.Axes.DateTimeTicksBottom();

            _holcPlot = PricePlot.Add.OHLC(PriceDatas.Select(x => new OHLC()
            {
                DateTime = x.Time,
                Open = x.Open,
                High = x.High,
                Low = x.Low,
                Close = x.Close,
            }).ToList());

            _holcPlot.Axes.YAxis = PricePlot.Axes.Right;
           // _holcPlot.FallingStyle.Width = 1;
          //  _holcPlot.RisingStyle.Width = 1;
            _holcPlot.IsVisible = false;

            _candlestickPlot = PricePlot.Add.Candlestick(PriceDatas.Select(x => new OHLC()
            {
                DateTime = x.Time,
                Open = x.Open,
                High = x.High,
                Low = x.Low,
                Close = x.Close,
            }).ToList());


            _candlestickPlot.Axes.YAxis = PricePlot.Axes.Right;
             _candlestickPlot.FallingLineStyle.Width = 1;
             _candlestickPlot.RisingLineStyle.Width = 1;
           // _candlestickPlot.IsVisible = false;

            _linePlot = PricePlot.Add.Scatter(PriceDatas.Select(x => x.Time).ToList(), PriceDatas.Select(x => x.Close).ToList());
            _linePlot.Axes.YAxis = PricePlot.Axes.Right;
            _linePlot.MarkerStyle.IsVisible = false;
            _linePlot.IsVisible = false;

            _dotPlot = PricePlot.Add.Scatter(PriceDatas.Select(x => x.Time).ToList(), PriceDatas.Select(x => x.Close).ToList());
            _dotPlot.Axes.YAxis = PricePlot.Axes.Right;
            _dotPlot.LineStyle.IsVisible = false;
            _dotPlot.IsVisible = false;
        }

        #region public fields
        public Plot PricePlot { get; private set; } = new Plot();
        public PriceListModel PriceDatas { get; private set; } = new PriceListModel();
        public ChartType ChartType
        {
            get
            {
                return _chartType;
            }
            set
            {
                _chartType = value;
               /* _holcPlot.IsVisible = _chartType == ChartType.OHLC;
                _candlestickPlot.IsVisible = _chartType == ChartType.Candlestick;
                _linePlot.IsVisible = _chartType == ChartType.Line;
                _dotPlot.IsVisible = _chartType == ChartType.Dot;*/

                PricePlot.RenderInMemory();
            }
        }
        #endregion
    }
}

