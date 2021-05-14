using HealthHelperMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;

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
                return workoutLogs.Select(wl => new CWorkoutLogDTO(wl)).ToList();
            }
        }

        public List<ChartEntry> Entries
        {
            get
            {
                var q = from wl in WorkoutLogs
                        group wl by wl.ActivityLevel.ID into g
                        select new ChartEntry((float)g.Sum(wl => wl.WorkoutTotalCal))
                        {
                            Color = SKColor.Parse(GetColorByALID(g.Key)),
                            Label = g.FirstOrDefault().ActivityLevel.Description,
                            ValueLabel = ((float)g.Sum(wl => wl.WorkoutTotalCal)).ToString(),
                        };

                return q.ToList();

                //return WorkoutLogs.Select(wl =>
                //{
                //    return new ChartEntry((float)wl.WorkoutTotalCal)
                //    {
                //        Color = SKColor.Parse("#FF1493"),
                //        Label = wl.ActivityLevel.Description,
                //        ValueLabel = wl.WorkoutTotalCal.ToString()
                //    };
                //}).ToList();
            }
        }

        public string GetColorByALID(int alID)
        {
            switch (alID)
            {
                case 1:
                    return Color.Pink.ToHex();
                case 2:
                    return Color.Yellow.ToHex();
                case 3:
                    return Color.DeepSkyBlue.ToHex();
                default:
                    return Color.SeaGreen.ToHex();
            }
        }
    }
}
