using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using MobileCharts.Data;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MobileCharts.ViewModels.OxyPlot
{
    public class MemoriaAreaViewModel : OxyPlotGenericViewModel
    {
        public MemoriaAreaViewModel(string title, List<string> colors) : base(title, colors)
        {
            Initialize();
        }

        private async Task Initialize()
        {
            var usoMemoria = await MockDatabase.ObtenerUsoMemoria();

            var serie = new AreaSeries()
            {
                Color = OxyColor.Parse(Colors[0]),
                StrokeThickness = 2,
                LineStyle = LineStyle.Solid,
                Color2 = OxyColors.Transparent,
                //Smooth = true,
            };
            serie.ItemsSource = usoMemoria.Select(m => new DataPoint(m.Minuto, m.PorcentajeUso));

            ChartModel.Series.Add(serie);
            ChartModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Tiempo [min]" });
            ChartModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Memoria [%]" });
        }
    }
}
