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
    public partial class PageMember : ContentPage
    {
        public PageMember()
        {
            InitializeComponent();
            CMember member = App.member;
            lblID.Text = member.ID.ToString();
            txtUserName.Text = member.Name;
            txtEmail.Text = member.Email;
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (App.member.Name == txtUserName.Text ||
                App.member.Email == txtEmail.Text)
            {
                DisplayAlert("訊息", "已輸入欲修改資訊", "確認");
            }
            else
            {
                App.member.Name = txtUserName.Text;
                App.member.Email = txtEmail.Text;
                new CMemberFactory().Update(App.member);
                DisplayAlert("訊息", "已修改資訊", "確認");
            }
        }
    }
}