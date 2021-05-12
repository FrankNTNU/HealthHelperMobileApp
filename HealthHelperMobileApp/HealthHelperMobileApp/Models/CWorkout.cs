using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjWorkout.Models
{
    class CWorkout
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int WorkoutCategoryID { get; set; }

        public string Name { get; set; }

        public double Calories { get; set; }

        public int ActivityLevelID { get; set; }
    }
}
