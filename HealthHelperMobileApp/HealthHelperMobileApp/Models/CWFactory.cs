using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HealthHelperMobileApp.Models
{
    class CWFactory
    {
        internal void insert()
        {
            
            List<CWorkout> list;
            if ((list = App.GetConnection().Table<CWorkout>().ToListAsync().Result).Count > 0)
            {
                return;
            }

            List<CWorkout> wlList = new List<CWorkout>();

            wlList.Add(new CWorkout { Name = "衝刺", Calories = 16.8, ActivityLevelID = 3, WorkoutCategoryID = 6 });
            wlList.Add(new CWorkout { Name = "快跑", Calories = 12.7, ActivityLevelID = 2, WorkoutCategoryID = 6 });
            wlList.Add(new CWorkout { Name = "慢跑", Calories = 8.2, ActivityLevelID = 1, WorkoutCategoryID = 6 });
            wlList.Add(new CWorkout { Name = "散步", Calories = 3.5, ActivityLevelID = 1, WorkoutCategoryID = 18 });
            wlList.Add(new CWorkout { Name = "快走", Calories = 5.5, ActivityLevelID = 2, WorkoutCategoryID = 18 });
            wlList.Add(new CWorkout { Name = "健走", Calories = 7.5, ActivityLevelID = 3, WorkoutCategoryID = 18 });
            wlList.Add(new CWorkout { Name = "下樓梯", Calories = 3.2, ActivityLevelID = 1, WorkoutCategoryID = 17 });
            wlList.Add(new CWorkout { Name = "上樓梯", Calories = 8.4, ActivityLevelID = 2, WorkoutCategoryID = 17 });
            wlList.Add(new CWorkout { Name = "慢慢騎(10公里/時)", Calories = 4, ActivityLevelID = 1, WorkoutCategoryID = 19 });
            wlList.Add(new CWorkout { Name = "騎快一點(20公里/時)", Calories = 8.4, ActivityLevelID = 2, WorkoutCategoryID = 19 });
            wlList.Add(new CWorkout { Name = "全力騎(30公里/時)", Calories = 12.6, ActivityLevelID = 3, WorkoutCategoryID = 19 });
            wlList.Add(new CWorkout { Name = "哈達瑜珈", Calories = 3, ActivityLevelID = 1, WorkoutCategoryID = 20 });
            wlList.Add(new CWorkout { Name = "流動瑜珈", Calories = 5.8, ActivityLevelID = 2, WorkoutCategoryID = 20 });
            wlList.Add(new CWorkout { Name = "ashtanga瑜珈", Calories = 9.9, ActivityLevelID = 3, WorkoutCategoryID = 20 });
            wlList.Add(new CWorkout { Name = "慢節奏舞蹈", Calories = 3.1, ActivityLevelID = 1, WorkoutCategoryID = 21 });
            wlList.Add(new CWorkout { Name = "一般節奏舞蹈", Calories = 5.3, ActivityLevelID = 2, WorkoutCategoryID = 21 });
            wlList.Add(new CWorkout { Name = "快節奏舞蹈", Calories = 7.5, ActivityLevelID = 3, WorkoutCategoryID = 21 });
            wlList.Add(new CWorkout { Name = "慢慢游", Calories = 6.3, ActivityLevelID = 1, WorkoutCategoryID = 22 });
            wlList.Add(new CWorkout { Name = "一般速度游", Calories = 10, ActivityLevelID = 2, WorkoutCategoryID = 22 });
            wlList.Add(new CWorkout { Name = "競速游", Calories = 13.7, ActivityLevelID = 3, WorkoutCategoryID = 22 });
            wlList.Add(new CWorkout { Name = "一般跳繩", Calories = 8.4, ActivityLevelID = 1, WorkoutCategoryID = 23 });
            wlList.Add(new CWorkout { Name = "快速跳繩", Calories = 12.6, ActivityLevelID = 2, WorkoutCategoryID = 23 });
            wlList.Add(new CWorkout { Name = "排球", Calories = 3.6, ActivityLevelID = 1, WorkoutCategoryID = 24 });
            wlList.Add(new CWorkout { Name = "高爾夫球", Calories = 5, ActivityLevelID = 2, WorkoutCategoryID = 24 });
            wlList.Add(new CWorkout { Name = "網球", Calories = 6.6, ActivityLevelID = 3, WorkoutCategoryID = 24 });
            wlList.Add(new CWorkout { Name = "棒壘球", Calories = 4.7, ActivityLevelID = 1, WorkoutCategoryID = 25 });
            wlList.Add(new CWorkout { Name = "籃球", Calories = 6.3, ActivityLevelID = 2, WorkoutCategoryID = 25 });
            wlList.Add(new CWorkout { Name = "足球", Calories = 7.7, ActivityLevelID = 3, WorkoutCategoryID = 25 });
            wlList.Add(new CWorkout { Name = "保齡球", Calories = 3.6, ActivityLevelID = 1, WorkoutCategoryID = 26 });
            wlList.Add(new CWorkout { Name = "乒乓球", Calories = 4.2, ActivityLevelID = 2, WorkoutCategoryID = 26 });
            wlList.Add(new CWorkout { Name = "羽毛球", Calories = 5.2, ActivityLevelID = 3, WorkoutCategoryID = 26 });
            wlList.Add(new CWorkout { Name = "一般有氧運動", Calories = 6.3, ActivityLevelID = 1, WorkoutCategoryID = 27 });
            wlList.Add(new CWorkout { Name = "有氧拳擊", Calories = 12, ActivityLevelID = 2, WorkoutCategoryID = 27 });
            wlList.Add(new CWorkout { Name = "飛輪", Calories = 16, ActivityLevelID = 3, WorkoutCategoryID = 27 });

            foreach (var item in wlList)
            {
                App.GetConnection().InsertAsync(item);
            }
        }

        internal List<CWorkout> GetWorkoutsByWCAL(int wcID = -1, int alID = -1)
        {
            return App.GetConnection().Table<CWorkout>()
                .Where(w => (wcID == -1 || w.WorkoutCategoryID == wcID) && (alID == -1 || w.ActivityLevelID == alID))
                .ToListAsync().Result;
        }
    }
}
