using HealthHelperMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            BindingContext = new MealViewModel(this.Navigation);
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            cvMeals.ItemsSource = new CMealFactory().GetMeals();
            keyword.Text = "";
        }
        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddMeal());
        }

        private void Keyword_TextChanged(object sender, TextChangedEventArgs e)
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
            if (isLike)
            {
                cvMeals.ItemsSource = new CMealFactory().GetLikedMeals(keyword.Text, isAscending);
            }
            else
            {
                cvMeals.ItemsSource = new CMealFactory().GetMeals(keyword.Text, isAscending);
                
            }
            isAscending = !isAscending;
        }

        private void CvMeals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CMeal meal = e.CurrentSelection.First() as CMeal;
            Navigation.PushAsync(new PageMealDetail(meal));
        }
        private bool isLike = false;
        private void BtnLike_Clicked(object sender, EventArgs e)
        {
            isLike = !isLike;
            if (isLike) cvMeals.ItemsSource = new CMealFactory().GetLikedMeals(keyword.Text, isAscending);
            else {
                if (!string.IsNullOrEmpty(keyword.Text))
                {
                    cvMeals.ItemsSource = new CMealFactory().GetMeals(keyword.Text);
                }
                else
                {
                    cvMeals.ItemsSource = new CMealFactory().GetMeals();
                }
            }
        }
    }
}