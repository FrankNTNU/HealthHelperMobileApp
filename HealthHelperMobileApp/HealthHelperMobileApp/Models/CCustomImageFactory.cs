using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CCustomImageFactory
    {
        public CCustomImage GetCustomImage(int mealID, int memberID)
        {
            return App.GetConnection().Table<CCustomImage>().FirstOrDefaultAsync(x => x.MealID == mealID && x.MemberID == memberID).Result;
        }
        public void Add(CCustomImage customImage)
        {
             App.GetConnection().InsertAsync(customImage);
        }
        public void Update(CCustomImage customImage)
        {
            App.GetConnection().UpdateAsync(customImage);
        }
    }
}
