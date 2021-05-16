using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CCustomImage
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CustomImage { get; set; }
        public int MealID { get; set; }
        public int MemberID { get; set; }
    }
}
