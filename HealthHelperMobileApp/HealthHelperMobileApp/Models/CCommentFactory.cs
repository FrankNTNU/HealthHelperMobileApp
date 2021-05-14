using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CCommentFactory
    {
        public List<CComment> GetComments(int mealID)
        {
            return App.GetConnection().Table<CComment>().Where(x => x.MealID == mealID).ToListAsync().Result;
        }
        public void Add(CComment comment)
        {
            App.GetConnection().InsertAsync(comment);
        }
    }
}
