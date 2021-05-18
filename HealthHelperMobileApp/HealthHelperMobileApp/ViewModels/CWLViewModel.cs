using HealthHelperMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using System.Windows.Input;

namespace HealthHelperMobileApp.ViewModels
{
    class CWLViewModel
    {
        List<CWorkoutLog> workoutLogs;
        HashSet<Color> colorSet = new HashSet<Color>();
        List<CChartList> chartLists = new List<CChartList>();
        int colorIndex = 0;

        public CWLViewModel() 
        {
            colorSet.Clear();
            colorSet.Add(Color.Pink);
            colorSet.Add(Color.Gold);
            colorSet.Add(Color.DeepSkyBlue);
            colorSet.Add(Color.SeaGreen);
            colorSet.Add(Color.IndianRed);
            colorSet.Add(Color.Goldenrod);
            colorSet.Add(Color.LightSkyBlue);
            colorSet.Add(Color.ForestGreen);
            colorSet.Add(Color.OrangeRed);
            colorSet.Add(Color.Khaki);

            chartLists.Clear();
            chartLists.Add(new CChartList { 
                Name = "運動強度熱量消耗", 
                Chart = new RadarChart 
                { 
                    Entries = alEntries,
                    LabelTextSize = 50,
                    Typeface = "一".ToSKTypeface()
                },
                Width = 500,
                Height = 300
            });

            chartLists.Add(new CChartList
            {
                Name = "運動類型熱量消耗",
                Chart = new DonutChart
                {
                    Entries = wcEntries,
                    LabelTextSize = 50,
                    Typeface = "一".ToSKTypeface()
                },
                Width = 500,
                Height = 300
            });

            chartLists.Add(new CChartList
            {
                Name = "每週熱量消耗",
                Chart = new RadialGaugeChart
                {
                    Entries = weekCalEntries,
                    LabelTextSize = 50,
                    Typeface = "一".ToSKTypeface()
                },
                Width = 500,
                Height = 220
            });

            chartLists.Add(new CChartList
            {
                Name = "每週運動時數",
                Chart = new LineChart
                {
                    Entries = weekHourEntries,
                    LabelTextSize = 45,
                    Typeface = "一".ToSKTypeface(),
                    LabelOrientation = Orientation.Horizontal,
                    ValueLabelOrientation = Orientation.Horizontal
                },
                Width = 300,
                Height = 400
            });

            this.MyCommand = new Command(
                execute: (obj) =>
                {
                    CWorkoutLogDTO wl = obj as CWorkoutLogDTO;
                    (Application.Current as App).MainPage.Navigation.PushAsync(new PageEditWorkoutLog(wl));
                }
            );

        }

        public string MemberName
        {
            get
            {
                return App.SelectedMember.Name;
            }
        }

        public List<CWorkoutLogDTO> WorkoutLogs
        {
            get 
            {
                workoutLogs = App.GetConnection().Table<CWorkoutLog>()
                    .Where(wl => wl.MemberID == App.SelectedMember.ID)
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
                            Color = SKColor.Parse(ColorList[colorIndex++].ToHex()),
                            Label = g.FirstOrDefault().ActivityLevel.Description.Substring(0, 2),
                            ValueLabel = ((float)g.Sum(wl => wl.WorkoutTotalCal)).ToString("0.00") + " cal"
                        };

                colorIndex = 0;

                return q.ToList();
            }
        }

        
        public List<ChartEntry> wcEntries
        {
            get
            {
                var q = from wl in WorkoutLogs
                        group wl by wl.WorkoutCategory.ID into g
                        select new ChartEntry((float)g.Sum(wl => wl.WorkoutTotalCal))
                        {
                            Color = SKColor.Parse(ColorList[colorIndex].ToHex()),
                            Label = g.FirstOrDefault().WorkoutCategory.Name,
                            ValueLabel = ((float)g.Sum(wl => wl.WorkoutTotalCal)).ToString("0.00") + " cal",
                            ValueLabelColor = SKColor.Parse(ColorList[colorIndex++].ToHex())
                        };

                colorIndex = 0;

                return q.ToList();
            }
        }

        public List<ChartEntry> weekCalEntries
        {
            get
            {
                var q = from wl in WorkoutLogs
                        where wl.EditTime.Date > DateTime.Now.AddDays(-7)
                        group wl by wl.EditTime.Date into g
                        orderby g.Key
                        select new ChartEntry((float)g.Sum(wl => wl.WorkoutTotalCal))
                        {
                            Color = SKColor.Parse(ColorList[colorIndex].ToHex()),
                            Label = g.FirstOrDefault().EditTime.Date.ToString("M/d"),
                            ValueLabel = ((float)g.Sum(wl => wl.WorkoutTotalCal)).ToString("0.00") + " cal",
                            ValueLabelColor = SKColor.Parse(ColorList[colorIndex++].ToHex())
                        };

                colorIndex = 0;

                return q.ToList();
            }
        }

        public List<ChartEntry> weekHourEntries
        {
            get
            {
                var q = from wl in WorkoutLogs
                        where wl.EditTime.Date > DateTime.Now.AddDays(-7)
                        group wl by wl.EditTime.Date into g
                        orderby g.Key
                        select new ChartEntry((float)g.Sum(wl => wl.WorkoutHours))
                        {
                            Color = SKColor.Parse(ColorList[colorIndex].ToHex()),
                            Label = g.FirstOrDefault().EditTime.Date.ToString("M/d"),
                            ValueLabel = ((float)g.Sum(wl => wl.WorkoutHours)).ToString("0.00") + " h",
                            ValueLabelColor = SKColor.Parse(ColorList[colorIndex++].ToHex())
                        };

                colorIndex = 0;

                return q.ToList();
            }
        }

        public List<CChartList> ChartLists
        {
            get
            {
                return chartLists;
            }
        }

        public List<Color> ColorList
        {
            get
            {
                return colorSet.ToList();
            }
        }

        public ICommand MyCommand { private set; get; }

    }

    class CChartList
    {
        public string Name { get; set; }
        
        public Chart Chart { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
