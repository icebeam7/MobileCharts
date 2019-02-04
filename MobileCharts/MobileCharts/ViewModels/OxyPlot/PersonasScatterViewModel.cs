using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using MobileCharts.Data;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MobileCharts.ViewModels.OxyPlot
{
    public class PersonasScatterViewModel : OxyPlotGenericViewModel
    {
        public PersonasScatterViewModel(string title, List<string> colors) : base(title, colors)
        {
            Initialize();
        }

        private async Task Initialize()
        {
            var datosPersonas = await MockDatabase.ObtenerDatosPersonas();

            var serie = new ScatterSeries()
            {
                MarkerFill = OxyColor.Parse(Colors[0]),
                MarkerType = MarkerType.Circle,
                Title = "Correlación entre peso y altura",
                MarkerStrokeThickness = 3,
            };

            serie.ItemsSource = datosPersonas.Select(p => new ScatterPoint(p.Altura, p.Peso, p.Edad));

            ChartModel.Series.Add(serie);
            ChartModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Altura [m]" });
            ChartModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Peso [Kg]" });
        }
    }
}
