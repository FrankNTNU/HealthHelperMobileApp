using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    public class CLogDetailFactory
    {
        public List<CDietDetail> GetDietLogDetails(int logID)
        {
            return App.GetConnection().Table<CDietDetail>().Where(x => x.DietLogID == logID).ToListAsync().Result;
        }
        public List<CDietDetail> GetDietLogDetails()
        {
            return App.GetConnection().Table<CDietDetail>().ToListAsync().Result;
        }
        public void Add(CDietDetail detail)
        {
            App.GetConnection().InsertAsync(detail);
        }

    }
}
