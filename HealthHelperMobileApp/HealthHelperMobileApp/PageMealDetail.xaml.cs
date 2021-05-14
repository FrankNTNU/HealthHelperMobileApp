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
        public PageMealDetail(CMeal meal)
        {
            InitializeComponent();
            _meal = meal;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblID.Text = _meal.ID.ToString();
            lblName.Text = _meal.Name;
            lblCalories.Text = _meal.Calories.ToString();
            lblPortion.Text = _meal.Portion;
            imageArea.Source = _meal.Image;
            txtImage.Text = _meal.Image;
            btnLike.BackgroundColor = _meal.IsFav ? Color.LightPink : Color.LightGray;
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblName.Text) ||
               string.IsNullOrEmpty(lblCalories.Text) ||
               string.IsNullOrEmpty(lblPortion.Text))
            {
                DisplayAlert("錯誤", "請填入所有欄位", "返回");
            }
            else if (!double.TryParse(lblCalories.Text, out double calories))
            {
                DisplayAlert("錯誤", "請輸入正確的卡路里格式", "返回");
            }
            else
            {
                _meal.Name = lblName.Text;
                _meal.Calories = calories;
                _meal.Portion = lblPortion.Text;
                _meal.Image = txtImage.Text;
                new CMealFactory().Update(_meal);
                DisplayAlert("訊息", "已更新成功", "確認");
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
    }
}