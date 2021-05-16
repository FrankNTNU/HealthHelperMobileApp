using HealthHelperMobileApp.Models;
using HealthHelperMobileApp.ViewModels;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthHelperMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageWLChart : ContentPage
    {
        CWLViewModel wlViewModel;

        public PageWLChart()
        {
            InitializeComponent();

            wlViewModel = this.BindingContext as CWLViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (wlViewModel.WorkoutLogs.Count == 0)
            {
                DisplayAlert("提示", "目前無資料", "OK");
            }
        }
    }
}