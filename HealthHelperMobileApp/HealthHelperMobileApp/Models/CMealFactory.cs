using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace HealthHelperMobileApp.Models
{
    public class CMealFactory
    {
     
        public async void Add(CMeal meal)
        {
            await App.GetConnection().InsertAsync(meal);
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
                if (string.IsNullOrEmpty(text))
                {
                    return App.GetConnection().Table<CMeal>().OrderBy(x => x.Calories).ToListAsync().Result;
                }
                else
                {
                    return App.GetConnection().Table<CMeal>().Where(x => x.Name.ToUpper().Contains(text.ToUpper())).OrderBy(x => x.Calories).ToListAsync().Result;
                }
               
            }
            else
            {
                if (string.IsNullOrEmpty(text))
                {
                    return App.GetConnection().Table<CMeal>().OrderByDescending(x => x.Calories).ToListAsync().Result;
                }
                else
                {
                    return App.GetConnection().Table<CMeal>().Where(x => x.Name.ToUpper().Contains(text.ToUpper())).OrderByDescending(x => x.Calories).ToListAsync().Result;
                }
               
            }
        }
        public void Update(CMeal entity)
        {
            App.GetConnection().UpdateAsync(entity);
        }
        public List<CMeal> GetLikedMeals(string text, bool isAscending)
        {
            if (isAscending)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    return App.GetConnection().Table<CMeal>().Where(x => x.IsFav == true && x.Name.ToUpper().Contains(text.ToUpper())).OrderBy(x => x.Calories).ToListAsync().Result;
                }
                else
                {
                    return App.GetConnection().Table<CMeal>().Where(x => x.IsFav == true).OrderBy(x => x.Calories).ToListAsync().Result;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(text))
                {
                    return App.GetConnection().Table<CMeal>().Where(x => x.IsFav == true && x.Name.ToUpper().Contains(text.ToUpper())).OrderByDescending(x => x.Calories).ToListAsync().Result;
                }
                else
                {
                    return App.GetConnection().Table<CMeal>().Where(x => x.IsFav == true).OrderByDescending(x => x.Calories).ToListAsync().Result;
                }
            }
            
            
        }
        public void Delete(CMeal meal)
        {
            App.GetConnection().DeleteAsync(meal);
        }
    }
}
