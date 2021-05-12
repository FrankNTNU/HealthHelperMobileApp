using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HealthHelperMobileApp.Models
{
    public class CMeal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public string Portion { get; set; }
        public string TotalCalories => $"{Calories} 大卡";
        public byte[] Image { get; set; }
    }
}
