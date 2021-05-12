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
    public partial class PageWorkoutLogList : ContentPage
    {
        public PageWorkoutLogList()
        {
            InitializeComponent();
        }

        private void btnAddWL_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddWorkoutLog());
        }
    }
}