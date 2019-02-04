using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using MobileCharts.Data;

using OxyPlot;
using OxyPlot.Series;

namespace MobileCharts.ViewModels.OxyPlot
{
    public class VentasPieViewModel : OxyPlotGenericViewModel
    {
        public VentasPieViewModel(string title, List<string> colors) : base(title, colors)
        {
            Initialize();
        }

        private async Task Initialize()
        {
            var ventas = await MockDatabase.ObtenerVentas();

            var slices = ventas.Select(
                (v, index) => new PieSlice(v.Mes, v.Monto)
                {
                    //IsExploded = index % 2 == 0,
                    IsExploded = false,
                    Fill = OxyColor.Parse(Colors[index + 1])
                }).ToList();

            var serie = new PieSeries()
            {
                ExplodedDistance = 0.15,
                Slices = slices
            };

            ChartModel.Series.Add(serie);
        }
    }
}
