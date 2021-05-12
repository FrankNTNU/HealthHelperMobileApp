using HealthHelperMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.ViewModels
{
    class CWLViewModel
    {
        List<CWorkoutLog> workoutLogs;

        public string MemberName
        {
            get
            {
                return App.member.Name;
            }
        }

        public List<CWorkoutLogDTO> WorkoutLogs
        {
            get 
            {
                workoutLogs = App.GetConnection().Table<CWorkoutLog>()
                    .Where(wl => wl.MemberID == App.member.ID)
                    .ToListAsync().Result;
                List<CWorkoutLogDTO> wlList = new List<CWorkoutLogDTO>();
                workoutLogs.ForEach(wl => wlList.Add(new CWorkoutLogDTO(wl)));
                return wlList;
            }
        }
    }
}
