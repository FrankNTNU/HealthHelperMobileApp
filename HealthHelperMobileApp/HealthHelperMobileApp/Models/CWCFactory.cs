using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HealthHelperMobileApp.Models
{
    class CWCFatory {

        internal void insert()
        {
            List<CWorkoutCategory> list;
            if ((list = App.GetConnection().Table<CWorkoutCategory>().ToListAsync().Result).Count > 0)
            {
                return;
            }

            List<CWorkoutCategory> wcList = new List<CWorkoutCategory>();

            wcList.Add(new CWorkoutCategory { ID = 24, Name = "戶外球類1" });
            wcList.Add(new CWorkoutCategory { ID = 25, Name = "戶外球類2" });
            wcList.Add(new CWorkoutCategory { ID = 27, Name = "有氧健身運動" });
            wcList.Add(new CWorkoutCategory { ID = 18, Name = "走路" });
            wcList.Add(new CWorkoutCategory { ID = 17, Name = "爬樓梯" });
            wcList.Add(new CWorkoutCategory { ID = 26, Name = "室內球類" });
            wcList.Add(new CWorkoutCategory { ID = 22, Name = "游泳" });
            wcList.Add(new CWorkoutCategory { ID = 6, Name = "跑步" });
            wcList.Add(new CWorkoutCategory { ID = 20, Name = "瑜珈" });
            wcList.Add(new CWorkoutCategory { ID = 21, Name = "跳舞" });
            wcList.Add(new CWorkoutCategory { ID = 23, Name = "跳繩" });
            wcList.Add(new CWorkoutCategory { ID = 19, Name = "騎腳踏車" });

            foreach (var item in wcList)
            {
                App.GetConnection().InsertAsync(item);
            }
        }
    }
}
