using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjWorkout.Models
{
    class CWorkoutLog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int WorkoutID { get; set; }

        public DateTime EditTime { get; set; }

        public double WorkoutHours { get; set; }
    }
}
