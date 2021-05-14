using HealthHelperMobileApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HealthHelperMobileApp
{
    public class MealViewModel 
    {
        readonly private INavigation _navigation;
        public MealViewModel(INavigation navigation)
        {
            _navigation = navigation;
            MealSelected = new Command<CMeal>(ShowMealDetail);
            LikePresssed = new Command<CMeal>(UpdateIsFav);
        }

        public Command<CMeal> MealSelected { get; }
        public Command<CMeal> LikePresssed { get; set; }
        void ShowMealDetail(CMeal meal)
        {
            _navigation.PushAsync(new PageMealDetail(meal));
        }
        void UpdateIsFav(CMeal meal)
        {

        }
    }
}
