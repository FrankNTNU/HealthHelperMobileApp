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
        SQLiteAsyncConnection conn;

        internal CWLFactory()
        {
            getConn();
        }

        public SQLiteAsyncConnection getConn()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, "HH.db");
            if (conn == null)
            {
                conn = new SQLiteAsyncConnection(path);
                conn.CreateTableAsync<CWorkoutLog>();
            }
            return conn;
        }

        internal bool AddWorkoutLog(CWorkoutLog workoutLog)
        {
            try
            {
                getConn().InsertAsync(workoutLog);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
