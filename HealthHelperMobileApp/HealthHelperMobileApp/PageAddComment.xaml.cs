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
    public partial class PageAddComment : ContentPage
    {
        readonly private CMeal _meal;
        public PageAddComment(CMeal meal)
        {
            InitializeComponent();
            _meal = meal;
            lblMealName.Text = _meal.Name;
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" ||
                txtComment.Text == "")
            {
                DisplayAlert("錯誤", "已輸入所有欄位", "返回");
            }
            else
            {
                CComment comment = new CComment();
                comment.Title = txtTitle.Text;
                comment.Content = txtComment.Text;
                comment.IsApproved = false;
                comment.MealID = _meal.ID;
                comment.MealName = _meal.Name;
                comment.MemberID = App.SelectedMember.ID;
                comment.MemberName = App.SelectedMember.Name;
                comment.AddDate = DateTime.Today.Date;
                new CCommentFactory().Add(comment);
                DisplayAlert("訊息", "已加入留言", "確認");
                Navigation.PopAsync();
            }
        }
    }
}