using System;
using System.Threading.Tasks;

using MobileCharts.ViewModels.MicroCharts;
using MobileCharts.ViewModels.OxyPlot;
using MobileCharts.Views.MicroCharts;
using MobileCharts.Views.OxyPlot;

using Microcharts;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCharts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : ContentPage
	{
        public MenuView ()
		{
			InitializeComponent ();
        }

        private async void MicroChart_Bar_Clicked(object sender, EventArgs e)
        {
            await MostrarMicroChart("Bar", new BarChart());
        }

        private async void MicroChart_Donut_Clicked(object sender, EventArgs e)
        {
            //await MostrarChart("Donut", new DonutChart() { HoleRadius = 0.3F });
            await MostrarMicroChart("Donut", new DonutChart());
        }

        private async void MicroChart_Gauge_Clicked(object sender, EventArgs e)
        {
            await MostrarMicroChart("Radial Gague", new RadialGaugeChart());
        }

        private async void MicroChart_Line_Clicked(object sender, EventArgs e)
        {
            //await MostrarChart("Line", new LineChart() { LineMode = LineMode.Straight, LineSize = 10, PointMode = PointMode.Square, PointSize = 20 });
            await MostrarMicroChart("Line", new LineChart());
        }

        private async void MicroChart_Point_Clicked(object sender, EventArgs e)
        {
            await MostrarMicroChart("Point", new PointChart());
        }

        private async void MicroChart_Radar_Clicked(object sender, EventArgs e)
        {
            await MostrarMicroChart("Radar", new RadarChart());
        }

        async Task MostrarMicroChart(string title, Chart chartType)
        {
            var vm = new VentasViewModel(title, chartType, App.ColorsList);
            await Navigation.PushAsync(new VentasView(vm));
        }

        private async void OxyPlot_Pie_Clicked(object sender, EventArgs e)
        {
            await MostrarOxyPlotChart(new VentasPieViewModel("Ventas (OxyPlot - Pie)", App.ColorsList));
        }

        private async void OxyPlot_Bar_Clicked(object sender, EventArgs e)
        {
            await MostrarOxyPlotChart(new PokemonBarViewModel("Pokémon (OxyPlot - Bar)", App.ColorsList));
        }

        private async void OxyPlot_Line_Clicked(object sender, EventArgs e)
        {
            await MostrarOxyPlotChart(new MovimientoLineViewModel("Movimientos (OxyPlot - Line)", App.ColorsList));
        }

        private async void OxyPlot_Area_Clicked(object sender, EventArgs e)
        {
            await MostrarOxyPlotChart(new MemoriaAreaViewModel("Memoria (OxyPlot - Area)", App.ColorsList));
        }

        private async void OxyPlot_CandleStick_Clicked(object sender, EventArgs e)
        {
            await MostrarOxyPlotChart(new DivisaCandleStickViewModel("Divisa (OxyPlot - CandleStick)", App.ColorsList));
        }

        private async void OxyPlot_HeatMap_Clicked(object sender, EventArgs e)
        {
            await MostrarOxyPlotChart(new PuntosHeatMapViewModel("Puntos (OxyPlot - HeatMap)", App.ColorsList));
        }

        private async void OxyPlot_Scatter_Clicked(object sender, EventArgs e)
        {
            await MostrarOxyPlotChart(new PersonasScatterViewModel("Personas (OxyPlot - Scatter)", App.ColorsList));
        }

        async Task MostrarOxyPlotChart(OxyPlotGenericViewModel vm)
        {
            await Navigation.PushAsync(new OxyPlotGenericView(vm));
        }
    }
}