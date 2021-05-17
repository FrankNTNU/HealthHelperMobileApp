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
    public partial class PageEditReply : ContentPage
    {
        CComment _reply;
        public PageEditReply(CComment reply)
        {
            InitializeComponent();
            _reply = reply;
            lblMember.Text = _reply.MemberName;
            lblDate.Text = _reply.AddDateString;
            txtReplyContent.Text = _reply.Content;
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReplyContent.Text))
            {
                _reply.Content = txtReplyContent.Text;
                new CCommentFactory().Update(_reply);
                DisplayAlert("訊息", "已修改回覆內容", "確認");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("錯誤", "請輸入回覆內容", "返回");
            }
            
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            new CCommentFactory().Delete(_reply);
            DisplayAlert("訊息", "已刪除回覆", "確認");
            Navigation.PopAsync();
        }
    }
}