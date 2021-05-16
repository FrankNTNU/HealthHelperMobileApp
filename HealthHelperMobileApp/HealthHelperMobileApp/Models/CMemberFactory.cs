using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HealthHelperMobileApp.Models
{
    public class CMemberFactory
    {
        
        public void Add(CMember member)
        {
            App.GetConnection().InsertAsync(member);
        }
        public CMember GetMember(string username, string password)
        {
            return App.GetConnection().Table<CMember>().Where(x => x.Name == username && x.Password == password).FirstOrDefaultAsync().Result;
        }
        public void Update(CMember member)
        {
            if (member.ID != 0)
            {
                App.GetConnection().UpdateAsync(member);
            }
        }
       
    }
}
