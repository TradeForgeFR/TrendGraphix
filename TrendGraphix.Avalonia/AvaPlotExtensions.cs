using Avalonia;
using Avalonia.Input;
using Key = ScottPlot.Control.Key;
using MouseButton = ScottPlot.Control.MouseButton;
using AvaKey = global::Avalonia.Input.Key;
using ScottPlot;

namespace TrendGraphix.Avalonia
{
    internal static class AvaPlotExtensions
    {
        internal static Pixel ToPixel(this PointerEventArgs e, Visual visual)
        {
            float x = (float)e.GetPosition(visual).X;
            float y = (float)e.GetPosition(visual).Y;
            return new Pixel(x, y);
        }

        internal static Key ToKey(this KeyEventArgs e)
        {
            return e.Key switch
            {
                AvaKey.LeftAlt => Key.Alt,
                AvaKey.RightAlt => Key.Alt,
                AvaKey.LeftShift => Key.Shift,
                AvaKey.RightShift => Key.Shift,
                AvaKey.LeftCtrl => Key.Ctrl,
                AvaKey.RightCtrl => Key.Ctrl,
                _ => Key.Unknown,
            };
        }

        internal static MouseButton ToButton(this PointerUpdateKind kind)
        {
            return kind switch
            {
                PointerUpdateKind.LeftButtonPressed => MouseButton.Left,
                PointerUpdateKind.LeftButtonReleased => MouseButton.Left,

                PointerUpdateKind.RightButtonPressed => MouseButton.Right,
                PointerUpdateKind.RightButtonReleased => MouseButton.Right,

                PointerUpdateKind.MiddleButtonPressed => MouseButton.Middle,
                PointerUpdateKind.MiddleButtonReleased => MouseButton.Middle,

                _ => MouseButton.Unknown,
            };
        }
    }
}
