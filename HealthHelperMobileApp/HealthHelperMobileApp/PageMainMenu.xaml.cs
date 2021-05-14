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
    public partial class PageMainMenu : ContentPage
    {
        public PageMainMenu()
        {
            InitializeComponent();
        }

        private void BtnMember_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageMember());
        }

        private void BtnMeal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageMeal());
        }

        private void BtnLog_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageLog());

        }
    }
}