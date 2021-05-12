using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjWorkout.Models
{
    class CWorkoutCategory
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
