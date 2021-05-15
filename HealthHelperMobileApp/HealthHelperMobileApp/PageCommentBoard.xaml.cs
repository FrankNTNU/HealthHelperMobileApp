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
    public partial class PageCommentBoard : ContentPage
    {
        public PageCommentBoard()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var list = new CCommentFactory().GetAllComments();
            cvComment.ItemsSource = list.Where(x => x.BasedCommentID == 0);
            lblHeader.Text = "共有" + list.Where(x => x.BasedCommentID == 0).Count() + "則評論";
        }

        private void CvComment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CComment comment = e.CurrentSelection.First() as CComment;
            Navigation.PushAsync(new PageCommentDetail(comment));
        }

        private async void Keyword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(keyword.Text))
            {
                var list = await new CCommentFactory().GetComments(keyword.Text);
                cvComment.ItemsSource = list.Where(x => x.BasedCommentID == 0);
                lblHeader.Text = "共有" + list.Where(x => x.BasedCommentID == 0).Count() + "則評論";

            }
            else
            {
                var list = new CCommentFactory().GetAllComments();
                cvComment.ItemsSource = list.Where(x => x.BasedCommentID == 0);
                lblHeader.Text = "共有" + list.Where(x => x.BasedCommentID == 0).Count() + "則評論";

            }
        }
        bool isAscending = false;
        private async void BtnSort_Clicked(object sender, EventArgs e)
        {
            keyword.Text = "";
            isAscending = !isAscending;
            var list = await new CCommentFactory().GetComments(isAscending);
            cvComment.ItemsSource = list.Where(x => x.BasedCommentID == 0);
            lblHeader.Text = "共有" + list.Where(x => x.BasedCommentID == 0).Count() + "則評論";

        }
    }
}