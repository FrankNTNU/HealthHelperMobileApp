using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CCommentFactory
    {
        public List<CComment> GetComments()
        {
            return App.GetConnection().Table<CComment>().ToListAsync().Result;
        }
        public List<CComment> GetComments(int mealID)
        {
            return App.GetConnection().Table<CComment>().Where(x => x.MealID == mealID).ToListAsync().Result;
        }
        public List<CComment> GetReplies(int commentID)
        {
            return App.GetConnection().Table<CComment>().Where(x => x.BasedCommentID == commentID).ToListAsync().Result;
        }
        public void Add(CComment comment)
        {
            App.GetConnection().InsertAsync(comment);
        }
        public void Update(CComment comment)
        {
            App.GetConnection().UpdateAsync(comment);
        }
        public void Delete(CComment comment)
        {
            App.GetConnection().DeleteAsync(comment);
        }
    }
}
