using System.Threading.Tasks;
using System.Collections.Generic;

using MobileCharts.Data;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MobileCharts.ViewModels.OxyPlot
{
    public class DivisaCandleStickViewModel : OxyPlotGenericViewModel
    {
        public DivisaCandleStickViewModel(string title, List<string> colors) : base(title, colors)
        {
            Initialize();
        }

        private async Task Initialize()
        {
            var variacionDivisas = await MockDatabase.ObtenerVariacionDivisas();

            var serie = new CandleStickSeries()
            {
                Color = OxyColor.Parse(Colors[0]),
                StrokeThickness = 2,
                LineStyle = LineStyle.Solid,
                DataFieldClose = "Cierre",
                DataFieldHigh = "Maximo",
                DataFieldLow = "Minimo",
                DataFieldOpen = "Apertura",
                DataFieldX = "Hora",
                ItemsSource = variacionDivisas,
                Title = "Variación del peso frente al dólar"
            };

            ChartModel.Series.Add(serie);
            ChartModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Hora del día" });
            ChartModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Valor [$]" });
        }
    }
}
