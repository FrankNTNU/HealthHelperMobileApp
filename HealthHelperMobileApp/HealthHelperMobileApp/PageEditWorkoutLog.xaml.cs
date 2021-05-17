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
    public partial class PageEditWorkoutLog : ContentPage
    {
        public CWorkoutLogDTO WL { set; get; }
        CWFactory wFactory = new CWFactory();
        CWLFactory wlFactory = new CWLFactory();
        int wcID, alID;

        public PageEditWorkoutLog(CWorkoutLogDTO wl)
        {
            this.WL = wl;
            InitializeComponent();

            List<CWorkoutCategory> wcList = App.GetConnection().Table<CWorkoutCategory>().ToListAsync().Result;
            wcList.Insert(0, new CWorkoutCategory { ID = -1, Name = "全部類型" });
            this.pkrWC.ItemsSource = wcList;
            this.pkrWC.SelectedItem = wcList.SingleOrDefault(wc => wc.ID == WL.WorkoutCategory.ID);

            List<CActivityLevel> alList = App.GetConnection().Table<CActivityLevel>().ToListAsync().Result;
            alList.Insert(0, new CActivityLevel { ID = -1, Description = "全部強度" });
            this.pkrAL.ItemsSource = alList;
            this.pkrAL.SelectedItem = alList.SingleOrDefault(al => al.ID == WL.ActivityLevel.ID);

            CWorkoutCategory wc1 = this.pkrWC.SelectedItem as CWorkoutCategory;

            CActivityLevel al1 = this.pkrAL.SelectedItem as CActivityLevel;

            List<CWorkout> wList = wFactory.GetWorkoutsByWCAL((wcID = wc1.ID), (alID = al1.ID));
            this.pkrWorkout.ItemsSource = wList;

            this.pkrWorkout.SelectedItem = wList.SingleOrDefault(w => w.ID == WL.WorkoutID);
        }

        private void pkrWCAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            CWorkoutCategory wc = this.pkrWC.SelectedItem as CWorkoutCategory
                ?? new CWorkoutCategory { ID = -1 };

            CActivityLevel al = this.pkrAL.SelectedItem as CActivityLevel
                ?? new CActivityLevel { ID = -1 };

            List<CWorkout> wList = wFactory.GetWorkoutsByWCAL((wcID = wc.ID), (alID = al.ID));
            this.pkrWorkout.ItemsSource = wList;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (!double.TryParse(this.txtHours.Text, out double hours))
            {
                this.lblHoursTest.Text = "請輸入數字";

                flag = true;
            }
            else
            {
                this.lblHoursTest.Text = "";
            }

            CWorkout workout = this.pkrWorkout.SelectedItem as CWorkout;

            if (workout == null)
            {
                this.lblWTest.Text = "請選擇運動項目";

                flag = true;
            }
            else
            {
                this.lblWTest.Text = "";
            }


            if (flag)
            {
                return;
            }

            CWorkoutLog wl = new CWorkoutLog();
            wl.ID = WL.ID;
            wl.MemberID = App.member.ID;
            wl.WorkoutID = workout.ID;
            wl.WorkoutHours = hours;
            wl.EditTime = DateTime.Now;
            
            if (wlFactory.EditWorkoutLog(wl))
            {
                await DisplayAlert("修改", "修改成功", "OK");
            }
            else
            {
                await DisplayAlert("修改", "修改失敗", "OK");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!await DisplayAlert("刪除", "確定要刪除此紀錄嗎？", "確認", "取消"))
            {
                return;
            }

            CWorkoutLog wl = new CWorkoutLog();
            wl.ID = WL.ID;

            if (wlFactory.DeleteWorkoutLog(wl))
            {
                await DisplayAlert("刪除", "刪除成功", "OK");
            }
            else
            {
                await DisplayAlert("刪除", "刪除失敗", "OK");
            }

            await Navigation.PopAsync();
        }

    }
}