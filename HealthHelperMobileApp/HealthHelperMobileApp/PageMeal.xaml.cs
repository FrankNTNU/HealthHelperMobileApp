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
    public partial class PageMeal : ContentPage
    {
        public static CMeal selectedMeal;
        bool isAscending = false;
        public PageMeal()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            cvMeals.ItemsSource = new CMealFactory().GetMeals();
        }
        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddMeal());
        }

        private void keyword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(keyword.Text))
            {
                cvMeals.ItemsSource = new CMealFactory().GetMeals(keyword.Text);
            }
            else
            {
                cvMeals.ItemsSource = new CMealFactory().GetMeals();
            }
        }

        private void BtnSort_Clicked(object sender, EventArgs e)
        {
            cvMeals.ItemsSource = new CMealFactory().GetMeals(keyword.Text, isAscending);
            isAscending = !isAscending;
        }
        private void CvSelectedMeal(object sender, SelectedItemChangedEventArgs e)
        {
            CMeal meal = e.SelectedItem as CMeal;
            selectedMeal = meal;
            Navigation.PushAsync(new PageMealDetail());
        }
    }
}