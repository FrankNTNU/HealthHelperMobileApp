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
    public partial class PageMealDetail : ContentPage
    {
        public PageMealDetail()
        {
            InitializeComponent();
           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (PageMeal.selectedMeal != null)
            {
                lblName.Text = PageMeal.selectedMeal.Name;
                lblCalories.Text = PageMeal.selectedMeal.Calories.ToString();
            }
            PageMeal.selectedMeal = null;
        }
    }
}