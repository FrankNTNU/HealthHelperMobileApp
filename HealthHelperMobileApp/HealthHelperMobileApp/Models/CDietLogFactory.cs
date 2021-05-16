using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace HealthHelperMobileApp.Models
{
    public class CDietLogFactory
    {

        public async Task AddAsync(CDietDetail detail, DateTime addDate)
        {
            CDietLog dietLog = GetDietLog(addDate);
            if (dietLog != null)
            {
                detail.DietLogID = dietLog.ID;
                await App.GetConnection().InsertAsync(detail);
                dietLog.TotalCalories += detail.Calories;
                await App.GetConnection().UpdateAsync(dietLog);
            }
            else
            {
                dietLog = new CDietLog();
                dietLog.AddDate = addDate.Date;
                dietLog.TotalCalories = detail.Calories;
                await App.GetConnection().InsertAsync(dietLog); // insert log to get ID 
                int tempID = 0;
                if (dietLog.ID != 0)
                {
                    tempID = dietLog.ID;
                }
                detail.DietLogID = tempID;
                await App.GetConnection().InsertAsync(detail); // set dietlogID to detail

                await App.GetConnection().UpdateAsync(dietLog); // update log after adding details
            }
        }
        
        public CDietLog GetDietLog(DateTime date)
        {
             return App.GetConnection().Table<CDietLog>()
                .FirstOrDefaultAsync(x => x.AddDate == date).Result;
        }
        public List<CDietLog> GetDietLogs()
        {
            return App.GetConnection().Table<CDietLog>().ToListAsync().Result;
        }
        public List<CDietLog> GetDietLogs(bool isAscending)
        {
            if (isAscending)
            {
                return App.GetConnection().Table<CDietLog>().OrderBy(x => x.AddDate).ToListAsync().Result;
            }
            else
            {
                return App.GetConnection().Table<CDietLog>().OrderByDescending(x => x.AddDate).ToListAsync().Result;

            }
        }
    }
}
