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

        internal bool EditWorkoutLog(CWorkoutLog workoutLog)
        {
            try
            {
                App.GetConnection().UpdateAsync(workoutLog);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteWorkoutLog(CWorkoutLog workoutLog)
        {
            try
            {
                App.GetConnection().DeleteAsync(workoutLog);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
