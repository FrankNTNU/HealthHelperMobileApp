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
    public partial class PageLogin : ContentPage
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            CMember member = new CMemberFactory().GetMember(UserName.Text, Password.Text);
            if (member == null)
            {
                Message.Text = "用戶不存在，或是帳號或密碼錯誤";
            }
            else
            {
                Message.Text = "";
                DisplayAlert("訊息", "歡迎回來, " + member.Name + "!", "進入");
                App.member = member;
                Navigation.PushAsync(new PageMainMenu());
            }
        }
    }
}