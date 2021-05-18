using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthHelperMobileApp.Models
{
    public class CWorkoutLogDTO : CWorkoutLog
    {
        CActivityLevel al;
        CMember member;
        CWorkout workout;
        CWorkoutCategory wc;

        public CWorkoutLogDTO() : base()
        {

        }

        public CWorkoutLogDTO(CWorkoutLog wl)
        {
            foreach (var propertyInfo in typeof(CWorkoutLog).GetProperties())
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(wl));
            }

            member = App.GetConnection().Table<CMember>().ToListAsync().Result
                .Where(m => m.ID == this.MemberID).SingleOrDefault();

            workout = App.GetConnection().Table<CWorkout>().ToListAsync().Result
                .Where(w=> w.ID == this.WorkoutID).SingleOrDefault();

            al = App.GetConnection().Table<CActivityLevel>().ToListAsync().Result
                .Where(al => al.ID == this.workout.ActivityLevelID).SingleOrDefault();

            wc = App.GetConnection().Table<CWorkoutCategory>().ToListAsync().Result
                .Where(wc => wc.ID == this.workout.WorkoutCategoryID).SingleOrDefault();
        }

        public CWorkout Workout
        {
            get
            {
                return workout;
            }
        }

        public CActivityLevel ActivityLevel
        {
            get
            {
                return al;
            }
        }

        public CWorkoutCategory WorkoutCategory
        {
            get
            {
                return wc;
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
