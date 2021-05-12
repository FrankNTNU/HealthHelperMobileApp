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
    public partial class PageSignUp : ContentPage
    {
        public PageSignUp()
        {
            InitializeComponent();
        }

        private void BtnSignup_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(Password1.Text) ||
                string.IsNullOrWhiteSpace(Password2.Text))
            {
                Message.Text = "請填入所有欄位";
            }
            else if (Password1.Text != Password2.Text)
            {
                Message.Text = "密碼驗證錯誤";
            }
            else
            {
                Message.Text = "OK";
                Message.TextColor = Color.Green;
                CMember member = new CMember
                {
                    Name = UserName.Text,
                    Email = Email.Text,
                    Password = Password1.Text
                };
                new CMemberFactory().Add(member);
                DisplayAlert("訊息", "已成功註冊", "確認");
                this.Navigation.PopAsync();
            }

        }
       
    }
}