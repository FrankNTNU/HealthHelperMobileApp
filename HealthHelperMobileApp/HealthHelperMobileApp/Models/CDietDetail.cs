using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CDietDetail
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int MealID { get; set; }
        public string MealName { get; set; }
        public double Calories { get; set; }
        public int Portion { get; set; }
        public string TotalCalories { get { return Calories + "大卡"; } }
        public int DietLogID { get; set; } // a foreign key
    }
}
