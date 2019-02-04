using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using MobileCharts.Data;

using Microcharts;
using SkiaSharp;

namespace MobileCharts.ViewModels.MicroCharts
{
    public class VentasViewModel : BaseViewModel
    {
        private Chart _ventasChart;

        public Chart VentasChart
        {
            get { return _ventasChart; }
            set { SetProperty(ref _ventasChart, value); }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private List<string> _colors;

        public VentasViewModel(string title, Chart chartType, List<string> colors)
        {
            _ventasChart = chartType;
            _colors = colors;
            _title = $"Ventas (MicroCharts - {title})";

            InicializarAsync();
        }

        private async Task InicializarAsync()
        {
            var ventas = await MockDatabase.ObtenerVentas();

            _ventasChart.Entries = ventas.Select(
                (v, index) => new Entry(v.Monto)
                {
                    Color = SKColor.Parse(_colors[index + 1]),
                    ValueLabel = v.Monto.ToString("N2"),
                    Label = v.Mes
                });
        }
    }
}
