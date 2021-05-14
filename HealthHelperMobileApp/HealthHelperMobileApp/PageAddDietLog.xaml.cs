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
    public partial class PageAddDietLog : ContentPage
    {
        readonly private CMeal _meal = null;
        public PageAddDietLog(CMeal meal)
        {
            _meal = meal;
            InitializeComponent();
            if (_meal != null)
            {
                lblName.Text = _meal.Name;
                lblCalories.Text = _meal.TotalCalories;
            }
            List<string> dates = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                dates.Add(DateTime.Today.AddDays(-i).ToString("yyyy/MM/dd"));
            }
            datePicker.ItemsSource = dates;
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPortion.Text) || datePicker.SelectedIndex == -1)
            {
                DisplayAlert("錯誤", "請輸入所有欄位", "返回");
            }
            else
            {
                string timeString = datePicker.SelectedItem.ToString();
                CDietDetail detail = new CDietDetail();
                detail.MealID = _meal.ID;
                detail.MealName = _meal.Name;
                detail.Calories = _meal.Calories * Convert.ToInt32(txtPortion.Text);
                detail.Portion = Convert.ToInt32(txtPortion.Text);
                DateTime addDate = DateTime.Parse(timeString);
                Task task = new CDietLogFactory().AddAsync(detail, addDate);
                DisplayAlert("訊息", "已加入飲食紀錄", "確認");
                Navigation.PopAsync();
            }
           
        }
    }
}