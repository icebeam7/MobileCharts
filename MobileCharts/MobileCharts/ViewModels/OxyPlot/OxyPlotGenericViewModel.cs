using System.Collections.Generic;

using OxyPlot;

namespace MobileCharts.ViewModels.OxyPlot
{
    public class OxyPlotGenericViewModel : BaseViewModel
    {
        private PlotModel _chartModel;

        public PlotModel ChartModel
        {
            get { return _chartModel; }
            set { SetProperty(ref _chartModel, value); }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private List<string> _colors;

        public List<string> Colors
        {
            get { return _colors; }
            set { SetProperty(ref _colors, value); }
        }

        public OxyPlotGenericViewModel(string title, List<string> colors)
        {
            _colors = colors;
            _title = title;

            _chartModel = new PlotModel()
            {
                PlotMargins = new OxyThickness(50),
            };
        }
    }
}