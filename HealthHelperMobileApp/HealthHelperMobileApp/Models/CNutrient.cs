using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CNutrient
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Fat { get; set; }
        public string Choles { get; set; } // Cholesterol 膽固醇
        public string Sodium { get; set; }
        public string Carbs { get; set; }
        public string Protein { get; set; }
        public int MealID { get; set; }
    }
}
