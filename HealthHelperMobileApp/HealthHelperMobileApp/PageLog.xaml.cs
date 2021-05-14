using HealthHelperMobileApp.Models;
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
    public partial class PageLog : ContentPage
    {

        public PageLog()
        {
            InitializeComponent();
            cvLog.ItemsSource = new CDietLogFactory().GetDietLogs();
        }

        private void CvLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CDietLog dietLog = e.CurrentSelection.First() as CDietLog;
            Navigation.PushAsync(new PageLogDetail(dietLog));
        }
        private bool isAscending = false;
        private void BtnSort_Clicked(object sender, EventArgs e)
        {
            isAscending = !isAscending;
            cvLog.ItemsSource = new CDietLogFactory().GetDietLogs(isAscending);
        }
    }
}