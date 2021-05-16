using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthHelperMobileApp.Models
{
    public class CCommentFactory
    {
        public List<CComment> GetAllComments()
        {
            return App.GetConnection().Table<CComment>().ToListAsync().Result;
        }
        public Task<List<CComment>> GetComments()
        {
            return Task.FromResult(App.GetConnection().Table<CComment>().Where(x => x.BasedCommentID == 0).ToListAsync().Result);

        }
        public List<CComment> GetComments(int mealID)
        {
            return App.GetConnection().Table<CComment>().Where(x => x.MealID == mealID).OrderByDescending(x=>x.AddDate).ToListAsync().Result;
        }
        public Task<List<CComment>> GetComments(string text)
        {
            return Task.FromResult(App.GetConnection().Table<CComment>().Where(x => 
            x.MealName.ToUpper().Contains(text.ToUpper()) || x.MemberName.Contains(text)).ToListAsync().Result);
        }
        public Task<List<CComment>> GetComments(bool isAscending)
        {
            if (isAscending)
            {
                return Task.FromResult(App.GetConnection().Table<CComment>().OrderBy(x => x.AddDate).ToListAsync().Result);
            }
            else
            {
                return Task.FromResult(App.GetConnection().Table<CComment>().OrderByDescending(x => x.AddDate).ToListAsync().Result);
            }
            
        }
        public List<CComment> GetReplies(int commentID)
        {
            return App.GetConnection().Table<CComment>().Where(x => x.BasedCommentID == commentID).OrderByDescending(x => x.AddDate).ToListAsync().Result;
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
