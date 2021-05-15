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
        CWLViewModel wlViewModel = new CWLViewModel();
        int position = 0;

        public PageWLChart()
        {
            InitializeComponent();

            this.crslView.SetBinding(ItemsView.ItemsSourceProperty, "ChartLists");

            this.crslView.ItemTemplate = new DataTemplate(() => 
            {
                CChartList cl = this.crslView.CurrentItem as CChartList;
                ChartView cv = new ChartView();


                if (position == 0)
                {
                    cv.Chart = new RadarChart();
                    cv.Chart.Entries = cl.entryList;
                    cv.Chart.LabelTextSize = 50;
                    cv.Chart.Typeface = "一".ToSKTypeface();
                    cv.Chart.Margin = 260f;
                }
                else if (position == 1)
                {
                    cv.Chart = new BarChart();
                    cv.Chart.Entries = cl.entryList;
                    cv.Chart.LabelTextSize = 50;
                    cv.Chart.Typeface = "一".ToSKTypeface();
                    cv.Chart.Margin = 260f;
                    cv.Rotation = 270;
                }
                else if (position == 2)
                {
                    cv.Chart = new DonutChart();
                    cv.Chart.Entries = cl.entryList;
                    cv.Chart.LabelTextSize = 50;
                    cv.Chart.Typeface = "一".ToSKTypeface();
                    cv.Chart.Margin = 260f;
                }
                else if (position == 3)
                {
                    cv.Chart = new LineChart();
                    cv.Chart.Entries = cl.entryList;
                    cv.Chart.LabelTextSize = 50;
                    cv.Chart.Typeface = "一".ToSKTypeface();
                    cv.Chart.Margin = 260f;
                    cv.Rotation = 270;
                }

                cv.Chart.LabelTextSize = 40;
                cv.HeightRequest = 500;

                position++;

                if (position > 4)
                {
                    position = 0;
                }

                if (position < 0)
                {
                    position = 4;
                }

                StackLayout stacklayout = new StackLayout
                {
                    Children = { cv },
                };

                stacklayout.VerticalOptions = LayoutOptions.FillAndExpand;

                return stacklayout;
            });

        }

    }
}