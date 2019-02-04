using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using MobileCharts.Data;

using OxyPlot;
using OxyPlot.Series;

namespace MobileCharts.ViewModels.OxyPlot
{
    public class MovimientoLineViewModel : OxyPlotGenericViewModel
    {
        public MovimientoLineViewModel(string title, List<string> colors) : base(title, colors)
        {
            Initialize();
        }

        private async Task Initialize()
        {
            var movimientos = await MockDatabase.ObtenerMovimientos();

            var serie = new LineSeries()
            {
                Color = OxyColor.Parse(Colors[0]),
                StrokeThickness = 2,
                LineStyle = LineStyle.Solid,
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColor.Parse(Colors[1]),
                MarkerFill = OxyColor.Parse(Colors[2]),
                Smooth = true,
            };
            serie.ItemsSource = movimientos.Select(m => new DataPoint(m.X, m.Y));
            
            ChartModel.Series.Add(serie);
        }
    }
}
