using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CDietLog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime AddDate { get; set; }
        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        //public virtual List<CDietDetail> Details { get; set; }
        public double TotalCalories { get; set; }
        public string Calories { get { return TotalCalories + "大卡"; } }
        public string Date { get { return AddDate.ToString("yyyy/MM/dd"); } }
    }
}
