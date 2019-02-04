using MobileCharts.ViewModels.MicroCharts;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCharts.Views.MicroCharts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentasView : ContentPage
    {
        public VentasView(VentasViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}