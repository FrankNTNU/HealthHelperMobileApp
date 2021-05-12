using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace HealthHelperMobileApp.Models
{
    public class CMealFactory
    {
     
        public void Add(CMeal meal)
        {
            App.GetConnection().InsertAsync(meal);
        }
        public List<CMeal> GetMeals()
        {
            return App.GetConnection().Table<CMeal>().ToListAsync().Result;
        }
        public List<CMeal> GetMeals(string text)
        {
            return App.GetConnection().Table<CMeal>().Where(x => x.Name.ToUpper().Contains(text.ToUpper())).ToListAsync().Result;
        }
        public List<CMeal> GetMeals(string text, bool isAscending)
        {
            if (isAscending)
            {
                return App.GetConnection().Table<CMeal>().Where(x => x.Name.ToUpper().Contains(text.ToUpper())).OrderBy(x => x.Calories).ToListAsync().Result;
            }
            else
            {
                return App.GetConnection().Table<CMeal>().Where(x => x.Name.ToUpper().Contains(text.ToUpper())).OrderByDescending(x => x.Calories).ToListAsync().Result;
            }
        }
    }
}
