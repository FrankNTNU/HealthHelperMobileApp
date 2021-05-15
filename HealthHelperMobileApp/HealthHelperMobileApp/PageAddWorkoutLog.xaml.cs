using HealthHelperMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthHelperMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAddWorkoutLog : ContentPage
    {
        CWFactory wFactory = new CWFactory();
        CWLFactory wlFactory = new CWLFactory();
        int wcID, alID;

        public PageAddWorkoutLog()
        {
            InitializeComponent();

            List<CWorkoutCategory> wcList = App.GetConnection().Table<CWorkoutCategory>().ToListAsync().Result;
            wcList.Insert(0, new CWorkoutCategory { ID = -1, Name = "全部類型" });
            this.pkrWC.ItemsSource = wcList;
            this.pkrWC.SelectedIndex = 0;

            List<CActivityLevel> alList = App.GetConnection().Table<CActivityLevel>().ToListAsync().Result;
            alList.Insert(0, new CActivityLevel { ID = -1, Description = "全部強度"});
            this.pkrAL.ItemsSource = alList;
            this.pkrAL.SelectedIndex = 0;
            
        }

        private void pkrWCAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //todo
            CWorkoutCategory wc = this.pkrWC.SelectedItem as CWorkoutCategory
                ?? new CWorkoutCategory { ID = -1 };

            CActivityLevel al = this.pkrAL.SelectedItem as CActivityLevel 
                ?? new CActivityLevel { ID = -1 };

            List<CWorkout> wList = wFactory.GetWorkoutsByWCAL((wcID = wc.ID), (alID = al.ID));
            this.pkrWorkout.ItemsSource = wList;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (flag |= !double.TryParse(this.txtHours.Text, out double hours))
            {
                this.lblHoursTest.Text = "請輸入數字";
            }

            CWorkout workout = this.pkrWorkout.SelectedItem as CWorkout;

            if (flag |= workout == null)
            {
                this.lblWTest.Text = "請選擇運動項目";
            }

            if (flag)
            {
                return;
            }

            CWorkoutLog wl = new CWorkoutLog();
            wl.MemberID = App.member.ID;
            wl.WorkoutID = workout.ID;
            wl.WorkoutHours = hours;
            wl.EditTime = this.dpEditTime.Date;

            if (wlFactory.AddWorkoutLog(wl))
            {
                await DisplayAlert("新增", "新增成功", "OK");
            }
            else
            {
                await DisplayAlert("新增", "新增失敗", "OK");
            }
            
        }

    }
}