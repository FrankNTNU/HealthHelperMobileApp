using HealthHelperMobileApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthHelperMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMealDetail : ContentPage
    {
        readonly private CMeal _meal;
        private CNutrient nutrient;
        public PageMealDetail(CMeal meal)
        {
            InitializeComponent();
            _meal = meal;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblName.Text = _meal.Name;
            lblCalories.Text = _meal.Calories.ToString();
            lblPortion.Text = _meal.Portion;
            imageArea.Source = _meal.Image;
            txtImage.Text = _meal.Image;
            nutrient = new CNutrientFactory().GetNutrient(_meal.ID);
            if (nutrient != null)
            {
                txtCarbs.Text = nutrient.Carbs;
                txtCholes.Text = nutrient.Choles;
                txtFat.Text = nutrient.Fat;
                txtProtein.Text = nutrient.Protein;
                txtSodium.Text = nutrient.Sodium;
            }
            btnLike.BackgroundColor = _meal.IsFav ? Color.LightPink : Color.LightGray;
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblName.Text) ||
               string.IsNullOrEmpty(lblCalories.Text) ||
               string.IsNullOrEmpty(lblPortion.Text))
            {
                DisplayAlert ("錯誤", "請填入所有欄位", "返回");
            }
            else if (!double.TryParse(lblCalories.Text, out double calories))
            {
                DisplayAlert ("錯誤", "請輸入正確的卡路里格式", "返回");
            }
            else
            {
                _meal.Name = lblName.Text;
                _meal.Calories = calories;
                _meal.Portion = lblPortion.Text;
                _meal.Image = txtImage.Text;
                if (nutrient == null)
                {
                    nutrient = new CNutrient();
                }
                nutrient.Carbs = string.IsNullOrEmpty(txtCarbs.Text) ? "0" : txtCarbs.Text;
                nutrient.Fat = string.IsNullOrEmpty(txtFat.Text) ? "0" : txtFat.Text;
                nutrient.Choles = string.IsNullOrEmpty(txtCholes.Text) ? "0" : txtCholes.Text;
                nutrient.Protein = string.IsNullOrEmpty(txtProtein.Text) ? "0" : txtProtein.Text;
                nutrient.Sodium = string.IsNullOrEmpty(txtSodium.Text) ? "0" : txtSodium.Text;
                nutrient.MealID = _meal.ID;
                if (nutrient.ID == 0) // Not exist
                {
                    new CNutrientFactory().Add(nutrient);
                }
                else
                {
                    new CNutrientFactory().Update(nutrient);
                }
                new CMealFactory().Update(_meal);
                DisplayAlert ("訊息", "已更新成功", "確認");
                Navigation.PopAsync();
            }
        }

        private void BtnLike_Clicked(object sender, EventArgs e)
        {
            _meal.IsFav = !_meal.IsFav;
            if (_meal.IsFav)
            {
                DisplayAlert("訊息", "已加入收藏", "確認");
            }
            btnLike.BackgroundColor = _meal.IsFav ? Color.LightPink : Color.LightGray;
            new CMealFactory().Update(_meal);
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddDietLog(_meal));
        }
        private void BtnComment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageComment(_meal));
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            new CMealFactory().Delete(_meal);
            CNutrient nutrient = new CNutrientFactory().GetNutrient(_meal.ID);
            if (nutrient!= null)
            {
                new CNutrientFactory().Delete(nutrient);
            }
            DisplayAlert("訊息", "已刪除餐點", "返回");
            Navigation.PopAsync();
        }
    }
}