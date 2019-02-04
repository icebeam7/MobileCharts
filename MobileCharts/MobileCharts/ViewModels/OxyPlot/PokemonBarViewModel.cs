using System.Threading.Tasks;
using System.Collections.Generic;

using MobileCharts.Data;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MobileCharts.ViewModels.OxyPlot
{
    public class PokemonBarViewModel : OxyPlotGenericViewModel
    {
        public PokemonBarViewModel(string title, List<string> colors) : base(title, colors)
        {
            Initialize();
        }

        private async Task Initialize()
        {
            var pokemons = await MockDatabase.ObtenerPokemons();

            ChartModel.PlotMargins = new OxyThickness(50);
            ChartModel.LegendPlacement = LegendPlacement.Outside;
            ChartModel.LegendPosition = LegendPosition.BottomCenter;
            ChartModel.LegendOrientation = LegendOrientation.Horizontal;

            var ejeCategorias = new CategoryAxis { Position = CategoryAxisPosition() };
            ejeCategorias.Labels.Add("Ataque");
            ejeCategorias.Labels.Add("Defensa");
            ejeCategorias.Labels.Add("Salud");
            ejeCategorias.Labels.Add("Velocidad");
            ChartModel.Axes.Add(ejeCategorias);

            var ejeValores = new LinearAxis { Position = ValueAxisPosition() };
            ChartModel.Axes.Add(ejeValores);

            for (int i = 0; i < pokemons.Count; i++)
            {
                var serie = new BarSeries() { Title = pokemons[i].Nombre,
                    FillColor = OxyColor.Parse(Colors[i]), StrokeThickness = 1 };

                serie.Items.Add(new BarItem { Value = pokemons[i].Ataque });
                serie.Items.Add(new BarItem { Value = pokemons[i].Defensa });
                serie.Items.Add(new BarItem { Value = pokemons[i].Salud });
                serie.Items.Add(new BarItem { Value = pokemons[i].Velocidad });

                ChartModel.Series.Add(serie);
            }
        }

        private AxisPosition CategoryAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
                return AxisPosition.Bottom;

            return AxisPosition.Left;
        }

        private AxisPosition ValueAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
                return AxisPosition.Left;

            return AxisPosition.Bottom;
        }
    }
}
