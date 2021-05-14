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

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            CMeal meal = new CMeal();
            if (string.IsNullOrEmpty(txtName.Text) ||
               string.IsNullOrEmpty(txtImage.Text) ||
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
                DisplayAlert("訊息", "已更新成功", "確認");
                Navigation.PopAsync();
            }
        }
    }
}