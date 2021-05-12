using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Xamarin.Forms;

namespace HealthHelperMobileApp.Models
{
    class CWLFactory
    {
        internal bool AddWorkoutLog(CWorkoutLog workoutLog)
        {
            try
            {
                App.GetConnection().InsertAsync(workoutLog);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
