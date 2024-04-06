using Avalonia;
using Avalonia.Controls;

namespace TrendGraphix.Avalonia
{
    public partial class Chart : UserControl
    {
        private StockChartModel _stockChart = new StockChartModel();

        public static readonly StyledProperty<StockChartModel> StockChartProperty =
        AvaloniaProperty.Register<Chart, StockChartModel>(nameof(StockChart));
        public Chart()
        {
            InitializeComponent();
            StockChart = this.Find<AvaPlot>("plot").StockChart;
            StockChart.ChartType = ChartType.Line;
        }

        public StockChartModel StockChart 
        {
            get 
            { 
                return GetValue(StockChartProperty);
            }
            private set
            {
                SetValue(StockChartProperty, value);
            }
        }
    }
}
