using HealthHelperMobileApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthHelperMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
        }
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new PageLogin());
        }
        private void BtnSignup_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new PageSignUp());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            CALFactory alFactory = new CALFactory();
            alFactory.insert();

            //CWCFatory wcFatory = new CWCFatory();
            //wcFatory.insert();

            //CWFactory wFactory = new CWFactory();
            //wFactory.insert();
        }
    }
}
