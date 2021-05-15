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
            var list = new CCommentFactory().GetComments();
            cvComment.ItemsSource = list.Where(x => x.BasedCommentID == 0);
            lblHeader.Text = "共有" + list.Count() + "則評論";
        }

        private void CvComment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CComment comment = e.CurrentSelection.First() as CComment;
            Navigation.PushAsync(new PageCommentDetail(comment));
        }
    }
}