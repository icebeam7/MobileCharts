using System.Collections.Generic;
using System.Linq;

using MobileCharts.Helpers;
using MobileCharts.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileCharts
{
    public partial class App : Application
    {
        public static List<string> ColorsList;

        public App()
        {
            InitializeComponent();

            ColorsList = ColorHelper.GetRandomColors().ToList();
            MainPage = new NavigationPage(new MenuView());
        }
    }
}
