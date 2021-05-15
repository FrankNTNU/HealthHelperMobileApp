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
    public partial class PageCommentDetail : ContentPage
    {
        CComment _comment;
        
        public PageCommentDetail(CComment comment)
        {
            InitializeComponent();
            _comment = comment;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMember.Text = _comment.MemberName;
            lblMealName.Text = _comment.MealName;
            txtTitle.Text = _comment.Title;
            txtContent.Text = _comment.Content;
            lblDate.Text = _comment.AddDateString;
            bool isWriter = App.SelectedMember.ID == _comment.MemberID;
            slButtons.IsVisible = isWriter;
            txtTitle.IsReadOnly = !isWriter;
            txtContent.IsReadOnly = !isWriter;
            slReplySection.IsVisible = !isWriter;
            cvReplySection.ItemsSource = new CCommentFactory().GetReplies(_comment.ID);
        }
        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            _comment.Title = txtTitle.Text;
            _comment.Content = txtContent.Text;
            new CCommentFactory().Update(_comment);
            DisplayAlert("訊息", "已修改留言", "確認");
            Navigation.PopAsync();
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            new CCommentFactory().Delete(_comment);
            DisplayAlert("訊息", "已刪除留言", "返回");
            Navigation.PopAsync();
        }

        private void BtnReply_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReply.Text))
            {
                DisplayAlert("錯誤", "請輸入回覆內容", "返回");
            }
            else
            {
                CComment reply = new CComment();
                reply.MemberID = App.SelectedMember.ID;
                reply.MemberName = App.SelectedMember.Name;
                reply.MealID = 0;
                reply.Title = "";
                reply.Content = txtReply.Text;
                reply.AddDate = DateTime.Today.Date;
                reply.BasedCommentID = _comment.ID;
                new CCommentFactory().Add(reply);
                DisplayAlert("訊息", "已新增回覆", "返回");
                Navigation.PopAsync();
            }
        }

        private void CvReplySection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CComment selectedReply = e.CurrentSelection.First() as CComment;
            if (selectedReply.MemberID == App.SelectedMember.ID)
            {
                Navigation.PushAsync(new PageEditReply(selectedReply));
            }
        }
    }
}