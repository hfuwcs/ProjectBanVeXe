using MyLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL
{
    internal class DriverDAL
    {
        private static DriverDAL instance;
        DbContext db = new DbContext();

        public static DriverDAL Instance { 
            get{
                if(instance == null)
                    instance = new DriverDAL();
                return instance;
            }
            private set => instance = value; 
        }
        public List<int> GetReadyDriverID(string today)
        {
            List<int> drivers = new List<int>();
            string sqls = "EXEC GETREADYDRIVER @TODAY";
            DataTable data = db.ExecuteQuery(sqls, new object[] {today});
            foreach (DataRow row in data.Rows) {
                drivers.Add(Convert.ToInt32(row["DRIVERID"].ToString()));
            }
            return drivers;
        }
    }
}
