using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CComment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public DateTime AddDate { get ; set; }
        public string AddDateString { get { return AddDate.ToString("yyyy/MM/dd"); } }
        public bool IsApproved { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int MealID { get; set; }
        public string MealName { get; set; }
        public int BasedCommentID { get; set; } = 0;
    }
}
