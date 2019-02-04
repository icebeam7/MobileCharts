using MobileCharts.ViewModels.OxyPlot;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCharts.Views.OxyPlot
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OxyPlotGenericView : ContentPage
	{
		public OxyPlotGenericView (OxyPlotGenericViewModel vm)
		{
			InitializeComponent ();
            this.BindingContext = vm;
		}
	}
}