using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HealthHelperMobileApp.Models
{
    class CALFactory
    {
        SQLiteAsyncConnection conn;

        internal CALFactory()
        {
            getConn();
        }

        public SQLiteAsyncConnection getConn()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, "HH.db");
            if (conn == null)
            {
                conn = new SQLiteAsyncConnection(path);
                conn.CreateTableAsync<CActivityLevel>();
            }
            return conn;
        }
        internal void insert()
        {
            List<CActivityLevel> list;
            if ((list = getConn().Table<CActivityLevel>().ToListAsync().Result).Count > 0)
            {
                return;
            }

            List<CActivityLevel> alList = new List<CActivityLevel>();

            alList.Add(new CActivityLevel { ID = 1, Description = "輕度身體活動" });
            alList.Add(new CActivityLevel { ID = 2, Description = "中度身體活動" });
            alList.Add(new CActivityLevel { ID = 3, Description = "強度身體活動" });
            alList.Add(new CActivityLevel { ID = 4, Description = "坐式生活型態" });

            foreach (var item in alList)
            {
                conn.InsertAsync(item);
            }
        }
    }
}
