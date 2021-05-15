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
    public partial class PageAddMeal : ContentPage
    {
        public PageAddMeal()
        {
            InitializeComponent();
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            CMeal meal = new CMeal();
            CNutrient nutrient = new CNutrient();
            if (string.IsNullOrEmpty(txtName.Text) ||
               string.IsNullOrEmpty(txtCalories.Text) ||
               string.IsNullOrEmpty(txtPortion.Text))
            {
                DisplayAlert("錯誤", "請填入所有欄位", "返回");
            }
            else if (!double.TryParse(txtCalories.Text, out double calories))
            {
                DisplayAlert("錯誤", "請輸入正確的卡路里格式", "返回");
            }
            else
            {
                meal.Name = txtName.Text;
                meal.Calories = calories;
                meal.Portion = txtPortion.Text;
                meal.Image = txtImage.Text;
                new CMealFactory().Add(meal);
                nutrient.Carbs = string.IsNullOrEmpty(txtCarbs.Text) ? "0" : txtCarbs.Text;
                nutrient.Fat = string.IsNullOrEmpty(txtFat.Text) ? "0" : txtFat.Text;
                nutrient.Choles = string.IsNullOrEmpty(txtCholes.Text) ? "0" : txtCholes.Text;
                nutrient.Protein = string.IsNullOrEmpty(txtProtein.Text) ? "0" : txtProtein.Text;
                nutrient.Sodium = string.IsNullOrEmpty(txtSodium.Text) ? "0" : txtSodium.Text;
                nutrient.MealID = meal.ID;
                new CNutrientFactory().Add(nutrient);
                DisplayAlert("訊息", "已更新成功", "確認");
                Navigation.PopAsync();
            }
        }
    }
}