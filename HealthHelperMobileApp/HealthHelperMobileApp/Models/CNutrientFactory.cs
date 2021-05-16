using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthHelperMobileApp.Models
{
    public class CNutrientFactory
    {
        public void Add(CNutrient nutrient)
        {
            App.GetConnection().InsertAsync(nutrient);
        }
        public CNutrient GetNutrient(int mealID)
        {
            return App.GetConnection().Table<CNutrient>().FirstOrDefaultAsync(x => x.MealID == mealID).Result;
        }
        public void Update(CNutrient nutrient)
        {
            App.GetConnection().UpdateAsync(nutrient);
        }
        public void Delete(CNutrient nutrient)
        {
            App.GetConnection().DeleteAsync(nutrient);
        }
    }
}
