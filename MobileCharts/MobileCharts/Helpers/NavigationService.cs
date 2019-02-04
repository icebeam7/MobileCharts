using System;
using System.Collections.Generic;

using MobileCharts.Views.MicroCharts;
using MobileCharts.ViewModels.MicroCharts;
using MobileCharts.Views.OxyPlot;
using MobileCharts.ViewModels.OxyPlot;

using Xamarin.Forms;

namespace MobileCharts.Helpers
{
    public class NavigationService : INavigationService
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(VentasViewModel), typeof(VentasView) },
            { typeof(OxyPlotGenericView), typeof(OxyPlotGenericViewModel) },
        };

        public void NavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void NavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void NavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
