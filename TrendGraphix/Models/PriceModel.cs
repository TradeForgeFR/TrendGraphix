namespace TrendGraphix.Models
{
    public class PriceModel
    {
        public double Open { get; internal set; } = double.NaN;
        public double High { get; internal set; } = double.NaN;
        public double Low { get; internal set; } = double.NaN;
        public double Close { get; internal set; } = double.NaN;
        public double Volume { get; internal protected set; } = double.NaN; 
        public DateTime Time { get; internal set; } = DateTime.MinValue;
    }
}
