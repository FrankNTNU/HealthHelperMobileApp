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
            double portion;
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtCalories.Text) ||
                string.IsNullOrEmpty(txtPortion.Text))
            {
                DisplayAlert("錯誤", "請填入所有欄位", "返回");
            }
            else if (!double.TryParse(txtCalories.Text, out portion))
            {
                DisplayAlert("錯誤", "請輸入正確的卡路里格式", "返回");
            }
            else
            {
                CMeal meal = new CMeal()
                {
                    Name = txtName.Text,
                    Calories = portion,
                    Portion = txtPortion.Text
                };
                new CMealFactory().Add(meal);
                DisplayAlert("訊息", "已成功新增餐點", "確認");
                Navigation.PopAsync();
            }
           
        }
    }
}