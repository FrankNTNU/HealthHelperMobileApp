using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    class CWorkoutLogDTO : CWorkoutLog
    {
        CMember member;
        CWorkout workout;

        public CWorkoutLogDTO() : base()
        {

        }
        public CWorkoutLogDTO(CWorkoutLog wl)
        {
            foreach (var propertyInfo in typeof(CWorkoutLog).GetProperties())
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(wl));
            }

            member = App.GetConnection().Table<CMember>()
                .FirstOrDefaultAsync(m => m.ID == this.MemberID).Result;

            workout = App.GetConnection().Table<CWorkout>()
                .FirstOrDefaultAsync(w => w.ID == this.WorkoutID).Result;
        }

        public string WorkoutName
        {
            get
            {
                return workout.Name;
            }
        }

        public double WorkoutTotalCal
        {
            get
            {
                return this.WorkoutHours * workout.Calories;
            }

        }
    }
}
