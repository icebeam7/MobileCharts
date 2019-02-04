using System.Threading.Tasks;
using System.Collections.Generic;

using MobileCharts.Data;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MobileCharts.ViewModels.OxyPlot
{
    public class PuntosHeatMapViewModel : OxyPlotGenericViewModel
    {
        public PuntosHeatMapViewModel(string title, List<string> colors) : base(title, colors)
        {
            Initialize();
        }

        private async Task Initialize()
        {
            var x0 = -3.5;
            var x1 = 2.4;
            var y0 = -4.0;
            var y1 = 4;
            var n = 100;

            var puntosRastrigin = await MockDatabase.ObtenerPuntosRastrigin(x0, x1, y0, y1, n);

            var serie = new HeatMapSeries
            {
                X0 = x0,
                X1 = x1,
                Y0 = y0,
                Y1 = y1,
                Data = puntosRastrigin,
                Title = "Rastrigin"
            };

            ChartModel.Series.Add(serie);
            ChartModel.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(500), HighColor = OxyColors.Gray, LowColor = OxyColors.Black });
        }
    }
}
