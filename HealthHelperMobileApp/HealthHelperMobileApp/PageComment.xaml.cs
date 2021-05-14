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
    public partial class PageComment : ContentPage
    {
        readonly private CMeal _meal;
        public PageComment(CMeal meal)
        {
            InitializeComponent();
            _meal = meal;
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddComment(_meal));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var list = new CCommentFactory().GetComments(_meal.ID);
            cvComment.ItemsSource = list;
            lblHeader.Text = "針對餐點" + _meal.Name + "的評論共有" + list.Count() + "則";
        }
    }
}