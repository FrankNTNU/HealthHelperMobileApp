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

        public List<ChartEntry> alEntries
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
            }
        }

        //todo
        //public List<ChartEntry> wcEntries
        //{
        //    //get
        //    //{
        //    //    var q = from wl in WorkoutLogs
        //    //            group wl by wl.WorkoutCategory.ID into g
        //    //            select new ChartEntry((float)g.Sum(wl => wl.WorkoutTotalCal))
        //    //            {
        //    //                Color = SKColor.Parse(GetColorByALID(g.Key)),
        //    //                Label = g.FirstOrDefault().ActivityLevel.Description,
        //    //                ValueLabel = ((float)g.Sum(wl => wl.WorkoutTotalCal)).ToString(),
        //    //            };
        //    //}
        //}

        public List<CChartList> ChartLists
        {
            get
            {
                List<CChartList> chartLists = new List<CChartList>();

                chartLists.Add(new CChartList { Name = "Bar", entryList = alEntries });
                chartLists.Add(new CChartList { Name = "Bar", entryList = alEntries });
                chartLists.Add(new CChartList { Name = "Bar", entryList = alEntries });
                chartLists.Add(new CChartList { Name = "Bar", entryList = alEntries });
                chartLists.Add(new CChartList { Name = "Bar", entryList = alEntries });

                return chartLists;
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

    class CChartList
    {
        public string Name { get; set; }
        public List<ChartEntry> entryList { get; set; }
    }
}
