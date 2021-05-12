using HealthHelperMobileApp.Models;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthHelperMobileApp
{
    public partial class App : Application
    {
        public static CMember member { get; set; }
        static SQLiteAsyncConnection db;
        public static SQLiteAsyncConnection GetConnection()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(folder, "HH.db");
            if (db == null)
                db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<CMember>();
            db.CreateTableAsync<CMeal>();

            //恩旗
            db.CreateTableAsync<CActivityLevel>();
            db.CreateTableAsync<CWorkoutCategory>();
            db.CreateTableAsync<CWorkout>();
            db.CreateTableAsync<CWorkoutLog>();

            return db;
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new PageAddWorkoutLog());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
