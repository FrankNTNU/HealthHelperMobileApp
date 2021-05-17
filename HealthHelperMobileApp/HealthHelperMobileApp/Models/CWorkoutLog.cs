using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CWorkoutLog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int WorkoutID { get; set; }

        public DateTime EditTime { get; set; }

        public double WorkoutHours { get; set; }
    }
}
