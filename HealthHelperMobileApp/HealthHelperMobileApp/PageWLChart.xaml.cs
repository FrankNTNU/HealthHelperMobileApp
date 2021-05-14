using HealthHelperMobileApp.Models;
using HealthHelperMobileApp.ViewModels;
using Microcharts;
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
        CWLViewModel wlViewModel = new CWLViewModel();

        public PageWLChart()
        {
            InitializeComponent();

            this.chart1.Chart = new RadarChart { Entries = wlViewModel.Entries };
            this.chart1.Chart.LabelTextSize = 50;
            this.chart1.Chart.Typeface = "一".ToSKTypeface();
            this.chart1.Chart.Margin = 240f;
        }

    }
}