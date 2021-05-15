using HealthHelperMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace HealthHelperMobileApp
{
    public partial class App : Application
    {
        public static CMember SelectedMember { get; set; }
        static SQLiteAsyncConnection db;
        public static SQLiteAsyncConnection GetConnection()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = Path.Combine(folder, "HH.db");
            if (db == null)
            {
                db = new SQLiteAsyncConnection(path);
                db.CreateTableAsync<CMember>().Wait();
                db.CreateTableAsync<CMeal>().Wait();
                db.CreateTableAsync<CDietLog>().Wait();
                db.CreateTableAsync<CDietDetail>().Wait();
                db.CreateTableAsync<CComment>().Wait();
                db.CreateTableAsync<CNutrient>().Wait();
            }
            
            return db;
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
