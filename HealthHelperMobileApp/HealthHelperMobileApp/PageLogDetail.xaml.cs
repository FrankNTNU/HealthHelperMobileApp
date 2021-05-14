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
    public partial class PageLogDetail : ContentPage
    {
        readonly private DateTime _datetime;
        readonly private CDietLog _dietlog; 
        public PageLogDetail(CDietLog dietLog)
        {
            InitializeComponent();
            _datetime = dietLog.AddDate;
            _dietlog = dietLog;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            cvDetail.ItemsSource = new CLogDetailFactory().GetDietLogDetails(_dietlog.ID);
            lblDate.Text = _datetime.ToString("yyyy/MM/dd");
            
        }
       
    }
}